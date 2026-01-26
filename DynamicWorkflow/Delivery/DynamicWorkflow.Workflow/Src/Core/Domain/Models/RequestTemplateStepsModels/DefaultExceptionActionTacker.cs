namespace _4EPlatform.Domain.Models.RequestTemplateStepsModels
{
    public class DefaultExceptionActionTacker: IdentityBaseEntity<Guid>
    {

        public Guid ActionTakerId { get; set; }
    }
}
