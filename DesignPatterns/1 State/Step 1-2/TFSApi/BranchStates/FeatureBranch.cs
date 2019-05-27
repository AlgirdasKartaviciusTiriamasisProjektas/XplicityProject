using System;
using System.Collections.Generic;

namespace TFSApi.BranchStates
{
    public class FeatureBranch : IBranchState
    {
        private readonly string _branchName;

        public FeatureBranch(string branchName)
        {
            if (string.IsNullOrWhiteSpace(branchName))
            {
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(branchName));
            }

            _branchName = branchName;
        }

        public string GetBuildName(string name) => name + "-" + _branchName;

        public string DefaultBranch => "refs/heads/" + _branchName;

        public string BranchFilter => "+refs/heads/" + _branchName;

        public string DockerImageTag => _branchName.ToLower();

        public IDictionary<string, string> Variables => new Dictionary<string, string>
        {
            ["system.debug"] = "false"
        };

        public string Suffix => _branchName;

        public bool AllowAddTrigger => true;
    }
}