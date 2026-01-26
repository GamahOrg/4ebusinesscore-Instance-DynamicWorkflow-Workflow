namespace _4EPlatform.Domain.Models.RequestTemplateStepsModels
{
    public class AssginRequestTemplateStep : IdentityBaseEntity<Guid>
    {
        public bool IsCountTask { get; set; }
        public int? CountTask { get; set; }
    //    public ActionAssgin ActionAssgin { get; set; }
        public Guid RequestTemplateId { get; set; }
        public RequestTemplateStep Step { get; set; }
    }

 

}
