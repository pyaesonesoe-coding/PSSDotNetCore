namespace PSSDotNetCore.MvcChartApp.Models
{
    public class TimeLineChartModel
    {
        public List<TaskName> Data { get; set; }

    }

    public class TaskName
    {
        public string x { get; set; }
        public DateTime[] y { get; set; }
    }


}
