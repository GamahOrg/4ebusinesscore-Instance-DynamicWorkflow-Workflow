namespace _4EPlatform.Domain.Models.RequestCategoryModels
{
    public class RequestCategory : IdentityBaseEntity<Guid>
    {
        [PreventInjection]
        public string Name { get; set; }
        public bool? FromSeed { get; set; }
        public virtual List<RequestTemplate> RequestTemplates { get; set; }
        public virtual ICollection<RequestCategoryType> RequestCategoryTypes { get; set; }
    }
}
