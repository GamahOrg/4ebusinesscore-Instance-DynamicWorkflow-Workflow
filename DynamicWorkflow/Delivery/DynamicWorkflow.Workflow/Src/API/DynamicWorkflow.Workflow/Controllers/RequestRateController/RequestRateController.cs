
namespace DynamicWorkflow.Workflow.Controllers.RequestRateController
{
    public class RequestRateController : ApiBaseController
    {
        public RequestRateController(IMediator mediator) : base(mediator)
        {
        }

        #region Post
        [HttpPost]
        public async Task<ResponseDTO> PostRequestCategory(PostRateCommand PostRequestRateCommand)
        {
            return await _mediator.Send(PostRequestRateCommand);
        }
        #endregion

        //#region Put
        //[HttpPut]
        //[Route("{RequestId}")]
        //public async Task<ResponseDTO> PutRequestCategory(Guid RequestId, PutRateDTO PutRateDTO)
        //{
        //    return await _mediator.Send(new PutRateCommand() { RequestId =RequestId  , RequestRateDTO = PutRateDTO });
        //}
        //#endregion
    }
}
