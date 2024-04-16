using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartService.Domain.Models
{
    public class Employment
    {
        public int UserID { get; set; }
        public short CompanyID { get; set; }
        public byte TaskListCategoryID { get; set; }
    }
}
