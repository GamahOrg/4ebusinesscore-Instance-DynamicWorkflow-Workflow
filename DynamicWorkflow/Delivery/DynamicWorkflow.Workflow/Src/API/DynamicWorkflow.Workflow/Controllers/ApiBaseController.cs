
namespace DynamicWorkflow.Workflow.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize("ResourceOwnerPolicy")]
    public class ApiBaseController : ControllerBase
    {
        protected IMediator _mediator;
        public ApiBaseController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
