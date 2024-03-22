using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knie_Schwarz_TourPlanner_project.Models
{
    public class TourLogModel
    {
        public DateTime Date { get; set; }
        public float Duration { get; set; }
        public float Distance { get; set; }
        public float Difficulty { get; set; }
        public float Childfriendliness { get; set; }
    }
}
