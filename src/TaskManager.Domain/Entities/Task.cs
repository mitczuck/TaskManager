using System.Reflection.Metadata;
using System.Text.Json.Serialization;
using TaskManager.Core.Enums;

namespace TaskManager.Core.Entities
{
    public class Task
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public StatusTask Status { get; set; }
        public Priority Priority { get; set; }
        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
        public int ResponsibleUserId { get; set; }
        public virtual User ResponsibleUser { get; set; } = null!;
        
        [JsonIgnore]
        public virtual ICollection<TaskHistory> History { get; set; } = new List<TaskHistory>();

        [JsonIgnore]
        public virtual ICollection<TaskUser> TaskUsers { get; set; } = new List<TaskUser>();

    }

    public class TaskUser
    {
        public int TaskId { get; set; }
        public int UserId { get; set; }
        public virtual Task Task { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
