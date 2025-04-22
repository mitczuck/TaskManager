using Microsoft.EntityFrameworkCore;
using TaskManager.Infrastructure.Context;
using TaskManager.Core.Entities;
using TaskManager.Infrastructure.Interfaces;

namespace TaskManager.Infrastructure.Repositories
{
    public class TaskUserRepository : ITaskUserRepository
    {
        private readonly SqlDbContext _context;

        public TaskUserRepository(SqlDbContext context)
        {
            _context = context;
        }

        public IEnumerable<TaskUser> GetTaskUsers()
        {
            return _context.TaskUsers.ToList();
        }

        public IEnumerable<TaskUser> GetTaskUsers(int taskId)
        {
            return _context.TaskUsers.Where(pu => pu.TaskId == taskId).ToList();
        }

        public TaskUser GetTaskUser(int taskId, int userId)
        {
            var Task = _context.TaskUsers.Find(taskId, userId);

            if (Task == null)
            {
                return new TaskUser();
            }

            return Task;
        }

        public TaskUser CreateTaskUser(TaskUser taskUser)
        {
            _context.TaskUsers.Add(taskUser);
            _context.SaveChanges();

            return GetTaskUser(taskUser.TaskId, taskUser.UserId);
        }

        public bool DeleteTaskUser(int taskId, int userId)
        {
            var taskUser = _context.TaskUsers.Find(taskId, userId);
            if (taskUser == null)
            {
                return false;
            }

            _context.TaskUsers.Remove(taskUser);
            _context.SaveChanges();

            return true;
        }

        public bool TaskUserExists(int taskId, int userId)
        {
            return _context.TaskUsers.Any(e => e.TaskId == taskId && e.UserId == userId);
        }
    }
}
