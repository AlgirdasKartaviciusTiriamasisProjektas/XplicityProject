using Contracts.Models;
using System;
using System.Collections.Generic;
using System.IO;
using TFSApi.BranchStates;
using TFSApi.ProjectStates;

namespace TFSApi.TaskStates
{
    public class NugetPackageState : ITaskState
    {
        private readonly NewBuild _newBuild;
        private readonly IBranchState _branchState;
        private readonly IProjectState _projectState;

        public NugetPackageState(NewBuild newBuild, IBranchState branchState, IProjectState projectState)
        {
            _newBuild = newBuild;
            _branchState = branchState;
            _projectState = projectState;
        }

        public string GetBuildName()
        {
            var projectName = Path.GetFileName(_newBuild.ProjectLocation)?
                .Replace(".", "")
                .Replace("LoginVsi", "");
           return _branchState.GetBuildName(projectName);
        }

        public string DisplayName => "Create Contracts NuGet";

        public IDictionary<string, string> Inputs => new Dictionary<string, string>
        {
            ["projectLocation"] = _newBuild.ProjectLocation,
            ["suffix"] = _branchState.Suffix
        };

        public IDictionary<string, string> Variables => new Dictionary<string, string>();

        public Guid Id => _projectState.NugetPackageTask;

        public string PathFilters => _newBuild.ProjectLocation;

        public bool AllowAddTrigger => _branchState.AllowAddTrigger;
    }
}