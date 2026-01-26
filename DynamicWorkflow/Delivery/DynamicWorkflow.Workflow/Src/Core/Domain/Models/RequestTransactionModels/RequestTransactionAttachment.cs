namespace _4EPlatform.Domain.Models.RequestTransactionModels
{
    public class RequestTransactionAttachment : IdentityBaseEntity<Guid>
    {
        public string AttachmentName { get; set; }
        public string AttachmentURL { get; set; }

        [ForeignKey("RequestTransaction")]
        public Guid RequestTransactionId { get; set; }
        public RequestTransaction RequestTransaction { get; set; }
    }
}
