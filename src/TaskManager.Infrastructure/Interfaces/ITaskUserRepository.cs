using Microsoft.EntityFrameworkCore;
using TaskManager.Core.Entities;

namespace TaskManager.Infrastructure.Interfaces
{
    public interface ITaskUserRepository
    {
        IEnumerable<TaskUser> GetTaskUsers();
        IEnumerable<TaskUser> GetTaskUsers(int taskId);
        TaskUser GetTaskUser(int taskId, int userId);
        TaskUser CreateTaskUser(TaskUser taskUser);
        bool DeleteTaskUser(int taskId, int userId);
        bool TaskUserExists(int taskId, int userId);
    }
}
