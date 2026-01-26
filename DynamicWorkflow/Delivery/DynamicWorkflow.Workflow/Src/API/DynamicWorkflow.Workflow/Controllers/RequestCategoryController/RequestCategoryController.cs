

namespace DynamicWorkflow.Workflow.Controllers.RequestCategoryController
{
    public class RequestCategoryController : ApiBaseController
    {
        public RequestCategoryController(IMediator mediator) : base(mediator)
        {
        }

        #region Post
        [HttpPost]
        public async Task<ResponseDTO> PostRequestCategory(PostRequestCategoryCommand PostRequestCategoryCommand)
        {
            return await _mediator.Send(PostRequestCategoryCommand);
        }
        #endregion

        #region Get
        [HttpGet]
        public async Task<ResponseDTO> GetAllRequestCategories()
        {
            return await _mediator.Send(new GetAllRequestCategoriesQuery());
        }
        #endregion

        #region Delete
        [HttpDelete]
        [Route("{id}")]
        public async Task<ResponseDTO> DeleteRequestCategory(Guid id)
        {
            return await _mediator.Send(new DeleteRequestCategoryCommand() { Id = id });
        }
        #endregion

        #region Put
        [HttpPut]
        [Route("{id}")]
        public async Task<ResponseDTO> PutRequestCategory(Guid id, PutRequestCategoryDTO PutRequestCategoryDTO)
        {
            return await _mediator.Send(new PutRequestCategoryCommand() { Id = id, RequestCategoryDTO = PutRequestCategoryDTO });
        }
        #endregion
    }
}
