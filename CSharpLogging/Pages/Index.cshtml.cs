using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CSharpLogging.Pages
{
    public class IndexModel : PageModel
    {
        // standard category
        //private readonly ILogger<IndexModel> _logger;
        //public IndexModel(ILogger<IndexModel> logger)
        //{
        //    _logger = logger;
        //}

        // custom category
        private readonly ILogger _logger;
        public IndexModel(ILoggerFactory factory)        
        {
            _logger = factory.CreateLogger("TestCategory");
        }

        public void OnGet()
        {
            // Logging Level
            _logger.LogTrace("This is Trace log");
            _logger.LogDebug("This is debug log");
            _logger.LogInformation(LoggingId.DemoCode, "This is first message.");
            _logger.LogWarning("This is warning log");
            _logger.LogError("Server down at {Time}", DateTime.UtcNow);
            _logger.LogCritical("This is critical log");


        }
    }


    public class LoggingId
    {
        public const int DemoCode = 1001;

    }

}