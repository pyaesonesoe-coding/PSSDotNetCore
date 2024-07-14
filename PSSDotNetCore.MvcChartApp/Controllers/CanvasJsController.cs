using Microsoft.AspNetCore.Mvc;

namespace PSSDotNetCore.MvcChartApp.Controllers
{
    public class CanvasJsController : Controller
    {
        public IActionResult AreaChart()
        {
            return View();
        }

        public IActionResult PyramidChart()
        {
            return View();
        }
    }
}
