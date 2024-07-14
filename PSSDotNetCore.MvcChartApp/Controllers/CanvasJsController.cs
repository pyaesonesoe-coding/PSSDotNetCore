using Microsoft.AspNetCore.Mvc;

namespace PSSDotNetCore.MvcChartApp.Controllers
{
    public class CanvasJsController : Controller
    {
        private readonly ILogger<CanvasJsController> _logger;

		public CanvasJsController(ILogger<CanvasJsController> logger)
		{
			_logger = logger;
		}

		public IActionResult AreaChart()
        {
            _logger.LogInformation("Area Chart...");
            return View();
        }

        public IActionResult PyramidChart()
        {
            return View();
        }
    }
}
