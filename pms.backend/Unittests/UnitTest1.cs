using FluentAssertions;
using Moq;
using System;
using System.Threading.Tasks;
using DataAccessLayer.Models;
using DataLayer.repos.project;
using BusinessAccessLayer.services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace pms.unittests.ServiceProjectTest
{
    [TestClass]
    public class ServiceProjectTest
    {
        [TestMethod]
        public void ProjectService_ProjectIsNull_ThrowArgurmentNullExceptio()
        {
            //Arrange
            Project project = null;
            bool expected = false;


            var RepoMock = new Mock<IProjectRepo<Project>>();
            RepoMock.Setup(x => x.Create(project)).ReturnsAsync(expected);

            var sut = new ServiceProject(RepoMock.Object);

            //Act
            Func<Task> action = async () => await sut.AddProject(project);

            //Assert
            action.Should().ThrowAsync<Exception>().WithMessage("Project cant be null");

        }
    }
}