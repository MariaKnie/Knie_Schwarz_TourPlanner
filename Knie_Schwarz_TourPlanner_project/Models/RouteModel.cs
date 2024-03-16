using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Knie_Schwarz_TourPlanner_project.Models
{
    public class RouteModel
    {
        public string RouteName { get; set; } = "";
        public string RouteDiscription { get; set; } = "";
        public string RouteStart { get; set; } = "";
        public string RouteGoal { get; set; } = "";
        public string TransportType { get; set; } = "";
        public float RouteDistance { get; set; } = 0;
        public string EstimatedDuration { get; set; } = "";
        //RouteInformation missing -> image
        public string mapURL = "\\Assets\\Images\\map.jpg";
        public List<TourLogModel> TourLogs { get; set; } = new List<TourLogModel>();
    }
}
