using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NbSites.Web.Helpers;

namespace NbSites.Web.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class DemoController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<DemoController> _logger;

        public DemoController(ILogger<DemoController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public string GetStatus()
        {
            return "From DemoController OK";
        }

        [HttpGet]
        public string Call([FromServices] IWebHostEnvironment env)
        {
            //www folder! may be null
            //var workDir = env.WebRootPath;

            //App folder
            //same as Directory.GetCurrentDirectory();
            var workDir = env.ContentRootPath;

            var shellHelper = new ShellHelper();
            var runFile = shellHelper.RunFile(workDir, "demo.bat", "");
            return runFile;
        }
    }
}
