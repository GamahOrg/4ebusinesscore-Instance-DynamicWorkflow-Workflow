// Ignore Spelling: Visbale

namespace _4EPlatform.Domain.Models.RequestTemplateStepsModels
{
    public class RequestTemplateStep : IdentityBaseEntity<Guid>
    {
        public RequestTemplateStep()
        {
            ExceptionActionTacker = new List<ExceptionActionTacker>();
        }
        public int StepNumber { get; set; }
        public ActionTacker ActionTacker { get; set; }
        public Guid ActionTackerId { get; set; }
        public RequestTemplate RequestTemplate { get; set; }
        public Guid RequestTemplateId { get; set; }
        public Guid? SlaId { get; set; }

        public AssginRequestTemplateStep AssginRequestTemplateStep { get; set; }
        public Guid? AssginRequestTemplateStepId { get; set; }

        public bool IsSlaVisbale { get; set; } = false;

        public bool AvailableforClosing { get; set; } = false;

        public virtual List<RequestInstance> RequestInstances { get; set; }
        public virtual List<StepToEdit> StepToEdits { get; set; }
        public virtual List<RequestTransaction> RequestTransactions { get; set; }

        public virtual List<AssginRequestInstance> AssginRequestInstances { get; set; }

        public virtual List<ExceptionActionTacker>? ExceptionActionTacker { get; set; }
        public DeterminExceptionActionTacker DeterminException { get; set; }

    }



}
