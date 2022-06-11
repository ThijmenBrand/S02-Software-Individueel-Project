using DataAccessLayer.Models;
using DataLayer.repos.sprint;
using BusinessLayer.services.sprint;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ExceptionMiddleware;

namespace pms.unittests.SprintService
{
    [TestFixture]
    public class ValidateSprintTests
    {
        [Test]
        public void SprintService_SprintIsNull_ThrowException()
        {
            //Arrange
            Sprint sprint = null;
            bool expected = false;

            var RepoMock = new Mock<IExcecuteSprintService>();
            RepoMock.Setup(x => x.ExcecuteAddSprint(sprint));

            var sut = new ValidateSprint(RepoMock.Object);

            //Assert
            var ex = Assert.ThrowsAsync<InputIdentifierCanNotBeNullException>(async () => await sut.AddSprint(sprint));
            Assert.That(ex.Message, Is.EqualTo("input can not be null"));
        }
    }
}
