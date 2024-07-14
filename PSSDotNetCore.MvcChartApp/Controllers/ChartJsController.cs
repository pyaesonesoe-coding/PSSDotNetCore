using Microsoft.AspNetCore.Mvc;

namespace PSSDotNetCore.MvcChartApp.Controllers
{
    public class ChartJsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
