using DataAccessLayer.Models;
using NUnit.Framework;
using Moq;
using DataLayer.repos.task;
using BusinessAccessLayer.services.tasks;
using System;
using System.Threading.Tasks;

namespace pms.unittests.TaskServiceTest
{
    [TestFixture]
    public class CreateTaskTest
    {
        [Test]
        public void TaskService_TaskIsNull_ThrowException()
        {
            Tasks task = null;
            bool expected = false;

            var RepoMock = new Mock<ITasksRepo<Tasks>>();
            RepoMock.Setup(x => x.Create(task)).ReturnsAsync(expected);

            var sut = new TasksService(RepoMock.Object);

            //assert
            var ex = Assert.ThrowsAsync<Exception>(async () => await sut.CreateTask(task));
            Assert.That(ex.Message, Is.EqualTo("task cant be null"));
        }
        [Test]
        public async Task TaskService_TaskIsValid_ReturnTrue()
        {
            Tasks task = new Tasks();
            task.TaskTag = "doing";
            task.SprintId = 1;
            task.TaskDescription = "";
            task.TaskEndTime = DateTime.Now;
            task.TaskStartTime = DateTime.Now;
            task.TaskName = "test";

            bool expected = true;

            var RepoMock = new Mock<ITasksRepo<Tasks>>();
            RepoMock.Setup(x => x.Create(task)).ReturnsAsync(expected);

            var sut = new TasksService(RepoMock.Object);

            //act
            var result = await sut.CreateTask(task);

            //assert
            Assert.That(result, Is.True);
        }
    }
}
