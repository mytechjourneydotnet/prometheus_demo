using System.Threading.Tasks;

namespace Prometheus_Demo.Services
{
    public interface IGitHubService
    {
        Task<User> GetUserByUsernameAsync(string userName);
    }
}