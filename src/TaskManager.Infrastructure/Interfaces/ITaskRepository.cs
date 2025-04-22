using TaskManager.Core.DTO.Response;

namespace TaskManager.Infrastructure.Interfaces
{
    public interface ITaskRepository
    {
        IEnumerable<Core.Entities.Task> GetTasks();
        IEnumerable<Core.Entities.Task> GetTasks(int projectId);
        Core.Entities.Task GetTask(int id);
        Core.Entities.Task UpdateTask(Core.Entities.Task task, int updateUserId);
        Core.Entities.Task CreateTask(Core.Entities.Task task, int createUserId);
        ReportResponse GetCompletedTasksPerUserReport(int userId);
        bool DeleteTask(int id);
        bool TaskExists(int id);
    }
}
