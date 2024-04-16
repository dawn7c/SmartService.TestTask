using Microsoft.EntityFrameworkCore;
using SmartService.DataAccess.DatabaseContext;
using SmartService.Domain.Abstractions;
using SmartService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartService.DataAccess.Repository
{
    public class UserListCategoryRepository : IUserListCategoryRepository
    {
        private readonly ApplicationContext _context;
       // private readonly DbSet<UserRole> _dbSet;

        public UserListCategoryRepository(ApplicationContext context)
        {
            _context = context;
           // _dbSet = _context.Set<UserRole>();
        }

        

        public async Task<IEnumerable<(int UserID, byte ListCategoryID)>> UserListCategoriesAsync(short tenantID)
        {
            var districtAvailable = 13; 

            var userTaskListCategories = await _context.UserTaskListCategories
                .Where(utc => utc.TaskListCategoryID == districtAvailable && utc.UserID == tenantID)
                .Select(utc => new { UserID = utc.UserID, ListCategoryID = utc.TaskListCategoryID })
                .ToListAsync();

            return userTaskListCategories.Select(utc => (utc.UserID, utc.ListCategoryID));
        }
    }
}
