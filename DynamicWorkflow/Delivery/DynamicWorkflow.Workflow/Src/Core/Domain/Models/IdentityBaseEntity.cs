namespace _4EPlatform.Domain.Models
{
    public class IdentityBaseEntity<T> : BaseEntity
    {
        public T Id { set; get; }
    }
}
