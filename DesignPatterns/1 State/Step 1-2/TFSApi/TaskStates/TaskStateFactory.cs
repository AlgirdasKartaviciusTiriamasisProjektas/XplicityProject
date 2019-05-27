using Contracts;
using Contracts.Models;
using System;
using TFSApi.BranchStates;

namespace TFSApi.TaskStates
{
    public class TaskStateFactory
    {
        public ITaskState Create(string project, NewBuild newBuild, IBranchState branchState)
        {
            var task = newBuild.Task;

            switch (task)
            {
                case Tasks.Component:
                    return new ComponentState(newBuild, branchState, project);

                case Tasks.NugetPackage:
                    return new NugetPackageState(newBuild, branchState, project);

                case Tasks.NpmPackage:
                    return new NpmPackageState(newBuild, branchState, project);

                default:
                    throw new Exception($"Build steps for task '{task}' were not implementated");
            }
        }
    }
}