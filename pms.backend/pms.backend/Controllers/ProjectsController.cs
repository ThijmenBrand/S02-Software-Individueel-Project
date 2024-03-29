﻿using ApiLayer.Helpers;
using BusinessLayer.services.project;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApiLayer.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectsController : ControllerBase
    {

        private readonly IValidateProject serviceProject;

        public ProjectsController(IValidateProject serviceProject)
        {
            this.serviceProject = serviceProject;
        }

        [HttpGet]
        public ActionResult<List<Project>> GetAllProjects()
        {
            return Ok(serviceProject.GetAllProjects(GetUserId.getUserId()));
        }

        [HttpPost]
        public async Task<ActionResult<List<Project>>> AddProject(Project project)
        {
            await serviceProject.AddProject(project, GetUserId.getUserId());
            return Ok(serviceProject.GetAllProjects(GetUserId.getUserId()));
        }

        [HttpGet("{projectId}")]
        public async Task<ActionResult<Project>> GetProjectById(int projectId)
        {
            return Ok(await serviceProject.GetProjectById(projectId));
        }
    }
}
