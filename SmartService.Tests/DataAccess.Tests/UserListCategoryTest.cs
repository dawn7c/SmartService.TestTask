using Microsoft.EntityFrameworkCore;
using Moq;
using SmartService.DataAccess.DatabaseContext;
using SmartService.DataAccess.Repository;
using SmartService.Domain.Models;
using Task = System.Threading.Tasks.Task;

namespace SmartService.Tests.DataAccess.Tests
{
    public class UserListCategoryTest
    {
        [Fact]
        public async Task UserListCategoriesAsync_WithValidTenantID_ReturnsExpectedResult()
        {
            var userTaskListCategoriesData = new List<UserTaskListCategory>
            {
                new UserTaskListCategory { UserID = 1, TaskListCategoryID = 13 },
                new UserTaskListCategory { UserID = 2, TaskListCategoryID = 13 },
                new UserTaskListCategory { UserID = 3, TaskListCategoryID = 14 }
            }.AsQueryable();

            var mockSet = new Mock<DbSet<UserTaskListCategory>>();
            mockSet.As<IQueryable<UserTaskListCategory>>().Setup(m => m.Provider).Returns(userTaskListCategoriesData.Provider);
            mockSet.As<IQueryable<UserTaskListCategory>>().Setup(m => m.Expression).Returns(userTaskListCategoriesData.Expression);
            mockSet.As<IQueryable<UserTaskListCategory>>().Setup(m => m.ElementType).Returns(userTaskListCategoriesData.ElementType);
            mockSet.As<IQueryable<UserTaskListCategory>>().Setup(m => m.GetEnumerator()).Returns(userTaskListCategoriesData.GetEnumerator());
            var mockContext = new Mock<ApplicationContext>();
            mockContext.Setup(c => c.Set<UserTaskListCategory>()).Returns(mockSet.Object); 
            var repository = new UserListCategoryRepository(mockContext.Object);
            short tenantID = 1; 
            var result = await repository.UserListCategoriesAsync(tenantID);
            Assert.Single(result); 
            Assert.Contains(result, r => r.UserID == 1 && r.ListCategoryID == 13);

        }
    }
}
