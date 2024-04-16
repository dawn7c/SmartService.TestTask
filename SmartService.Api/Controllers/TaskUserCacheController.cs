using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartService.Domain.Abstractions;

namespace SmartService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskUserCacheController : ControllerBase
    {
        private readonly ITaskUserCacheRepository _taskUserCacheRepository;

        public TaskUserCacheController(ITaskUserCacheRepository taskUserCacheRepository)
        {
            _taskUserCacheRepository = taskUserCacheRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetTaskUserCaches([FromQuery] short tenantID)
        {
            var taskUserCaches = await _taskUserCacheRepository.AggregateTaskUserCacheAsync(tenantID);
            return Ok(taskUserCaches);
        }
    }
}
