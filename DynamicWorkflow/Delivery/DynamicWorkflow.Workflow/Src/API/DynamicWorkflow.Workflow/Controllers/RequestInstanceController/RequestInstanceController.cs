namespace DynamicWorkflow.Workflow.Controllers.RequestInstanceController
{

    public class RequestInstanceController : ApiBaseController
    {
        public RequestInstanceController(IMediator mediator) : base(mediator)
        {
        }

        #region Get
        [HttpGet]
        [Route("{id}")]
        public async Task<ResponseDTO> GetRequestInstanceById(Guid id)
        {
            return await _mediator.Send(new GetRequestInstanceByIdQuery() { Id = id });
        }
        [HttpGet]
        [Route("IsAuthorizeStep/{id}")]
        public async Task<ResponseDTO> IsAuthorizeStep(Guid id)
        {
            return await _mediator.Send(new IsAuthorizeStepQuery() { Id = id });
        }
        [HttpGet]
        [Route("IsAuthorizeStepAssgin/{id}")]
        public async Task<ResponseDTO> IsAuthorizeStepAssgin(Guid id)
        {
            return await _mediator.Send(new IsAuthorizeStepAssginQuery() { Id = id });
        }
        [HttpGet]
        [Route("Count")]
        public async Task<ResponseDTO> Count()
        {
            return await _mediator.Send(new GetRequestInsCountQuery() { });
        }
        [HttpGet]
        [Route("RequestInstancesStatusStatistics")]
        public async Task<ResponseDTO> RequestInstancesStatusStatistics()
        {
            return await _mediator.Send(new RequestInstancesStatusStatisticsQuery() { });
        }
        [HttpGet]
        [Route("RequestInstanceTypeStatistics")]
        public async Task<ResponseDTO> RequestInstanceTypeStatistics()
        {
            return await _mediator.Send(new RequestInstanceTypeStatisticsQuery() { });
        }
        #endregion

        #region Delete
        [HttpDelete]
        [Route("{id}")]
        public async Task<ResponseDTO> DeleteRequestInstance(Guid id)
        {
            return await _mediator.Send(new DeleteRequestInstanceCommand() { Id = id });
        }
        #endregion
        [HttpPost]
        public async Task<ResponseDTO> PostRequestInstance(PostRequestInstanceCommand command) => await _mediator.Send(command);

    }
}
