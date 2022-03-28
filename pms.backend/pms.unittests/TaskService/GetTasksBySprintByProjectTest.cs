using BusinessAccessLayer.services;
using DataAccessLayer.Models;
using NUnit.Framework;
using Moq;
using System;
using System.Threading.Tasks;
using DataLayer.repos.sprint;
using DataLayer.repos.task;
using BusinessAccessLayer.services.tasks;

namespace pms.unittests.TaskServiceTest
{
    [TestFixture]
    public class GetTasksBySprintByProjectTest
    {
        [Test]
        public void TaskService_TaskIdIsNull_ThrowArgumentNullException()
        {
            int taskId = 0;
            int projectId = 1;

            var RepoMock = new Mock<ITasksRepo<Tasks>>();
            RepoMock.Setup(x => x.GetTasksByProject(projectId));

            var sut = new TasksService(RepoMock.Object);

            //assert
            var ex = Assert.Throws<Exception>(() => sut.GetTasksByProjectBySprint(projectId, taskId));
            Assert.That(ex.Message, Is.EqualTo("Values cant be null"));
        }
        [Test]
        public void TaskService_ProjectIdIsNull_ThrowArgumentNullException()
        {
            int taskId = 1;
            int projectId = 0;

            var RepoMock = new Mock<ITasksRepo<Tasks>>();
            RepoMock.Setup(x => x.GetTasksByProject(projectId));

            var sut = new TasksService(RepoMock.Object);

            //assert
            var ex = Assert.Throws<Exception>(() => sut.GetTasksByProjectBySprint(projectId, taskId));
            Assert.That(ex.Message, Is.EqualTo("Values cant be null"));
        }
        [Test]
        public void TaskService_TaskIdAndProjectIdIsNull_ThrowArgumentNullException()
        {
            int taskId = 0;
            int projectId = 0;

            var RepoMock = new Mock<ITasksRepo<Tasks>>();
            RepoMock.Setup(x => x.GetTasksByProject(projectId));

            var sut = new TasksService(RepoMock.Object);

            //assert
            var ex = Assert.Throws<Exception>(() => sut.GetTasksByProjectBySprint(projectId, taskId));
            Assert.That(ex.Message, Is.EqualTo("Values cant be null"));
        }
    }
}
