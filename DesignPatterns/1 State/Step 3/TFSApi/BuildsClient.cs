using Contracts;
using Contracts.Models;
using Microsoft.TeamFoundation.Build.WebApi;
using Microsoft.VisualStudio.Services.Common;
using System.Linq;
using TFSApi.BranchStates;
using TFSApi.TaskStates;

namespace TFSApi
{
    public class BuildsClient : IBuildsClient
    {
        private readonly BranchStateFactory _branchStateFactory = new BranchStateFactory();

        private readonly TaskStateFactory _taskStateFactory = new TaskStateFactory();

        public BuildDefinition CreateBuildDefinition(string project, NewBuild newBuild)
        {
            var branchState = _branchStateFactory.Create(newBuild.Branch);

            var taskState = _taskStateFactory.Create(project, newBuild, branchState);

            var buildName = taskState.GetBuildName();

            var newDefinition = new BuildDefinition();

            newDefinition.Name = buildName;

            newDefinition.Repository = new BuildRepository
            {
                CheckoutSubmodules = false,
                Clean = "true",
                DefaultBranch = branchState.DefaultBranch,
                Name = newBuild.Repo,
                Properties =
                {
                    ["reportBuildStatus"] = "true",
                    ["cleanOptions"] = "3"
                },
                Type = "TfsGit"
            };

            newDefinition.Queue = new AgentPoolQueue
            {
                Name = newBuild.AgentQueue
            };

            if (taskState.AllowAddTrigger)
            {
                newDefinition.Triggers.Add(
                    new ContinuousIntegrationTrigger
                    {
                        BatchChanges = true,
                        BranchFilters = {branchState.BranchFilter},
                        MaxConcurrentBuildsPerBranch = 1,
                        PathFilters = {"+/" + taskState.PathFilters}
                    });
            }

            var buildStep = new BuildDefinitionStep
            {
                AlwaysRun = true,
                ContinueOnError = true,
                DisplayName = taskState.DisplayName,
                Enabled = true,
                TaskDefinition = new TaskDefinitionReference
                {
                    DefinitionType = "metaTask",
                    Id = taskState.Id,
                    VersionSpec = "1.*"
                },
                TimeoutInMinutes = 0
            };
            buildStep.Inputs.AddRange(taskState.Inputs);
            newDefinition.Steps.Add(buildStep);

            newDefinition.Variables.AddRange(
                taskState.Variables.ToDictionary(
                    pair => pair.Key,
                    pair => new BuildDefinitionVariable
                    {
                        IsSecret = false,
                        AllowOverride = true,
                        Value = pair.Value
                    })
            );

            newDefinition.Path = newBuild.Root + "\\" + newBuild.Name;

            newDefinition.DefinitionQuality = DefinitionQuality.Definition;

            newDefinition.JobTimeoutInMinutes = 60;

            //newDefinition.RetentionRules.Add(
            //    new RetentionPolicy()
            //    {

            //    });

            return newDefinition;
        }
    }
}