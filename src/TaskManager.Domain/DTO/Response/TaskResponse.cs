namespace TaskManager.Core.DTO.Response
{
    public class TaskResponse
    {
        public Entities.Task Task { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
