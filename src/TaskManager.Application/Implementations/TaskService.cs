using System.Threading.Tasks;
using Microsoft.VisualBasic;
using TaskManager.Application.Interfaces;
using TaskManager.Core.DTO.Request;
using TaskManager.Core.DTO.Response;
using TaskManager.Core.Entities;
using TaskManager.Core.Enums;
using TaskManager.Infrastructure.Interfaces;

namespace TaskManager.Application.Implementations
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;
        private readonly ITaskHistoryRepository _taskHistoryRepository;

        public TaskService(ITaskRepository taskRepository, ITaskHistoryRepository taskHistoryRepository)
        {
            _taskRepository = taskRepository;
            _taskHistoryRepository = taskHistoryRepository;
        }

        public TaskResponse CreateTask(TaskPostRequest taskPostRequest, int createUserId) 
        {
            TaskResponse taskResponse = new TaskResponse();

            try
            {
                Core.Entities.Task task = _taskRepository.CreateTask(new Core.Entities.Task()
                {
                    Title = taskPostRequest.Title,
                    Description = taskPostRequest.Description,
                    DueDate = taskPostRequest.DueDate,
                    Status = taskPostRequest.Status,
                    Priority = taskPostRequest.Priority,
                    ProjectId = taskPostRequest.ProjectId,
                    ResponsibleUserId = taskPostRequest.ResponsibleUserId
                }, createUserId);

                taskResponse.Task = task;
                taskResponse.Message = "Tarefa criada com sucesso";
                taskResponse.Success = true;
            }
            catch (Exception e)
            {
                taskResponse.Message = e.Message;
                taskResponse.Success = false;
            }

            return taskResponse;
        }

        public TaskResponse DeleteTask(int id)
        {
            TaskResponse taskResponse = new TaskResponse();
            try
            {
                bool result = _taskRepository.DeleteTask(id);
          
                taskResponse.Message = "Tarefa deletada com sucesso";
                taskResponse.Success = result;
            }
            catch (Exception e)
            {
                taskResponse.Message = e.Message;
                taskResponse.Success = false;
            }

            return taskResponse;
        }

        public TaskResponse UpdateTask(TaskPutRequest taskPutRequest, int updateUserId)
        {
            Core.Entities.Task task = _taskRepository.GetTask(taskPutRequest.Id);

            if(task.Title != taskPutRequest.Title)
                task.Title = taskPutRequest.Title;

            if (task.Description != taskPutRequest.Description)
                task.Description = taskPutRequest.Description;

            if (task.DueDate != taskPutRequest.DueDate)
                task.DueDate = taskPutRequest.DueDate;

            if (task.Status != taskPutRequest.Status)
                task.Status = taskPutRequest.Status;

            if (task.ResponsibleUserId != taskPutRequest.ResponsibleUserId)
                task.ResponsibleUserId = taskPutRequest.ResponsibleUserId;

            TaskResponse taskResponse = new TaskResponse();

            try
            {
                task = _taskRepository.UpdateTask(task, updateUserId);

                taskResponse.Task = task;
                taskResponse.Message = "Tarefa atualizada com sucesso";
                taskResponse.Success = true;

            } catch (Exception e)
            {
                taskResponse.Message = e.Message;
                taskResponse.Success = false;
            }

            return taskResponse;
        }

        public TaskResponse CreateTaskHistory(TaskHistory taskHistory, int createUserId)
        {
            TaskResponse taskResponse = new TaskResponse();

            try
            {
                _taskHistoryRepository.CreateTaskHistory(new TaskHistory()
                {
                    Message = taskHistory.Message,
                    TaskId = taskHistory.TaskId,
                    UserId = createUserId
                });

                taskResponse.Message = "Histórico da tarefa criado com sucesso";
                taskResponse.Success = true;
            }
            catch (Exception e)
            {
                taskResponse.Message = e.Message;
                taskResponse.Success = false;
            }

            return taskResponse;
        }

        public IEnumerable<Core.Entities.Task> GetTasks()
        {
            return _taskRepository.GetTasks();
        }

        public IEnumerable<Core.Entities.Task> GetTasks(int projectId)
        {
            return _taskRepository.GetTasks(projectId);
        }

        public Core.Entities.Task GetTask(int id)
        {
           return _taskRepository.GetTask(id);
        }
    }
}
