using BusinessLayer.services.project;
using DataAccessLayer.Models;
using DataLayer.repos.project;
using NUnit.Framework;
using Moq;
using System;
using System.Threading.Tasks;

namespace pms.unittests.ServiceProjectTest
{
    [TestFixture]
    public class ServiceProjectTest
    {
        [Test]
        public void  ProjectService_ProjectIsNull_ThrowArgurmentNullException()
        {
            //Arrange
            Project project = null;
            bool expected = false;


            var RepoMock = new Mock<IExecuteServiceProject<Project>>();
            RepoMock.Setup(x => x.Create(project, 1)).ReturnsAsync(expected);

            var sut = new ServiceProject(RepoMock.Object);

            //Assert
            var ex = Assert.ThrowsAsync<Exception>(async () => await sut.AddProject(project, 1));
            Assert.That(ex.Message, Is.EqualTo("Project cant be null"));
        }

        [Test]
        public void ProjectService_ProjectParamsInvalid_ThrowException()
        {
            //Arrange
            Project project = new Project();
            project.ProjectName = "";
            project.ProjectDescription = "";
            bool expected = false;

            var RepoMock = new Mock<IExecuteServiceProject<Project>>();
            RepoMock.Setup(x => x.Create(project, 1)).ReturnsAsync(expected);

            var sut = new ServiceProject(RepoMock.Object);

            //Assert
            var ex = Assert.ThrowsAsync<Exception>(async () => await sut.AddProject(project, 1));
            Assert.That(ex.Message, Is.EqualTo("One or more project parameters are invalid"));
        }

        [Test]
        public async Task ProjectService_ProjectIsValid_CreateProject()
        {
            //Arrange
            Project project = new Project();
            project.ProjectName = "test123";
            project.ProjectDescription = "test123";

            bool expected = true;

            var RepoMock = new Mock<IExecuteServiceProject<Project>>();
            RepoMock.Setup(x => x.Create(project, project.ProjectOwnerId)).ReturnsAsync(expected);

            var sut = new ServiceProject(RepoMock.Object);

            //Act
            var result = await sut.AddProject(project, 1);

            //Assert
            Assert.AreEqual(expected, result);

        }
    }
}