using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Knie_Schwarz_TourPlanner_project.Models;

namespace Knie_Schwarz_TourPlanner_project.Interfaces
{
    public interface IEventService:INotifyPropertyChanged
    {
        RouteModel ModelToAdd { get; set; }
        RouteModel ModelToUpdate { get; set; }
    }
}
