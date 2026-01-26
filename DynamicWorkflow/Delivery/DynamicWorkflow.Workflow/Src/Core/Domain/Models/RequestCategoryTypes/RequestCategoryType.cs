namespace _4EPlatform.Domain.Models.RequestCategoryTypes
{
    public class RequestCategoryType : IdentityBaseEntity<Guid>
    {
        [PreventInjection]
        public string Name { get; set; }
        public RequestCategory RequestCategory { get; set; }
        public Guid RequestCategoryId { get; set; }
        public bool? FromSeed { get; set; }
        public bool? IsHide { get; set; }
        public ICollection<RequestTemplate> RequestTemplates { get; set; }
    }
}
