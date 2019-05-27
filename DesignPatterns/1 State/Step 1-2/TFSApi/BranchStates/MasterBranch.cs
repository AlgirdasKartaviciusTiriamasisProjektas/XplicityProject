using System.Collections.Generic;

namespace TFSApi.BranchStates
{
    public class MasterBranch : IBranchState
    {
        public string GetBuildName(string name) => name + "-master";

        public string DefaultBranch => "refs/heads/master";

        public string BranchFilter => "+refs/heads/master";

        public string DockerImageTag => "dev";

        public IDictionary<string, string> Variables => new Dictionary<string, string>
        {
            ["system.debug"] = "false"
        };

        public string Suffix => "dev";

        public bool AllowAddTrigger => true;
    }
}