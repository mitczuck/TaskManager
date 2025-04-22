using TaskManager.Core.DTO.Report;

namespace TaskManager.Core.DTO.Response
{
    public class ReportResponse
    {
        public string Message { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<CompletedTasksPerUser> UserStats { get; set; }
    }
}
