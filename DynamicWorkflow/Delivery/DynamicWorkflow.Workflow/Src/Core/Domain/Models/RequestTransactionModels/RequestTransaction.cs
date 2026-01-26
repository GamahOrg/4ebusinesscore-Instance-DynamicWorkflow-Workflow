namespace _4EPlatform.Domain.Models.RequestTransactionModels
{
    public class RequestTransaction : IdentityBaseEntity<Guid>
    {
        public RequestTransaction()
        {
            RequestTransactionAttachments = new HashSet<RequestTransactionAttachment>();
            requireEditFormSteps = new HashSet<RequireEditFormStep>();
        }
        [PreventInjection]
        public string? Comment { get; set; }
        public DateTime ReceivedDate { get; set; }
        public ActionOptions Action { get; set; }
        public RequestInstance RequestInstance { get; set; }
        public Guid RequestInstanceId { get; set; }
        public RequestTemplateStep RequestTemplateStep { get; set; }
        public Guid RequestTemplateStepId { get; set; }
        public ICollection<RequestTransactionAttachment> RequestTransactionAttachments { get; set; }
        public Guid? AssginRequestInstanceId { get; set; }
        public AssginRequestInstance AssginRequestInstance { get; set; }

        public Guid BaseActionUserId { get; set; }

        public bool IsRequireEdit { get; set; } = false;

        public Guid? RequireEditToStepId { get; set; }

        [ForeignKey("RequireEditToStepId")]
        public RequestTemplateStep? RequireEditToStep { get; set; }

        [InverseProperty("RequestTransactionFrom")]
        public ICollection<RequireEditFormStep> requireEditFormSteps { get; set; }
    }

}
