using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartService.Domain.Abstractions
{
    public interface ITaskUserCacheAggregateResponsibilityRepository
    {
        Task AggregateTaskUserCacheResponsibilityAsync(short tenantID);
    }
}
