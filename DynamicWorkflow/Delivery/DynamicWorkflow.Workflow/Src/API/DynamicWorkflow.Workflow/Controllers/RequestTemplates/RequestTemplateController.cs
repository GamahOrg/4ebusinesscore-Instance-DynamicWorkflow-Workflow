


namespace DynamicWorkflow.Workflow.Controllers.RequestTemplates
{

    public class RequestTemplateController : ApiBaseController
    {
        public RequestTemplateController(IMediator mediator) : base(mediator)
        {
        }

        [HttpGet]
        public async Task<ResponseDTO> GetAllRequestTemplate(int pageNumber, int pageSize)
        {
            return await _mediator.Send(new GetAllRequestTemplateQuery(new PaginationModel(pageNumber, pageSize)));
        }
        [HttpGet("GetAllRequestTemplateBycategoryId/{categoryId}")]
        public async Task<ResponseDTO> GetAllRequestTemplateBycategoryId(Guid categoryId, string? search, int pageNumber, int pageSize)
        {
            return await _mediator.Send(new GetAllRequestTemplateBycategoryIdeQuery(new PaginationModel(pageNumber, pageSize), categoryId, search));
        }

        [HttpGet, Route("GetChildRequestTemplatesByParentId/{parentId}")]
        public async Task<ResponseDTO> GetChildsByParentRequestTemplateId(Guid parentId) => await _mediator.Send(new GetChildsByParentIdQuery(parentId));

        [HttpGet, Route("GetParentRequestTemplatesByCategoryId/{categoryId}")]
        public async Task<ResponseDTO> GetParentRequestTemplatesByCategoryId(Guid categoryId) => await _mediator.Send(new GetParentsByCategoryIdQuery(categoryId));

        [HttpGet, Route("GetRequestTemplatesByRequestTypeId/{categoryTypeId}")]
        public async Task<ResponseDTO> GetRequestTemplatesByRequestTypeId(Guid categoryTypeId) => await _mediator.Send(new GetRequestTemplatesByRequestTypeIdQuery(categoryTypeId));

        [HttpPost]
        public async Task<ResponseDTO> PostRequestTemplate(PostRequestTemplateCommand command) => await _mediator.Send(command);

        [HttpPut("{id}")]
        public async Task<ResponseDTO> PutRequestTemplate(Guid id, [FromBody] PutRequestTemplateCommand command)
        {
            command.Id = id;
            return await _mediator.Send(command);
        }
        [HttpDelete("{id}")]
        public async Task<ResponseDTO> DelteRequestTemplate(Guid id) => await _mediator.Send(new DeleteRequestTemplateCommand(id));

    }
}
