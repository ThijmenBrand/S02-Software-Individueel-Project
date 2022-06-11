using DataAccessLayer.Models;
using DataLayer.repos.project;
using NUnit.Framework;
using Moq;
using System;
using System.Threading.Tasks;
using BusinessLayer.services.project;
using ExceptionMiddleware;

namespace pms.unittests.ServiceProject
{
    [TestFixture]
    public class ValidateProjectTests
    {
        [Test]
        public void ValidateProject_GetProjectById_ThrowInputIdentifierCanNotBeZeroException()
        {
            int projectId = 0;

            var RepoMock = new Mock<IExcecuteProject>();
            RepoMock.Setup(x => x.ExcecuteGetProjectById(projectId));

            var sut = new ValidateProject(RepoMock.Object);

            var ex = Assert.ThrowsAsync<InputIdentifierCanNotBeZeroException>(async () => await sut.GetProjectById(projectId));
            Assert.That(ex.Message, Is.EqualTo("input has to be greater than zero"));
        }

        [Test]
        public void ValidateProject_AddProject_InputIdentifierCanNotBeNullException()
        {
            Project project = null;
            int userId = 1;

            var RepoMock = new Mock<IExcecuteProject>();
            RepoMock.Setup(x => x.ExcecuteAddProject(project, userId));

            var sut = new ValidateProject(RepoMock.Object);

            var ex = Assert.ThrowsAsync<InputIdentifierCanNotBeNullException>(async () => await sut.AddProject(project, userId));
            Assert.That(ex.Message, Is.EqualTo("input can not be null"));
        }

        [Test]
        public void ValidateProject_AddProject_ProjectParametersInvalidException()
        {
            Project project = new Project("", "");
            int userId = 1;

            var RepoMock = new Mock<IExcecuteProject>();
            RepoMock.Setup(x => x.ExcecuteAddProject(project, userId));

            var sut = new ValidateProject(RepoMock.Object);

            var ex = Assert.ThrowsAsync<ProjectParametersInvalidException>(async () => await sut.AddProject(project, userId));
            Assert.That(ex.Message, Is.EqualTo("Project name can not be empty!"));
        }

        [Test]
        public void ValidateProject_AddProject_InputIdentifierCanNotBeZeroException()
        {
            Project project = new Project("TestProject", "");
            int userId = 0;

            var RepoMock = new Mock<IExcecuteProject>();
            RepoMock.Setup(x => x.ExcecuteAddProject(project, userId));

            var sut = new ValidateProject(RepoMock.Object);

            var ex = Assert.ThrowsAsync<InputIdentifierCanNotBeZeroException>(async () => await sut.AddProject(project, userId));
            Assert.That(ex.Message, Is.EqualTo("input has to be greater than zero"));
        }

        [Test]
        public void ValidateProject_DeleteProject_InputIdentifierCanNotBeZeroException()
        {
            int projectId = 0;

            var RepoMock = new Mock<IExcecuteProject>();
            RepoMock.Setup(x => x.ExcecuteDeleteProject(projectId));

            var sut = new ValidateProject(RepoMock.Object);

            var ex = Assert.ThrowsAsync<InputIdentifierCanNotBeZeroException>(async () => await sut.DeleteProject(projectId));
            Assert.That(ex.Message, Is.EqualTo("input has to be greater than zero"));
        }
    }
}
