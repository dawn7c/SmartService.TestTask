using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartService.Domain.Models
{
    public class TaskOnlineAssigned
    {
        public short TenantID { get; set; }
        public int TaskID { get; set; }
        public int AssignedTo { get; set; }
    }
}
