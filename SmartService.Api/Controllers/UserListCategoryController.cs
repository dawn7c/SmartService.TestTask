using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartService.Domain.Abstractions;

namespace SmartService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserListCategoryController : ControllerBase
    {
        private readonly IUserListCategoryRepository _userListCategoryRepository;

        public UserListCategoryController(IUserListCategoryRepository userListCategoryRepository)
        {
            _userListCategoryRepository = userListCategoryRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetUserListCategories(short tenantID)
        {
            
            var userListCategories = await _userListCategoryRepository.UserListCategoriesAsync(tenantID);
            return Ok(userListCategories);
        }
    }
}
