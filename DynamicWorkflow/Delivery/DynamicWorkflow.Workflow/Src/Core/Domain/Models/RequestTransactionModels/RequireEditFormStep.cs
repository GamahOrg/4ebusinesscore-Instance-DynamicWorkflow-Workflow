namespace _4EPlatform.Domain.Models.RequestTransactionModels
{
    public class RequireEditFormStep : IdentityBaseEntity<Guid>
    {
        public Guid RequestTransactionId { get; set; }

        //[ForeignKey("RequestTransactionId")]
        //public RequestTransaction RequestTransaction { get; set; }
        public Guid RequestTransactionFromId { get; set; }

        [ForeignKey("RequestTransactionFromId")]
        public RequestTransaction RequestTransactionFrom { get; set; }

    }

}
