using Microsoft.EntityFrameworkCore;
using SmartService.DataAccess.DatabaseContext;
using SmartService.Domain.Abstractions;


namespace SmartService.DataAccess.Repositories
{
    public class TaskUserCacheAggregateResponsibilityRepository : ITaskUserCacheAggregateResponsibilityRepository
    {
        private readonly ApplicationContext _context;

        public TaskUserCacheAggregateResponsibilityRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AggregateTaskUserCacheResponsibilityAsync(short tenantID)
        {
            var taskResponsibleUsers = await _context.TaskResponsibleUsers.ToListAsync();
            var aggregatedResponsibleUsers = taskResponsibleUsers
                .GroupBy(tru => tru.UserID)
                .Select(group => new
                {
                    UserID = group.Key
                })
                .ToList();
        }
    }
}
