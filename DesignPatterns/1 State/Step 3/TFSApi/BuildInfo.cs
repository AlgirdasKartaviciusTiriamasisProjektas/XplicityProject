using Microsoft.TeamFoundation.Build.WebApi;

namespace TFSApi
{
    public class BuildInfo
    {
        public BuildDefinition Definition { get; set; }

        public Build LastBuild { get; set; }

        public Build FirstBroken { get; set; }

        public override string ToString()
        {
            return Definition?.Name ?? "";
        }
    }
}