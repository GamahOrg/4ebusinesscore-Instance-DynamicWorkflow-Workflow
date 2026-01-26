namespace _4EPlatform.Domain.Models.RequestTemplateStepsModels
{
    public class ExceptionActionTacker : IdentityBaseEntity<Guid>
    {
        public Guid RequestTemplateStepId { get; set; }
        public RequestTemplateStep RequestTemplateStep { get; set; }
        public Guid ActionTackerId { get; set; }
    }

}
