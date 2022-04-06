using BusinessLayer.services.project;
using DataAccessLayer.Models;
using DataLayer.repos.project;
using NUnit.Framework;
using Moq;
using System;

namespace pms.unittests.ServiceProjectTests
{
    [TestFixture]
    public class UpdateProjectTests
    {
        [Test]
        public void ProjectService_UpdateProjectProjectIdIsZero_ThrowException()
        {
            //Arrange
            Project project = new Project();
            int projectId = 0;

            var RepoMock = new Mock<IProjectRepo<Project>>();
            RepoMock.Setup(x => x.Update(project));

            var sut = new ServiceProject(RepoMock.Object);

            //Act
            Assert.Throws<ArgumentNullException>(() => sut.UpdateProject(projectId));
        }
    }
}
