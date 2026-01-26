
namespace DynamicWorkflow.Workflow.Controllers.AssginRequestTransactionController
{
    public class AssginRequestTransactionController : ApiBaseController
    {
        public AssginRequestTransactionController(IMediator mediator) : base(mediator)
        {
        }
        #region GET

        [HttpGet]
        public async Task<ResponseDTO> Get(Guid AssginRequestId)
        {
            return await _mediator.Send(new GetByAssginRequestIdQuery { Id = AssginRequestId });
        }
        #endregion


        #region Post
        [HttpPost]
        public async Task<ResponseDTO> PostRequestTransaction([FromForm] PostAssginRequestTransactionsCommand PostRequestTransactionCommand)
        {
            return await _mediator.Send(PostRequestTransactionCommand);
        }
        #endregion

        #region PUT
        [HttpPut]
        public async Task<ResponseDTO> PutRequestTransaction([FromForm] PutAssginRequestTransactionsCommand PutRequestTransactionCommand)
        {
            return await _mediator.Send(PutRequestTransactionCommand);
        }
        #endregion
    }
}
