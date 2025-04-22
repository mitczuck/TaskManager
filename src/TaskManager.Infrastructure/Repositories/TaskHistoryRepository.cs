using TaskManager.Infrastructure.Context;
using TaskManager.Core.Entities;
using TaskManager.Infrastructure.Interfaces;

namespace TaskManager.Infrastructure.Repositories
{
    public class TaskHistoryRepository : ITaskHistoryRepository
    {
        private readonly SqlDbContext _context;

        public TaskHistoryRepository(SqlDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TaskHistory> GetTaskHistorys()
        {
            return _context.TaskHistories.ToList();
        }

        public TaskHistory GetTaskHistory(int id)
        {
            var TaskHistory = _context.TaskHistories.Find(id);

            if (TaskHistory == null)
            {
                return new TaskHistory();
            }

            return TaskHistory;
        }

        public TaskHistory CreateTaskHistory(TaskHistory taskHistory)
        {
            _context.TaskHistories.Add(taskHistory);
            _context.SaveChanges();

            return GetTaskHistory(taskHistory.Id);
        }

        public bool DeleteTaskHistory(int id)
        {
            var TaskHistory = _context.TaskHistories.Find(id);
            if (TaskHistory == null)
            {
                return false;
            }

            _context.TaskHistories.Remove(TaskHistory);
            _context.SaveChanges();

            return true;
        }

        public bool TaskHistoryExists(int id)
        {
            return _context.TaskHistories.Any(e => e.Id == id);
        }
    }
}
