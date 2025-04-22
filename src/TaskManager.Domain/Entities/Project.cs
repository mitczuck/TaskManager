using System.Text.Json.Serialization;

namespace TaskManager.Core.Entities
{
    public class Project
    {
        public int Id { get; set; }
        public string ProjectName { get; set; }
        public int TaskLimit { get; set; } = 20;

        [JsonIgnore]
        public virtual ICollection<Task> Tasks { get; set; } = new List<Task>();        
        public virtual ICollection<ProjectUser> ProjectUsers { get; set; } = new List<ProjectUser>();
    }

    public class ProjectUser
    {
        public int ProjectId { get; set; }
        public int UserId { get; set; }

        [JsonIgnore]
        public virtual Project Project { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}