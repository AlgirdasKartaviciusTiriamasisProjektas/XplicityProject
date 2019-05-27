using Contracts.Models;
using System;
using System.Collections.Generic;
using TFSApi.BranchStates;
using TFSApi.ProjectStates;

namespace TFSApi.TaskStates
{
    public class NpmPackageState : ITaskState
    {
        private readonly NewBuild _newBuild;
        private readonly IBranchState _branchState;
        private readonly IProjectState _projectState;

        public NpmPackageState(NewBuild newBuild, IBranchState branchState, IProjectState projectState)
        {
            _newBuild = newBuild;
            _branchState = branchState;
            _projectState = projectState;
        }

        public string GetBuildName() => _branchState.GetBuildName(_newBuild.Name + "TSClient");

        public string DisplayName => "Build NPM package";

        public IDictionary<string, string> Inputs => new Dictionary<string, string>
        {
            ["solutionFolder"] = _newBuild.ProjectLocation,
            ["suffix"] = _branchState.Suffix
        };

        public IDictionary<string, string> Variables => new Dictionary<string, string>();

        public Guid Id => _projectState.NpmPackageTask;

        public string PathFilters => _newBuild.ProjectLocation;

        public bool AllowAddTrigger => true;
    }
}