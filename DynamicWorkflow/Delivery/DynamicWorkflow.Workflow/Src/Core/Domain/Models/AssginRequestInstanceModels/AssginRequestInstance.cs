
namespace _4EPlatform.Domain.Models.AssginRequestInstanceModels
{
    public class AssginRequestInstance : IdentityBaseEntity<Guid>
    {
        public AssginRequestInstance()
        {
            GroupAssginActionTackers = new HashSet<GroupAssginActionTacker>();
            AssginRequestTemplateStepAttachment = new HashSet<AssginRequestTemplateStepAttachment>();
            AssginRequestTransactions = new HashSet<AssginRequestTransaction>();

        }
        [PreventInjection]
        public string Description { get; set; }
        public DateTime EndDate { get; set; }
        public Guid RequestTemplateStepId { get; set; }
        public RequestTemplateStep RequestTemplateStep { get; set; }

        public Guid RequestInstanceId { get; set; }
        public RequestInstance RequestInstance { get; set; }
        public Guid ActionTakerId { get; set; }

        public virtual ICollection<GroupAssginActionTacker> GroupAssginActionTackers { get; set; }

        public virtual ICollection<AssginRequestTemplateStepAttachment> AssginRequestTemplateStepAttachment { get; set; }

        public virtual ICollection<AssginRequestTransaction> AssginRequestTransactions { get; set; }

        public RequestTransaction RequestTransaction { get; set; }
        public Guid RequestTransactionId { get; set; }


        public AssginRequestStatus assginRequestStatus { get; set; }
    }



}
