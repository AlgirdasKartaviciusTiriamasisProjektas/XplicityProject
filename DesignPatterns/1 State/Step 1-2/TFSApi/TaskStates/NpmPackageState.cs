using Contracts.Models;
using System;
using System.Collections.Generic;
using TFSApi.BranchStates;

namespace TFSApi.TaskStates
{
    public class NpmPackageState : ITaskState
    {
        private readonly NewBuild _newBuild;
        private readonly IBranchState _branchState;
        private readonly string _project;

        public NpmPackageState(NewBuild newBuild, IBranchState branchState, string project)
        {
            _newBuild = newBuild;
            _branchState = branchState;
            _project = project;
        }

        public string GetBuildName() => _branchState.GetBuildName(_newBuild.Name + "TSClient");

        public string DisplayName => "Build NPM package";

        public IDictionary<string, string> Inputs => new Dictionary<string, string>
        {
            ["solutionFolder"] = _newBuild.ProjectLocation,
            ["suffix"] = _branchState.Suffix
        };

        public IDictionary<string, string> Variables => new Dictionary<string, string>();

        public Guid Id => new Guid(GetId(_project));

        public string PathFilters => _newBuild.ProjectLocation;

        public bool AllowAddTrigger => true;
        public string GetId(string _project)
        {
            return _project == "TAT" ? "485526bb-f315-444b-a1af-a0c1a68602b7" : "a606604b-fafc-45f0-8386-77e625fa9a63";
        }
    }
}