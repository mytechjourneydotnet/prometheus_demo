using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Prometheus_Demo.Services
{
    public class GitHubService : IGitHubService
    {
        IHttpClientFactory _httpClientfactory;
        public GitHubService(IHttpClientFactory httpClientfactory)
        {
            _httpClientfactory = httpClientfactory;
        }
        public async Task<User> GetUserByUsernameAsync(string userName)
        {
            var client = _httpClientfactory.CreateClient("github");
            string uri = $"/{userName}";
            User user = new User()
            {
                Name = userName,
                Url = new Uri("https://github.com/" + userName)
            };
            var response = await client.GetAsync(uri).ConfigureAwait(false);
            user.Description = await response.Content.ReadAsStringAsync();
            return user;
        }
    }
}
