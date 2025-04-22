using TaskManager.Application.Interfaces;
using TaskManager.Core.DTO.Request;
using TaskManager.Core.DTO.Response;
using TaskManager.Infrastructure.Interfaces;
using TaskManager.Infrastructure.Repositories;
using TaskManager.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace TaskManager.Application.Implementations
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        private readonly IProjectUserRepository _projectUserRepository;

        public ProjectService(IProjectRepository projectRepository, IProjectUserRepository projectUserRepository)
        {
            _projectRepository = projectRepository;
            _projectUserRepository = projectUserRepository;
        }

        public ProjectResponse CreateProject(ProjectPostRequest projectPostRequest) 
        {
            ProjectResponse projectResponse = new ProjectResponse();

            try
            {
                Project project = _projectRepository.CreateProject(new Project() { ProjectName = projectPostRequest.ProjectName });

                projectResponse.Project = project;
                projectResponse.Message = "Projeto criado com sucesso";
                projectResponse.Success = true;
            }
            catch (Exception e)
            {
                projectResponse.Message = e.Message;
                projectResponse.Success = false;
            }

            return projectResponse;
        }

        public ProjectResponse DeleteProject(int id)
        {
            ProjectResponse projectResponse = new ProjectResponse();

            try
            {
                bool result = _projectRepository.DeleteProject(id);

                projectResponse.Message = "Projeto deletado com sucesso";
                projectResponse.Success = result;
            }
            catch (Exception e)
            {
                projectResponse.Message = e.Message;
                projectResponse.Success = false;
            }

            return projectResponse;
        }

        public ProjectResponse UpdateProject(ProjectPutRequest projectPutRequest)
        {
            ProjectResponse projectResponse = new ProjectResponse();

            try {
                Project project = _projectRepository.UpdateProject(new Project() { Id = projectPutRequest.Id, ProjectName = projectPutRequest.ProjectName });

                projectResponse.Project = project;
                projectResponse.Message = "Projeto atualizado com sucesso";
                projectResponse.Success = true;
            }
            catch (Exception e)
            {
                projectResponse.Message = e.Message;
                projectResponse.Success = false;
            }


            return projectResponse;
        }

        public IEnumerable<Project> GetProjects()
        {
            return _projectRepository.GetProjects();
        }

        public IEnumerable<Project> GetProjects(int userId)
        {
            return _projectRepository.GetProjects(userId);
        }

        public Project GetProject(int id)
        {
           return _projectRepository.GetProject(id);
        }

        public ProjectUserResponse AddProjectUser(int projectId, int userId) 
        {
            ProjectUserResponse projectUserResponse = new ProjectUserResponse();

            try
            {
                ProjectUser projectUser = _projectUserRepository.CreateProjectUser(new ProjectUser() { ProjectId = projectId, UserId = userId });

                projectUserResponse.ProjectUser = projectUser;
                projectUserResponse.Message = "Usuário adicionado ao projeto com sucesso";
                projectUserResponse.Success = true;
            }
            catch (Exception e)
            {
                projectUserResponse.Message = e.Message;
                projectUserResponse.Success = false;
            }

            return projectUserResponse;
        }

        public ProjectUserResponse DeleteProjectUser(int projectId, int userId)
        {
            ProjectUserResponse projectUserResponse = new ProjectUserResponse();

            try {
                bool result = _projectUserRepository.DeleteProjectUser(projectId, userId);

                projectUserResponse.Message = "Usuário removido do projeto com sucesso";
                projectUserResponse.Success = result;
            }
            catch (Exception e)
            {
                projectUserResponse.Message = e.Message;
                projectUserResponse.Success = false;
            }

            return projectUserResponse;
        }
    }
}
