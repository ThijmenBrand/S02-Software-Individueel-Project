using BusinessLayer.services.project;
using DataAccessLayer.Models;
using DataLayer.repos.project;
using NUnit.Framework;
using Moq;
using System;
using System.Threading.Tasks;

namespace pms.unittests.ServiceProjectTests
{
    [TestFixture]
    public class DeleteProjectTests
    {
        [Test]
        public void ProjectService_ProjectIdIsZero_ThrowException()
        {
            //Arrange
            Project project = new Project();
            int projectId = 0;

            var RepoMock = new Mock<IExecuteServiceProject<Project>>();
            RepoMock.Setup(x => x.Delete(projectId));

            var sut = new ServiceProject(RepoMock.Object);

            //Act
            Assert.Throws<ArgumentNullException>(() => sut.DeleteProject(projectId));
        }
    }
}
