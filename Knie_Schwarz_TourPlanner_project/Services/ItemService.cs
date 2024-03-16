using Knie_Schwarz_TourPlanner_project.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knie_Schwarz_TourPlanner_project.Services
{
    public interface IItemService
    {
        public ObservableCollection<RouteModel> Routes { get; set; }
       
    }
    public class ItemService : IItemService
    {
        public ObservableCollection<RouteModel> Routes { get; set; }
        
    }
}
