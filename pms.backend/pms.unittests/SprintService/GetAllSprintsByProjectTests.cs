using BusinessLayer.services.sprint;
using DataAccessLayer.Models;
using NUnit.Framework;
using Moq;
using System;
using DataLayer.repos.sprint;

namespace pms.unittests.SprintServiceTest
{
    [TestFixture]
    public class GetAllSprintsByProjectTests
    {
        [Test]
        public void SprintService_ProjectIdIsNull_ThrowException()
        {

            int ProjectId = 0;
            Sprint expected = new Sprint();

            var RepoMock = new Mock<ISprintRepo<Sprint>>();
            RepoMock.Setup(x => x.GetAllByProject(ProjectId));

            var sut = new SprintService(RepoMock.Object);

            //act
            var ex = Assert.Throws<Exception>(() => sut.GetAllSprintsByProject(ProjectId));
            Assert.That(ex.Message, Is.EqualTo("ProjectId cant be null"));
        }
    }
}
