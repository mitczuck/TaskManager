
using TaskManager.Core.Entities;

namespace TaskManager.Infrastructure.Interfaces
{
    public interface IProjectUserRepository
    {
        IEnumerable<ProjectUser> GetProjectUsers();
        IEnumerable<ProjectUser> GetProjectUsers(int projectId);
        ProjectUser GetProjectUser(int projectId, int userId);
        ProjectUser CreateProjectUser(ProjectUser projectUser);
        bool DeleteProjectUser(int projectId, int userId);
        bool ProjectUserExists(int projectId, int userId);
    }
}
