using Contracts.Models;
using System;
using System.Collections.Generic;
using System.IO;
using TFSApi.BranchStates;

namespace TFSApi.TaskStates
{
    public class NugetPackageState : ITaskState
    {
        private readonly NewBuild _newBuild;
        private readonly IBranchState _branchState;
        private readonly string _project;

        public NugetPackageState(NewBuild newBuild, IBranchState branchState, string project)
        {
            _newBuild = newBuild;
            _branchState = branchState;
            _project = project;
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

        public Guid Id => new Guid(GetId(_project));

        public string PathFilters => _newBuild.ProjectLocation;

        public bool AllowAddTrigger => _branchState.AllowAddTrigger;

        public string GetId(string _project)
        {
            return _project == "TAT" ? "9dfd6355-9a9a-4826-a356-d20ec65a8061" : "b8a4d7dd-2127-49f8-8a9a-a7cc97da17cd";
        }
    }
}