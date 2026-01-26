namespace _4EPlatform.Domain.Models.AssginRequestInstanceModels
{
    public class AssginRequestTemplateStepAttachment : IdentityBaseEntity<Guid>
    {
        [PreventInjection]
        public string AttachmentName { get; set; }
        public string AttachmentURL { get; set; }
        public Guid AssginRequestInstanceId { get; set; }
        public AssginRequestInstance AssginRequestInstance { get; set; }
    }



}
