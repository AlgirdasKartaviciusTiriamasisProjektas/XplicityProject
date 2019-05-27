using Contracts;
using Contracts.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace TFSApi.Tests
{
    [TestClass]
    public class UnitTest1
    {
        private IBuildsClient _buildsClient;

        [TestInitialize]
        public void Initialize()
        {
            _buildsClient = new BuildsClient();
        }

        [DataTestMethod]
        [DataRow("f92a84af-e0b2-4d4a-809a-58f784be7b0d", "Shared", Tasks.Component)]
        [DataRow("a606604b-fafc-45f0-8386-77e625fa9a63", "Shared", Tasks.NpmPackage)]
        [DataRow("b8a4d7dd-2127-49f8-8a9a-a7cc97da17cd", "Shared", Tasks.NugetPackage)]
        [DataRow("b5244970-98e7-4ff9-a03c-052e9c5b6a79", "TAT", Tasks.Component)]
        [DataRow("485526bb-f315-444b-a1af-a0c1a68602b7", "TAT", Tasks.NpmPackage)]
        [DataRow("9dfd6355-9a9a-4826-a356-d20ec65a8061", "TAT", Tasks.NugetPackage)]
        public void ItReturns_ExpectedTask_WhenCreating(string taskId, string project, Tasks task)
        {
            //Create

            var newBuild = NewBuildCreateHelper(task);

            //Act

            var buildDefinition = _buildsClient.CreateBuildDefinition(project, newBuild);

            //Assert

            Assert.AreEqual(new Guid(taskId), buildDefinition.Steps[0].TaskDefinition.Id);
        }

        [DataTestMethod]
        [DataRow("loginvsi", "Shared", Tasks.Component)]
        [DataRow("loginvsi2", "TAT", Tasks.Component)]
        public void ItReturns_ExpectedDockerRepository_WhenCreating(string dockerimage, string project, Tasks task)
        {
            //Create

            var newBuild = NewBuildCreateHelper(task);

            //Act

            var buildDefinition = _buildsClient.CreateBuildDefinition(project, newBuild);

            //Assert

            Assert.IsTrue(buildDefinition.Steps[0].Inputs["dockerImageName"].StartsWith(dockerimage + "/"));
        }

        private static NewBuild NewBuildCreateHelper(Tasks task)
        {
            return new NewBuild
            {
                Branch = "master",
                Name = "NewBuild",
                Task = task
            };
        }
    }
}