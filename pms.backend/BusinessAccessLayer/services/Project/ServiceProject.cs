﻿using DataAccessLayer.Models;
using DataLayer.repos.project;
using BusinessAccessLayer.extensions;
using Microsoft.AspNetCore.Mvc;

namespace BusinessLayer.services.project
{
    public class ServiceProject : IServiceProject
    {
        private readonly IProjectRepo<Project> _repository;
        private readonly ProjectValidator _validator = new ProjectValidator();
        
        public ServiceProject(IProjectRepo<Project> _repository)
        {
            this._repository = _repository;
        }

        public async Task<bool> AddProject(Project project, int UserId)
        {
            try
            {
                if(project == null)
                {
                    throw new Exception("Project cant be null");
                }

                if (!_validator.ProjectParameterValidator(project))
                {
                    throw new Exception("One or more project parameters are invalid");
                } else
                {
                    project.ProjectDate = DateTime.Now;
                    return await _repository.Create(project, UserId);
                }
            } catch (Exception)
            {
                throw;
            }
        }
        public void DeleteProject(int id)
        {
            try
            {
                if(id != 0)
                {
                    _repository.Delete(id);
                } else
                {
                    throw new ArgumentNullException();
                }
            } catch(Exception)
            {
                throw;
            }
        }
        public IEnumerable<Project> GetAllProjects(int UserId)
        {
            try
            {
                return _repository.GetAll(UserId).ToList();
            } catch (Exception)
            {
                throw;
            }
        }
    }
}
