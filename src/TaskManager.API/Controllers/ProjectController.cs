using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Interfaces;
using TaskManager.Core.DTO.Request;
using TaskManager.Core.DTO.Response;
using TaskManager.Core.Entities;

namespace TaskManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectService;

        public ProjectController(IProjectService projectService)
        {
            _projectService = projectService;
        }

        [HttpPost]
        public ProjectResponse PostProject(ProjectPostRequest projectPostRequest)
        {
            return _projectService.CreateProject(projectPostRequest);
        }

        [HttpDelete("{id}")]
        public ProjectResponse DeleteProject(int id)
        {
            return _projectService.DeleteProject(id);
        }

        [HttpPut]
        public ProjectResponse PutProject(ProjectPutRequest projectPutRequest)
        {
            return _projectService.UpdateProject(projectPutRequest);
        }

        [HttpGet]
        public IEnumerable<Project> GetProjects()
        {
            return _projectService.GetProjects();
        }

        [HttpGet("{id}")]
        public Project GetProject(int id)
        {
            return _projectService.GetProject(id);
        }

        [HttpGet("GetProjectByUserId")]
        public IEnumerable<Project> GetProjectByUserId(int userId)
        {
            return _projectService.GetProjects(userId);
        }

        [HttpPost("AddProjectUser")]
        public ProjectUserResponse AddProjectUser(int projectId, int userId)
        {
            return _projectService.AddProjectUser(projectId, userId);
        }

        [HttpDelete("DeletProjectUser")]
        public ProjectUserResponse DeletProjectUser(int projectId, int userId)
        {
            return _projectService.DeletProjectUser(projectId, userId);
        }

    }
}
