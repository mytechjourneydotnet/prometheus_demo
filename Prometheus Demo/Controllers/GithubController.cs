using Microsoft.AspNetCore.Mvc;
using Prometheus;
using Prometheus_Demo.Services;
using System.Threading.Tasks;

namespace Prometheus_Demo.Controllers
{
    public class GithubController : Controller
    {
        private readonly IGitHubService _githubService;
        Counter counter = Metrics.CreateCounter("get_calls_counter", "It give count of http get requests");
        private static HistogramConfiguration histogramConfiguration = new HistogramConfiguration()
        {
            Buckets = new double[] { 1d, 2d, 3d, 4d, 5d }
        };
        Histogram histogram = Metrics.CreateHistogram("get_calls_latency", "It gives repsonse times of http get requests", histogramConfiguration);

        public GithubController(IGitHubService githubService)
        {
            _githubService = githubService;
        }

        [HttpGet("users/{userName}")]
        public async Task<IActionResult> GetUserByUsername(string userName)
        {
            counter.Inc();
            using (histogram.NewTimer())
            {
                var user = await _githubService.GetUserByUsernameAsync(userName);
                return user != null ? (IActionResult)Ok(user) : NotFound();

            }
        }
    }
}
