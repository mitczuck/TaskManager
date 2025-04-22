using TaskManager.Application.Interfaces;
using TaskManager.Core.DTO.Response;
using TaskManager.Infrastructure.Interfaces;

namespace TaskManager.Application.Implementations
{
    public class ReportService : IReportService
    {
        private readonly ITaskRepository _taskRepository;

        public ReportService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public ReportResponse GetCompletedTasksPerUserReport(int UserId)
        {
            ReportResponse reportResponse = new ReportResponse();

            try
            {
                reportResponse = _taskRepository.GetCompletedTasksPerUserReport(UserId);
            }
            catch (Exception e)
            {
                reportResponse.Message = e.Message;
            }

            return reportResponse;
        }
    }
}
