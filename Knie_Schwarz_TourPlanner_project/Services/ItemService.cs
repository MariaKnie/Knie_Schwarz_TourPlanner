using Knie_Schwarz_TourPlanner_project.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knie_Schwarz_TourPlanner_project.Services
{
    public interface IItemService
    {
        public ObservableCollection<RouteModel> Routes { get; set; }
        public RouteModel? ActiveRoute { get; set; }
        public TourLogModel? ActiveLogModel { get; set; }

    }
    public class ItemService : IItemService, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        private RouteModel? activeRoute { get; set; }
        private TourLogModel? activeLogModel { get; set; }
        public ObservableCollection<RouteModel> Routes { get; set; } = new ObservableCollection<RouteModel>()
        {
            new RouteModel()
            {
                 RouteName = "Wienerwald", RouteStart = "Here", RouteGoal = "There", RouteDistance = 9900, EstimatedDuration = "02:22", TransportType = "Bike", RouteDiscription = "nothing here",
                 TourLogs = new List<TourLogModel>()
                 {
                     new TourLogModel()
                     {
                         Date = DateTime.Now,
                         Duration = 50,
                         Distance = 40,
                         Difficulty = 7,
                         Childfriendliness = 2
                     },
                     new TourLogModel()
                     {
                         Date = DateTime.Now,
                         Duration = 10,
                         Distance = 7,
                         Difficulty = 2,
                         Childfriendliness = 5
                     },
                 }
            },
            new RouteModel()
            {
                RouteName = "Dopplerhütte"
            },
            new RouteModel()
            {
                RouteName = "Figlwarte"
            },
            new RouteModel()
            {
                RouteName = "Dorfrunde"
            },
        };

        public RouteModel? ActiveRoute
        {
            get => activeRoute;
            set
            {
                activeRoute = value;
                OnPropertyChanged(nameof(activeRoute));
            }
        }

        public TourLogModel? ActiveLogModel
        {
            get => activeLogModel;
            set
            {
                activeLogModel = value;
                OnPropertyChanged(nameof(activeLogModel));
            }
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
