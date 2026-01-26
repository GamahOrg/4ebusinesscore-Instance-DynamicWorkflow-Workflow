namespace _4EPlatform.Domain.Models.AssginRequestInstanceModels
{
    public class AssginRequestTransactionAttachment : IdentityBaseEntity<Guid>
    {
        [PreventInjection]
        public string AttachmentName { get; set; }
        public string AttachmentURL { get; set; }
        public Guid AssginRequestTransactionId { get; set; }
        public AssginRequestTransaction AssginRequestTransaction { get; set; }
    }

}
