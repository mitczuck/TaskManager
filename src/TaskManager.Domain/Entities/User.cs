using System.Text.Json.Serialization;
using TaskManager.Core.Enums;

namespace TaskManager.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public Position Position { get; set; }

        [JsonIgnore]
        public virtual ICollection<ProjectUser> ProjectUsers { get; set; } = new List<ProjectUser>();
        
        [JsonIgnore]
        public virtual ICollection<TaskUser> TaskUsers { get; set; } = new List<TaskUser>();
        
        [JsonIgnore]
        public virtual Task Task { get; set; } = null!;
        
        [JsonIgnore]
        public virtual TaskHistory TaskHistory { get; set; } = null!;
    }
}
