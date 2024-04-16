using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SmartService.Domain.Abstractions;


namespace SmartService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskUserCacheAggregateResponsibilityController : ControllerBase
    {
        private readonly ITaskUserCacheAggregateResponsibilityRepository _taskUserCacheAggregateResponsibilityRepository;
        

        public TaskUserCacheAggregateResponsibilityController(ITaskUserCacheAggregateResponsibilityRepository taskUserCacheAggregateResponsibilityRepository)
        {
            _taskUserCacheAggregateResponsibilityRepository = taskUserCacheAggregateResponsibilityRepository;
            
        }

        [HttpPost("{tenantID}")]
        public async Task<IActionResult> AggregateTaskUserCacheResponsibility(short tenantID)
        {
            await _taskUserCacheAggregateResponsibilityRepository.AggregateTaskUserCacheResponsibilityAsync(tenantID);
            return Ok();
        }
    }
}
