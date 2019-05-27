using System;

namespace TFSApi.ProjectStates
{
    public class ProjectStateFactory
    {
        public IProjectState Create(string project)
        {
            switch (project)
            {
                case "Shared":
                    return new SharedProjectState();
                case "TAT":
                    return new TATProjectState();
                default:
                    throw new Exception($"Tasks for project '{project}' were not implementated");
            }
        }
    }
}