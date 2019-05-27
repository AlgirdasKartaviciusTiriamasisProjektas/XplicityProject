using System;

namespace TFSApi.ProjectStates
{
    public class SharedProjectState : IProjectState
    {
        public Guid ComponentTask => new Guid("f92a84af-e0b2-4d4a-809a-58f784be7b0d");

        public Guid NpmPackageTask => new Guid("a606604b-fafc-45f0-8386-77e625fa9a63");

        public Guid NugetPackageTask => new Guid("b8a4d7dd-2127-49f8-8a9a-a7cc97da17cd");

        public string DockerRepository => "loginvsi";
    }
}