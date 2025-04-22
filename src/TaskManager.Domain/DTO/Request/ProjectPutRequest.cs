namespace TaskManager.Core.DTO.Request
{
    public class ProjectPutRequest
    {
        public int Id { get; set; }
        public string ProjectName { get; set; } = string.Empty;
    }
}