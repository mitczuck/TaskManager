namespace TaskManager.Core.Entities
{
    public class TaskHistory
    {   
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime Created { get; set; } = DateTime.Now;
        public int TaskId { get; set; }
        public virtual Task Task { get; set; } = null!;
        public int UserId { get; set; }
        public virtual User HistoryUser { get; set; } = null!;
    }
}
