using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFSApi.ProjectStates
{
    class TATProjectState : IProjectState
    {
        public Guid ComponentTask => new Guid("b5244970-98e7-4ff9-a03c-052e9c5b6a79");

        public Guid NpmPackageTask => new Guid("485526bb-f315-444b-a1af-a0c1a68602b7");

        public Guid NugetPackageTask => new Guid("9dfd6355-9a9a-4826-a356-d20ec65a8061");

        public string DockerRepository => "loginvsi2";
    }
}
