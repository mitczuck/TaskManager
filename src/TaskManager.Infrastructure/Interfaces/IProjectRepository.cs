
using TaskManager.Core.Entities;

namespace TaskManager.Infrastructure.Interfaces
{
    public interface IProjectRepository
    {
        IEnumerable<Project> GetProjects();
        IEnumerable<Project> GetProjects(int userId);
        Project GetProject(int id);
        Project UpdateProject(Project Project);
        Project CreateProject(Project Project);
        bool DeleteProject(int id);
        bool ProjectExists(int id);
    }
}
