using Contracts.Models;
using System;
using System.Collections.Generic;
using TFSApi.BranchStates;

namespace TFSApi.TaskStates
{
    public class ComponentState : ITaskState
    {
        private readonly NewBuild _newBuild;
        private readonly IBranchState _branchState;
        private readonly string _project;

        public ComponentState(NewBuild newBuild, IBranchState branchState, string project)
        {
            _newBuild = newBuild;
            _branchState = branchState;
            _project = project;
        }

        public string GetBuildName() => _branchState.GetBuildName(_newBuild.Name);

        public string DisplayName => "Restore and Build Solution";

        public IDictionary<string, string> Inputs => GetDictionary(_project);

        public IDictionary<string, string> Variables => _branchState.Variables;

        public Guid Id => new Guid(GetId(_project));

        public string PathFilters => _newBuild.Name;

        public bool AllowAddTrigger => _branchState.AllowAddTrigger;

        public string GetId(string _project)
        {
            return _project == "TAT" ? "b5244970-98e7-4ff9-a03c-052e9c5b6a79" : "f92a84af-e0b2-4d4a-809a-58f784be7b0d";
        }

        public Dictionary<string, string> GetDictionary(string _project)
        {
            if (_project == "TAT")
            {
                return new Dictionary<string, string>
                {
                    ["solutionLocation"] = _newBuild.Name,
                    ["projectLocation"] = _newBuild.ProjectLocation,
                    ["dockerFile"] = "Dockerfile",
                    ["dockerImageName"] = "loginvsi2/" + _newBuild.Name.ToLower(),
                    ["dockerImageTag"] = _branchState.DockerImageTag
                };
            }
            else
            {
                return new Dictionary<string, string>
                {
                    ["solutionLocation"] = _newBuild.Name,
                    ["projectLocation"] = _newBuild.ProjectLocation,
                    ["dockerFile"] = "Dockerfile",
                    ["dockerImageName"] = "loginvsi/" + _newBuild.Name.ToLower(),
                    ["dockerImageTag"] = _branchState.DockerImageTag
                };
            }
        }
    }


}