using System;
using System.Collections.Generic;

namespace TFSApi.TaskStates
{
    public interface ITaskState
    {
        string GetBuildName();

        string DisplayName { get; }

        IDictionary<string, string> Inputs { get; }

        Guid Id { get; }

        string PathFilters { get; }

        IDictionary<string, string> Variables { get; }

        bool AllowAddTrigger { get; }
    }
}