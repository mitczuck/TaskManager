
using TaskManager.Core.Entities;

namespace TaskManager.Infrastructure.Interfaces
{
    public interface ITaskHistoryRepository
    {
        IEnumerable<TaskHistory> GetTaskHistorys();
        TaskHistory GetTaskHistory(int id);
        TaskHistory CreateTaskHistory(TaskHistory taskHistory);
        bool DeleteTaskHistory(int id);
        bool TaskHistoryExists(int id);
    }
}
