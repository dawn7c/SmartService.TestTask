using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartService.Domain.Models
{
    public class TaskResponsibleUser
    {
        public int TaskID { get; set; }
        public int UserID { get; set; }
    }
}
