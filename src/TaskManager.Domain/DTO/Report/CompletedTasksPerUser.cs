using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManager.Core.DTO.Report
{
    public class CompletedTasksPerUser
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public int CountCompletedTasks { get; set; }
    }
}
