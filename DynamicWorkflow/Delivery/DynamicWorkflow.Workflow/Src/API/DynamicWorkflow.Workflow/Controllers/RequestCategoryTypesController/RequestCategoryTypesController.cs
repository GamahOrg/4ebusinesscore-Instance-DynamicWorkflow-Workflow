

namespace DynamicWorkflow.Workflow.Controllers.RequestCategoryTypesController
{
    public class RequestCategoryTypesController : ApiBaseController
    {
        public RequestCategoryTypesController(IMediator mediator) : base(mediator)
        {
        }


        #region Post
        [HttpPost("PostRequestCategoryType")]
        public async Task<ResponseDTO> PostRequestCategoryTypes(PostRequestCategoryTypeCommand PostRequestCategoryCommand)
        {
            return await _mediator.Send(PostRequestCategoryCommand);
        }
        #endregion

        #region Delete
        [HttpDelete]
        [Route("DeleteRequestCategoryType/{id}")]
        public async Task<ResponseDTO> DeleteRequestCategoryTypes(Guid id)
        {
            return await _mediator.Send(new DeleteRequestCategoryTypeCommand() { Id = id });
        }
        #endregion

        #region Put
        [HttpPut]
        [Route("PutRequestCategoryType/{id}")]
        public async Task<ResponseDTO> PutRequestCategoryTypes(Guid id, PutRequestCategoryTypeDTO PutRequestCategoryTypeDTO)
        {
            return await _mediator.Send(new PutRequestCategoryTypeCommand() { Id = id, RequestCategoryTypeDTO = PutRequestCategoryTypeDTO });
        }
        #endregion

        #region Get
        [HttpGet]
        public async Task<ResponseDTO> GetAllRequestCategoriesType()
        {
            return await _mediator.Send(new GetAllRequestCategoriesTypesQuery());
        }

        [HttpGet, Route("GetRequestTypesByCategoryId/{categoryId}")]
        public async Task<ResponseDTO> GetRequestTypesByCategoryId(Guid categoryId) => await _mediator.Send(new GetRequestTypesByCategoryIdQuery(categoryId));

        #endregion
    }
}
