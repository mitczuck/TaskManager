using TaskManager.Core.Entities;

namespace TaskManager.Core.DTO.Response
{
    public class ProjectUserResponse
    {
        public ProjectUser ProjectUser { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
