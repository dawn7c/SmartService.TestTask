using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartService.Domain.Models
{
    public class TaskUserCacheResult
    {
        public int TaskID { get; set; }
        public int UserID { get; set; }
        public byte TaskListCategoryID { get; set; }
    }
}
