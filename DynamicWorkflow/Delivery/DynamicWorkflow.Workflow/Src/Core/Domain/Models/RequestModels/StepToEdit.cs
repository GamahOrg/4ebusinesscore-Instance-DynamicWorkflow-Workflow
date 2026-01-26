namespace _4EPlatform.Domain.Models.RequestModels
{
    public class StepToEdit : BaseEntity
    {
        public RequestTemplateStep Step { get; set; }
        public Guid StepId { get; set; }
        public RequestInstance RequestInstance { get; set; }
        public Guid RequestInstanceId { get; set; }
    }
}
