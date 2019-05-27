using Contracts.Models;
using System;
using System.Collections.Generic;
using TFSApi.BranchStates;
using TFSApi.ProjectStates;

namespace TFSApi.TaskStates
{
    public class ComponentState : ITaskState
    {
        private readonly NewBuild _newBuild;
        private readonly IBranchState _branchState;
        private readonly IProjectState _projectState;

        public ComponentState(NewBuild newBuild, IBranchState branchState, IProjectState projectState)
        {
            _newBuild = newBuild;
            _branchState = branchState;
            _projectState = projectState;
        }

        public string GetBuildName() => _branchState.GetBuildName(_newBuild.Name);

        public string DisplayName => "Restore and Build Solution";

        public IDictionary<string, string> Inputs => new Dictionary<string, string>
        {
            ["solutionLocation"] = _newBuild.Name,
            ["projectLocation"] = _newBuild.ProjectLocation,
            ["dockerFile"] = "Dockerfile",
            ["dockerImageName"] = _projectState.DockerRepository + "/" + _newBuild.Name.ToLower(),
            ["dockerImageTag"] = _branchState.DockerImageTag
        };

        public IDictionary<string, string> Variables => _branchState.Variables;

        public Guid Id => _projectState.ComponentTask;

        public string PathFilters => _newBuild.Name;

        public bool AllowAddTrigger => _branchState.AllowAddTrigger;
    }
}