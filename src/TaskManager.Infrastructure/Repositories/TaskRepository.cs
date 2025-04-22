using Microsoft.EntityFrameworkCore;
using TaskManager.Infrastructure.Context;
using TaskManager.Core.Entities;
using TaskManager.Infrastructure.Interfaces;
using System.Reflection;
using System.Threading.Tasks;
using System.Text;

namespace TaskManager.Infrastructure.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly SqlDbContext _context;

        public TaskRepository(SqlDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Core.Entities.Task> GetTasks()
        {
            return _context.Tasks.ToList();
        }

        public IEnumerable<Core.Entities.Task> GetTasks(int projectId)
        {
            return _context.Tasks.Where(t => t.ProjectId == projectId).ToList();
        }

        public Core.Entities.Task GetTask(int id)
        {
            var task = _context.Tasks.Find(id);

            if (task == null)
            {
                return new Core.Entities.Task();
            }

            return task;
        }
        public Core.Entities.Task CreateTask(Core.Entities.Task task, int createUserId)
        {
            if (createUserId <= 0)
                throw new ArgumentException("CreateUserId é obrigatório.");            

            try
            {
                _context.Tasks.Add(task);
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (TaskExists(task.Id))
                {
                    return GetTask(task.Id);
                }
                else
                {
                    throw new ArgumentException("Tarefa não encontrada.");
                }
            }

            _context.TaskHistories.Add(new TaskHistory
            {
                Message = "Tarefa criada",
                TaskId = task.Id,
                UserId = createUserId
            });
            _context.SaveChanges();

            return GetTask(task.Id);
        }
        public Core.Entities.Task UpdateTask(Core.Entities.Task task, int updateUserId)
        {
            if(updateUserId <= 0)
                throw new ArgumentException("UpdateUserId é obrigatório.");

            _context.Entry(task).State = EntityState.Modified;

            var sBuilder = new StringBuilder();

            foreach (var entry in _context.ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Modified)
                {
                    var changes = new StringBuilder();
                    foreach (var property in entry.Properties)
                    {
                        if (!property.OriginalValue.Equals(property.CurrentValue))
                        {
                            changes.AppendLine($"{property.Metadata.Name}: " +
                                             $"{property.OriginalValue} -> {property.CurrentValue}");
                        }
                    }
                    sBuilder.AppendLine($":\n{changes}");
                }
            }

            try
            {
                _context.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (TaskExists(task.Id))
                {
                    return GetTask(task.Id);
                }
                else
                {
                    throw new ArgumentException("Tarefa não encontrada.");
                }
            }

            _context.TaskHistories.Add(new TaskHistory
            {
                Message = "Tarefa alterada : " + sBuilder.ToString(),
                TaskId = task.Id,
                UserId = updateUserId
            });
            _context.SaveChanges();

            return GetTask(task.Id);
        }

        public bool DeleteTask(int id)
        {
            var Task = _context.Tasks.Find(id);
            if (Task == null)
            {
                return false;
            }

            _context.Tasks.Remove(Task);
            _context.SaveChanges();

            return true;
        }

        public bool TaskExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}
