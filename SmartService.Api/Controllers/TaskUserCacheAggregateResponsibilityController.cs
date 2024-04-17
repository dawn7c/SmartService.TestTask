using Microsoft.AspNetCore.Mvc;
using SmartService.Domain.Abstractions;
using System.ComponentModel.DataAnnotations;

namespace SmartService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskUserCacheAggregateResponsibilityController : ControllerBase
    {
        private readonly ITaskUserCacheAggregateResponsibilityRepository _taskUserCacheAggregateResponsibilityRepository;
        private readonly Application.Validation.Validator _validator;

        public TaskUserCacheAggregateResponsibilityController(ITaskUserCacheAggregateResponsibilityRepository taskUserCacheAggregateResponsibilityRepository)
        {
            _taskUserCacheAggregateResponsibilityRepository = taskUserCacheAggregateResponsibilityRepository;
            _validator = new Application.Validation.Validator();
        }

        [HttpPost("{tenantID}")]
        public async Task<IActionResult> AggregateTaskUserCacheResponsibility(short tenantID)
        {
            _validator.CheckForNull(tenantID);  
            await _taskUserCacheAggregateResponsibilityRepository.AggregateTaskUserCacheResponsibilityAsync(tenantID);
            return Ok();
        }
    }
}
