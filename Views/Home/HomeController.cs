using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CanvasJSChartExample.Models;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace CanvasJSChartExample.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            List<DataPointBar> dataPoints = new List<DataPointBar>{
                new DataPointBar(10, 22),
                new DataPointBar(20, 36),
                new DataPointBar(30, 42),
                new DataPointBar(40, 51),
                new DataPointBar(50, 46),
                new DataPointBar(40, 40),
            };

            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public ContentResult JSON()
        {
            List<DataPoint> dataPoints = new List<DataPoint>();


            dataPoints.Add(new DataPoint(1506882600000, new double[] { 85.990997, 86.374001, 85.945999, 86.374001 }));
            dataPoints.Add(new DataPoint(1506969000000, new double[] { 86.374001, 86.374001, 86.374001, 86.374001 }));
            dataPoints.Add(new DataPoint(1507055400000, new double[] { 86.5, 88.679001, 86.199997, 87.764999 }));
            dataPoints.Add(new DataPoint(1507141800000, new double[] { 88.098999, 89.172997, 88.098999, 88.800003 }));
            dataPoints.Add(new DataPoint(1507228200000, new double[] { 88.532997, 89.334999, 88.532997, 89.271004 }));
            dataPoints.Add(new DataPoint(1507487400000, new double[] { 88.801003, 89.126999, 88.622002, 88.978996 }));
            dataPoints.Add(new DataPoint(1507573800000, new double[] { 88.693001, 88.900002, 88.199997, 88.639999 }));
            dataPoints.Add(new DataPoint(1507660200000, new double[] { 88.419998, 88.605003, 87.958, 88.605003 }));
            dataPoints.Add(new DataPoint(1507746600000, new double[] { 88.213997, 88.566002, 87.484001, 87.938004 }));
            dataPoints.Add(new DataPoint(1507833000000, new double[] { 87.800003, 87.800003, 86.848, 87.487 }));
            dataPoints.Add(new DataPoint(1508092200000, new double[] { 87.100998, 87.649002, 86.975998, 87.295998 }));
            dataPoints.Add(new DataPoint(1508178600000, new double[] { 86.906998, 87.656998, 86.370003, 87.656998 }));
            dataPoints.Add(new DataPoint(1508265000000, new double[] { 88.214996, 88.545998, 87.992996, 88.418999 }));
            dataPoints.Add(new DataPoint(1508351400000, new double[] { 87.699997, 87.699997, 86.099998, 87.093002 }));
            dataPoints.Add(new DataPoint(1508437800000, new double[] { 86.800003, 87.533997, 86.385002, 86.385002 }));
            dataPoints.Add(new DataPoint(1508697000000, new double[] { 86.221001, 86.613998, 85.751999, 85.999001 }));
            dataPoints.Add(new DataPoint(1508783400000, new double[] { 85.801003, 86.605003, 85.242996, 86.549004 }));
            dataPoints.Add(new DataPoint(1508869800000, new double[] { 86.248001, 86.248001, 85, 85.248001 }));
            dataPoints.Add(new DataPoint(1508956200000, new double[] { 85.401001, 86.554001, 85.188004, 86.066002 }));
            dataPoints.Add(new DataPoint(1509042600000, new double[] { 86.500999, 87.747002, 86.500999, 87.002998 }));
            dataPoints.Add(new DataPoint(1509301800000, new double[] { 87.225998, 87.776001, 87.225998, 87.282997 }));
            dataPoints.Add(new DataPoint(1509388200000, new double[] { 87.282997, 87.282997, 87.282997, 87.282997 }));


            JsonSerializerSettings _jsonSetting = new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore };
            return Content(JsonConvert.SerializeObject(dataPoints, _jsonSetting), "application/json");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

    [DataContract]
    public class DataPointBar
    {
        public DataPointBar(double x, double y)
        {
            this.X = x;
            this.Y = y;
        }

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "x")]
        public Nullable<double> X = null;

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "y")]
        public Nullable<double> Y = null;
    }

    //DataContract for Serializing Data - required to serve in JSON format
    [DataContract]
    public class DataPoint
    {
        public DataPoint(double x, double[] y)
        {
            this.X = x;
            this.Y = y;
        }

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "x")]
        public Nullable<double> X = null;

        //Explicitly setting the name to be used while serializing to JSON.
        [DataMember(Name = "y")]
        public double[] Y = null;
    }
}
