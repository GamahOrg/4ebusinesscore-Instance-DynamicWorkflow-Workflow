namespace _4EPlatform.Domain.Models.RequestTemplateModel
{
    public class RequestTemplate : IdentityBaseEntity<Guid>
    {
        [PreventInjection]
        public string? Name { get; set; }
        [PreventInjection]
        public string? Description { get; set; }
        public ActionOptions ActionOptions { get; set; }
        public RequestCategoryType RequestCategoryType { get; set; }
        [ForeignKey("RequestCategoryType")]
        public Guid? RequestCategoryTypeId { get; set; }
        public RequestCategory RequestCategory { get; set; }
        public Guid? RequestCategoryId { get; set; }
        [InverseProperty("ChildRequestTemplates")]
        public Guid? ParentRequestTemplateId { set; get; }
        public virtual RequestTemplate ParentRequestTemplate { set; get; }
        public virtual ICollection<RequestTemplate> ChildRequestTemplates { get; set; }
        public virtual List<RequestTemplateStep> RequestTemplateSteps { get; set; }
        public virtual List<RequestInstance> RequestInstances { get; set; }

        public bool IsClose { get; set; } = false;
        public bool? FromSeed { get; set; }

    }
}
