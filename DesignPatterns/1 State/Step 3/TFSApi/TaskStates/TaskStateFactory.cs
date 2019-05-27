using Contracts;
using Contracts.Models;
using System;
using TFSApi.BranchStates;
using TFSApi.ProjectStates;

namespace TFSApi.TaskStates
{
    public class TaskStateFactory
    {
        private readonly ProjectStateFactory _projectStateFactory = new ProjectStateFactory();

        public ITaskState Create(string project, NewBuild newBuild, IBranchState branchState)
        {
            var task = newBuild.Task;

            var projectState = _projectStateFactory.Create(project);

            switch (task)
            {
                case Tasks.Component:
                    return new ComponentState(newBuild, branchState, projectState);

                case Tasks.NugetPackage:
                    return new NugetPackageState(newBuild, branchState, projectState);

                case Tasks.NpmPackage:
                    return new NpmPackageState(newBuild, branchState, projectState);

                default:
                    throw new Exception($"Build steps for task '{task}' were not implementated");
            }
        }
    }
}