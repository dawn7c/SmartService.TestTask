using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartService.Domain.Models
{
    public class RolePermissionExt
    {
        public short TenantID { get; set; }
        public int RoleID { get; set; }
        public short PermissionExtID { get; set; }
        public DateTime? Deleted { get; set; }
    }
}
