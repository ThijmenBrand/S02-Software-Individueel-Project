using Xunit;
using FluentAssertions;
using AutoFixture.Xunit2;
using System;
using System.Threading.Tasks;
using DataAccessLayer.Models;

namespace pms.unittests.ServiceProjectTest
{
    public class ServiceProjectTest
    {
        ServiceProjectBuilder _builder;

        public ServiceProjectTest()
        {
            _builder = new ServiceProjectBuilder();
        }

        [Theory, AutoData]
        public async Task ProjectService_ProjectIsNull_ThrowArgurmentNullException(bool returnvalue)
        {
            //Arrange
            var sut = _builder
                .MockCreateNewProject(null, returnvalue)
                .Build();

            Func<Task> action = async () => await sut.AddProject(null);

            await action.Should().ThrowAsync<Exception>().WithMessage("Project cant be null");
        }

        [Theory, AutoData]
        public async Task ServiceProject_ProjectParamsInvalid
    }
}