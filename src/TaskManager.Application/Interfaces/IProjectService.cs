using TaskManager.Core.DTO.Request;
using TaskManager.Core.DTO.Response;
using TaskManager.Core.Entities;

namespace TaskManager.Application.Interfaces
{ 
    public interface IProjectService
    {
        ProjectResponse CreateProject(ProjectPostRequest projectPostRequest);
        ProjectResponse DeleteProject(int id);
        ProjectResponse UpdateProject(ProjectPutRequest projectPutRequest);
        IEnumerable<Project> GetProjects();
        IEnumerable<Project> GetProjects(int userId);
        Project GetProject(int id);
        ProjectUserResponse AddProjectUser(int projectId, int userId);
        ProjectUserResponse DeleteProjectUser(int projectId, int userId);
    }
}
