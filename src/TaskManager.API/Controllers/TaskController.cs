using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Interfaces;
using TaskManager.Core.DTO.Request;
using TaskManager.Core.DTO.Response;
using TaskManager.Core.Entities;

namespace TaskManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ITaskService _taskService;

        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        [HttpPost]
        public TaskResponse PostTask(TaskPostRequest taskPostRequest, int createUserId)
        {
            return _taskService.CreateTask(taskPostRequest, createUserId);
        }

        [HttpDelete("{id}")]
        public TaskResponse DeleteTask(int id)
        {
            return _taskService.DeleteTask(id);
        }

        [HttpPut]
        public TaskResponse PutTask(TaskPutRequest taskPutRequest, int updateUserId)
        {
            return _taskService.UpdateTask(taskPutRequest, updateUserId);
        }

        [HttpGet]
        public IEnumerable<Core.Entities.Task> GetTasks()
        {
            return _taskService.GetTasks();
        }

        [HttpGet("GetTasksByProjectId")]
        public IEnumerable<Core.Entities.Task> GetTasksByProjectId(int projectId)
        {
            return _taskService.GetTasks(projectId);
        }

        [HttpPost("PostTaskHistory")]
        public TaskResponse PostTaskHistory(TaskHistory taskHistory, int createUserId)
        {
            return _taskService.CreateTaskHistory(taskHistory, createUserId);
        }

        [HttpGet("{id}")]
        public Core.Entities.Task GetTask(int id)
        {
            return _taskService.GetTask(id);
        }

    }
}
