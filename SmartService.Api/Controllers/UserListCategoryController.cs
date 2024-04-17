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
        private readonly Application.Validation.Validator _validator;

        public UserListCategoryController(IUserListCategoryRepository userListCategoryRepository)
        {
            _userListCategoryRepository = userListCategoryRepository;
            _validator = new Application.Validation.Validator();
        }

        [HttpGet]
        public async Task<IActionResult> GetUserListCategories(short tenantID)
        {
            _validator.CheckForNull(tenantID);
            var userListCategories = await _userListCategoryRepository.UserListCategoriesAsync(tenantID);
            return Ok(userListCategories);
        }
    }
}
