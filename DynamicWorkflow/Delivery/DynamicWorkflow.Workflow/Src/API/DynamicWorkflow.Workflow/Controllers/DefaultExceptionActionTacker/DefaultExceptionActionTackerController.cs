


namespace DynamicWorkflow.Workflow.Controllers.DefaultExceptionActionTacker
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultExceptionActionTackerController : ApiBaseController
    {
        public DefaultExceptionActionTackerController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<ResponseDTO> PostDefaultExceptionActionTacker(List<Guid> ActionTakerId)
        {
            return await _mediator.Send(new PostDefaultExceptionActionTackerCommand
            {
                ActionTakerId = ActionTakerId,
            });
        }

        [HttpDelete]
        public async Task<ResponseDTO> DeleteDefaultExceptionActionTacker(List<Guid> ActionTakerId)
        {
            return await _mediator.Send(new DeleteDefaultExceptionActionTackerCommand
            {
                ActionTakerId = ActionTakerId,
            });
        }
    }
}
