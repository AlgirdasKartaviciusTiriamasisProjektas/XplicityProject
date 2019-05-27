namespace Contracts.Models
{
    public class NewBuild
    {
        public string Name { get; set; }

        public string Repo { get; set; }

        public string Branch { get; set; }

        public string AgentQueue { get; set; }

        public string Root { get; set; }

        public Tasks Task { get; set; }

        public string ProjectLocation { get; set; }
    }
}