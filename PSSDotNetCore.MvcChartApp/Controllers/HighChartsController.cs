using Microsoft.AspNetCore.Mvc;

namespace PSSDotNetCore.MvcChartApp.Controllers
{
    public class HighChartsController : Controller
    {
        public IActionResult LineChart()
        {
            return View();
        }

        public IActionResult Variwide()
        {
            return View();
        }
    }
}
