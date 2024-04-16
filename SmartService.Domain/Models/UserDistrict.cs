using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartService.Domain.Models
{
    public class UserDistrict
    {
        public short TenantID { get; set; }
        public int UserID { get; set; }
        public byte DistrictID { get; set; }
        public DateTime? Deleted { get; set; }
    }
}
