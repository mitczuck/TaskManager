using TaskManager.Core.DTO.Request;
using TaskManager.Core.DTO.Response;
using TaskManager.Core.Entities;

namespace TaskManager.Application.Interfaces
{ 
    public interface IReportService
    {
        ReportResponse GetCompletedTasksPerUserReport(int UserId);
    }
}
