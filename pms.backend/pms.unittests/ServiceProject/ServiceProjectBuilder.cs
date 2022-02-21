using DataAccessLayer.contracts;
using DataAccessLayer.Models;
using BusinessAccessLayer.services;
using BusinessAccessLayer.extensions;
using Moq;

namespace pms.unittests.ServiceProjectTest
{
    public class ServiceProjectBuilder
    {
        private readonly Mock<IProjectRepo<Project>> _repository;
        private readonly Mock<ProjectValidator> _validator;

        public ServiceProjectBuilder()
        {
            _repository = new Mock<IProjectRepo<Project>>();
            _validator = new Mock<ProjectValidator>();
        }

        public ServiceProject Build()
        {
            return new ServiceProject(_repository.Object);
        }

        public ServiceProjectBuilder MockCreateNewProject(Project project, bool returnvalue)
        {
            _repository
                .Setup(x => x.Create(project))
                .ReturnsAsync(returnvalue);

            return this;
        }
    }
}
