using DataAccessLayer.Models;
using NUnit.Framework;
using Moq;
using System;
using System.Threading.Tasks;
using DataLayer.repos.sprint;
using DataLayer.repos.task;
using BusinessLayer.services.tasks;

namespace pms.unittests.TaskServiceTest
{
    [TestFixture]
    public class GetTasksBySprintByProjectTest
    {
        [Test]
        public void TaskService_TaskIdIsNull_ThrowArgumentNullException()
        {
            int sprintId = 0;

            var RepoMock = new Mock<ITasksRepo<Tasks>>();
            RepoMock.Setup(x => x.GetTasksBySprint(sprintId));

            var sut = new TasksService(RepoMock.Object);

            //assert
            var ex = Assert.Throws<Exception>(() => sut.GetTasksByProjectBySprint(sprintId));
            Assert.That(ex.Message, Is.EqualTo("sprintId cant be null"));
        }
    }
}
