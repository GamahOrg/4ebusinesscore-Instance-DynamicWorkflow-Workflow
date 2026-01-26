

namespace _4EPlatform.Domain.Models.RequestModels
{
    public class RequestInstance : IdentityBaseEntity<Guid>
    {
        public RequestInstance()
        {
            AssginRequestInstances = new HashSet<AssginRequestInstance>();
            RequestInstanceUsers = new HashSet<RequestInstanceUser>();
        }
        [PreventInjection]
        public string? Name { get; set; }
        [PreventInjection]
        public string? Description { get; set; }
        public RequestStatus RequestStatus { get; set; }
        public RequestTemplate RequestTemplate { get; set; }
        public Guid RequestTemplateId { get; set; }
        public RequestTemplateStep CurrentStep { get; set; }
        public Guid? CurrentStepId { get; set; }
        public Guid? ItemId { get; set; }
        public ServiceType? ServiceType { get; set; }
        public virtual List<StepToEdit> StepsToEdit { get; set; }
        public virtual List<RequestTransaction> RequestTransactions { get; set; }

        public virtual RequestRate? RequestRate { get; set; }

        public virtual ICollection<AssginRequestInstance> AssginRequestInstances { get; set; }

        public Guid? IntegrationId { get; set; }

        public ICollection<RequestInstanceUser> RequestInstanceUsers { get; set; }
    }
}
