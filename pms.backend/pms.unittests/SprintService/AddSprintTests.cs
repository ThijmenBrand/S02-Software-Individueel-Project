using BusinessAccessLayer.services;
using DataAccessLayer.Models;
using NUnit.Framework;
using Moq;
using System;
using System.Threading.Tasks;
using DataLayer.repos.sprint;

namespace pms.unittests.SprintServiceTest
{
    [TestFixture]
    public class AddSprintTests
    {
        [Test]
        public void SprintService_SprintIsNull_ThrowException()
        {
            //Arrange
            Sprint sprint = null;
            bool expected = false;

            var RepoMock = new Mock<ISprintRepo<Sprint>>();
            RepoMock.Setup(x => x.Create(sprint)).ReturnsAsync(expected);

            var sut = new SprintService(RepoMock.Object);

            //Assert
            var ex = Assert.ThrowsAsync<Exception>(async () => await sut.AddSprint(sprint));
            Assert.That(ex.Message, Is.EqualTo("Sprint cant be null!"));
        }

        [Test]
        public async Task SprintService_SprintIsValid_ReturnTrue()
        {
            Sprint sprint = new Sprint();
            sprint.SprintStart = DateTime.Now;
            sprint.SprintDuration = 10;
            sprint.ProjectId = 1;

            bool expected = true;

            var RepoMock = new Mock<ISprintRepo<Sprint>>();
            RepoMock.Setup(x => x.Create(sprint)).ReturnsAsync(expected);

            var sut = new SprintService(RepoMock.Object);

            //act
            var result = await sut.AddSprint(sprint);
            
            //assert
            Assert.AreEqual(expected, result);
        }
    }
}
