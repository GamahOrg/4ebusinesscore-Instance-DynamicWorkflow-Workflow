namespace _4EPlatform.Domain.Models.AssginRequestInstanceModels
{
    public class AssginRequestTransaction : IdentityBaseEntity<Guid>
    {
        public AssginRequestTransaction()
        {
            AssginRequestTransactionAttachments = new HashSet<AssginRequestTransactionAttachment>();
        }
        [PreventInjection]
        public string Comment { get; set; }
        public DateTime ReceivedDate { get; set; }
        public ActionOptionsAssgin Action { get; set; }
        public AssginRequestInstance AssginRequestInstance { get; set; }
        public Guid AssginRequestInstanceId { get; set; }

        public ICollection<AssginRequestTransactionAttachment> AssginRequestTransactionAttachments { get; set; }
    }

}
