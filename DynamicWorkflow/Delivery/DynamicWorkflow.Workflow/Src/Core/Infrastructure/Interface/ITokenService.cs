
namespace _4EPlatform.Infrastructure.Helpers
{
    public interface ITokenService
    {
        Task<CallOptions> AcquireToken();
        //Task<CallOptions> GetAccessTokenAsync();
    }
}
