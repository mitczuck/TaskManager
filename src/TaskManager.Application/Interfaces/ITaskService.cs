using TaskManager.Core.DTO.Request;
using TaskManager.Core.DTO.Response;
using TaskManager.Core.Entities;

namespace TaskManager.Application.Interfaces
{ 
    public interface ITaskService
    {
        TaskResponse CreateTask(TaskPostRequest taskPostRequest, int createUserId);
        TaskResponse DeleteTask(int id);
        TaskResponse UpdateTask(TaskPutRequest taskPutRequest, int updateUserId);
        TaskResponse CreateTaskHistory(TaskHistory taskHistory, int createUserId);
        IEnumerable<Core.Entities.Task> GetTasks();
        IEnumerable<Core.Entities.Task> GetTasks(int projectId);
        Core.Entities.Task GetTask(int id);
    }
}
