namespace _4EPlatform.Domain.Models.RequestModels
{
    public class RequestRate : IdentityBaseEntity<Guid>
    {
        public Guid RequsetId { get; set; }
        public RequestInstance RequestInstance { get; set; }
        public int RateValue { get; set; }
    }
}
