using Microsoft.AspNetCore.Mvc;
using PSSDotNetCore.MvcChartApp.Models;

namespace PSSDotNetCore.MvcChartApp.Controllers
{
    public class ApexChartController : Controller
    {
        public IActionResult TimeLineChart()
        {
            TimeLineChartModel model = new TimeLineChartModel();
            model.Data = new List<TaskName>
            {
                new TaskName
                {
                    x = "Code",
                    y = new DateTime[] { new DateTime(2019, 3, 2), new DateTime(2019, 3, 4) }
                },
                new TaskName
                {
                    x = "Test",
                    y = new DateTime[] { new DateTime(2019, 3, 4), new DateTime(2019, 3, 8) }
                },
                new TaskName
                {
                    x = "Validation",
                    y = new DateTime[] { new DateTime(2019, 3, 8), new DateTime(2019, 3, 12) }
                },
                new TaskName
                {
                    x = "Deployment",
                    y = new DateTime[] { new DateTime(2019, 3, 12), new DateTime(2019, 3, 18) }
                }
            };
            return View(model);
        }
    }
}
