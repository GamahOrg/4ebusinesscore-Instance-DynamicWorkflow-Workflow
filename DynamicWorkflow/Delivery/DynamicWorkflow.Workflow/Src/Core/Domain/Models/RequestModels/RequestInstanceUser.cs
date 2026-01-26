namespace _4EPlatform.Domain.Models.RequestModels
{
    public class RequestInstanceUser : IdentityBaseEntity<Guid>
    { 
         public Guid   RequestInstanceId {  get; set; }   

        public RequestInstance RequestInstance { get; set; }    
        public Guid? UserId { get; set; }

    }
}
