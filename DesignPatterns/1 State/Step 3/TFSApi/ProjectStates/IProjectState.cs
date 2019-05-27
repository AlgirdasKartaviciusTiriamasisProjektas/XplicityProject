using System;

namespace TFSApi.ProjectStates
{
    public interface IProjectState
    {
        Guid ComponentTask { get; }

        Guid NpmPackageTask { get; }

        Guid NugetPackageTask { get; }

        string DockerRepository { get; }
    }
}