using Microsoft.EntityFrameworkCore;
using SmartService.DataAccess.DatabaseContext;
using SmartService.Domain.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartService.DataAccess.Repositories
{
    public class TaskUserCacheRepository : ITaskUserCacheRepository
    {
        private readonly ApplicationContext _context;

        public TaskUserCacheRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<List<object>> AggregateTaskUserCacheAsync(short tenantID)
        {
            var taskUserCaches = await _context.TaskUserCaches.ToListAsync();
            var aggregatedTaskUserCache = taskUserCaches
                .Concat(taskUserCaches)
                .GroupBy(tuc => new { tuc.TaskID, tuc.UserID })
                .Select(group => new
                {
                    TaskID = group.Key.TaskID,
                    UserID = group.Key.UserID,
                    TaskListCategoryID = group.Max(tuc => tuc.TaskListCategoryID)
                })
                .ToList<object>();

            return await Task.FromResult(aggregatedTaskUserCache);

        }
    }
}
    
