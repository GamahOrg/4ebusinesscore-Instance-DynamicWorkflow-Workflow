namespace _4EPlatform.Domain.Models.AssginRequestInstanceModels
{
    public class GroupAssginActionTacker : IdentityBaseEntity<Guid>
    {
        public Guid ActionTakerId { get; set; }
        public Guid AssginRequestInstanceId { get; set; }
        public AssginRequestInstance AssginRequestInstance { get; set; }

    }



}
