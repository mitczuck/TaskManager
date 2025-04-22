using TaskManager.Core.Entities;
using TaskManager.Core.Enums;

namespace TaskManager.Core.DTO.Request
{
    public class TaskPostRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime DueDate { get; set; }
        public StatusTask Status { get; set; }
        public Priority Priority { get; set; }
        public int ProjectId { get; set; }
        public int ResponsibleUserId { get; set; }
    }
}