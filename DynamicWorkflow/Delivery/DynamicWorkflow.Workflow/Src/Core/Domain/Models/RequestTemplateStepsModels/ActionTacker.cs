namespace _4EPlatform.Domain.Models.RequestTemplateStepsModels
{
    public class ActionTacker : IdentityBaseEntity<Guid>
    {
        public Guid ActionTakerId { get; set; }
        public ActionTakerTypes Type { get; set; }
        public Guid? RoleId { get; set; }
        public Guid? AlternativeCategoryId { get; set; }
        public virtual List<RequestTemplateStep> RequestTemplateSteps { get; set; }

    }
}
