using System.Collections.Generic;

namespace TFSApi.BranchStates
{
    public interface IBranchState
    {
        string GetBuildName(string name);

        string DefaultBranch { get; }

        string BranchFilter { get; }

        string DockerImageTag { get; }

        IDictionary<string, string> Variables { get; }

        string Suffix { get; }

        bool AllowAddTrigger { get; }
    }
}