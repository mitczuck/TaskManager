using Microsoft.AspNetCore.Mvc;
using TaskManager.Application.Interfaces;
using TaskManager.Core.DTO.Response;

namespace TaskManager.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _reportRepository;

        public ReportController(IReportService reportRepository)
        {
            _reportRepository = reportRepository;
        }

        [HttpGet("GetCompletedTasksPerUserReport")]
        public ReportResponse GetCompletedTasksPerUserReport(int userId)
        {
            return _reportRepository.GetCompletedTasksPerUserReport(userId);
        }

    }
}
