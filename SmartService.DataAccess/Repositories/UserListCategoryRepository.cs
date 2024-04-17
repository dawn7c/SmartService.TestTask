using Microsoft.EntityFrameworkCore;
using SmartService.DataAccess.DatabaseContext;
using SmartService.Domain.Abstractions;

namespace SmartService.DataAccess.Repository
{
    public class UserListCategoryRepository : IUserListCategoryRepository
    {
        private readonly ApplicationContext _context;
       
        public UserListCategoryRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<(int UserID, byte ListCategoryID)>> UserListCategoriesAsync(short tenantID)
        {
            try
            {
                var districtAvailable = 13;

                Console.WriteLine($"_context: {_context}");
                Console.WriteLine($"_context.UserTaskListCategories: {_context.UserTaskListCategories}");

                var userTaskListCategories = await _context.UserTaskListCategories
                    .Where(utc => utc.TaskListCategoryID == districtAvailable && utc.UserID == tenantID)
                    .Select(utc => new { UserID = utc.UserID, ListCategoryID = utc.TaskListCategoryID })
                    .ToListAsync();

                return userTaskListCategories.Select(utc => (utc.UserID, utc.ListCategoryID));
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception occurred: {ex}");
                throw; // Распространяем исключение для отображения в тесте
            }
        }
    }
}
