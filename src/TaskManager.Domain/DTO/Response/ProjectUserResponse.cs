using TaskManager.Core.Entities;

namespace TaskManager.Core.DTO.Response
{
    public class ProjectResponse
    {
        public Project Project { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
