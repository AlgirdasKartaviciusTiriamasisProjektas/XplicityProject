using System.Collections.Generic;

namespace TFSApi.BranchStates
{
    public class StableBranch : IBranchState
    {
        private const string DockerImageTagVariable = "dockerImageTag";

        public string GetBuildName(string name) => name + "-stable";

        public string DefaultBranch => "refs/heads/stable";

        public string BranchFilter => "+refs/heads/stable";

        public string DockerImageTag => $"$({DockerImageTagVariable})";

        public IDictionary<string, string> Variables => new Dictionary<string, string>
        {
            [DockerImageTagVariable] = "0.1.0"
        };

        public string Suffix => "\"\"";

        public bool AllowAddTrigger => false;
    }
}