
namespace DynamicWorkflow.Workflow.Controllers.RequestTransactionController
{
    public class RequestTransactionController : ApiBaseController
    {
        public RequestTransactionController(IMediator mediator) : base(mediator)
        {
        }

        #region Post
        [HttpPost]
        public async Task<ResponseDTO> PostRequestTransaction([FromForm] PostRequestTransactionCommand PostRequestTransactionCommand)
        {
            return await _mediator.Send(PostRequestTransactionCommand);
        }
        #endregion
    }
}
