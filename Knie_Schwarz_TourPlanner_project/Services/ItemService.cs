using Knie_Schwarz_TourPlanner_project.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

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
                 TourLogs = new ObservableCollection<TourLogModel>()
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
                RouteName = "Dopplerhütte", RouteStart = "Salzburg", RouteGoal = "Vienna", RouteDistance = 5600, EstimatedDuration = "05:35", TransportType = "Car", RouteDiscription = "bLABLABLA",
                 TourLogs = new ObservableCollection<TourLogModel>()
                 {
                     new TourLogModel()
                     {
                         Date = DateTime.Now.AddDays(10),
                         Duration = 50,
                         Distance = 80,
                         Difficulty = 4,
                         Childfriendliness = 2
                     },
                     new TourLogModel()
                     {
                         Date = DateTime.Now.AddDays(18),
                         Duration = 90,
                         Distance = 100,
                         Difficulty = 2,
                         Childfriendliness = 5
                     },
                 }
            },
            new RouteModel()
            {
                RouteName = "Figlwarte", RouteStart = "Gerasdorf", RouteGoal = "G3", RouteDistance = 4012, EstimatedDuration = "01:17", TransportType = "Bus", RouteDiscription = "Some Text",
                 TourLogs = new ObservableCollection<TourLogModel>()
                 {
                     new TourLogModel()
                     {
                         Date = DateTime.Now.AddDays(1),
                         Duration = 50,
                         Distance = 40,
                         Difficulty = 7,
                         Childfriendliness = 2
                     },
                     new TourLogModel()
                     {
                         Date = DateTime.Now.AddDays(3),
                         Duration = 50,
                         Distance = 7,
                         Difficulty = 2,
                         Childfriendliness = 5
                     },
                 }
            },
            new RouteModel()
            {
                RouteName = "Dorfrunde", RouteStart = "Dresdnerstraße", RouteGoal = "Leopoldau", RouteDistance = 8340, EstimatedDuration = "04:41", TransportType = "Walking", RouteDiscription = "So much fun",
                 TourLogs = new ObservableCollection<TourLogModel>()
                 {
                     new TourLogModel()
                     {
                         Date = DateTime.Now.AddDays(7),
                         Duration = 60,
                         Distance = 40,
                         Difficulty = 7,
                         Childfriendliness = 2
                     },
                     new TourLogModel()
                     {
                         Date = DateTime.Now.AddDays(9),
                         Duration = 70,
                         Distance = 9,
                         Difficulty = 5,
                         Childfriendliness = 3
                     },
                 }
            },
        };

        public RouteModel? ActiveRoute
        {
            get => activeRoute;
            set
            {
                activeRoute =  value;
                OnPropertyChanged(nameof(ActiveRoute));
            }
        }

        public TourLogModel? ActiveLogModel
        {
            get => activeLogModel;
            set
            {
                activeLogModel = value;
                OnPropertyChanged(nameof(ActiveLogModel));
            }
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            //Calculate average difficulty and rating
            for(int i = 0; i < Routes.Count; i++)
            {
                float rating = 0;
                float difficutly = 0;
                if (Routes[i].TourLogs.Count != 0)
                {
                    for (int j = 0; j < Routes[i].TourLogs.Count; j++)
                    {
                        difficutly += Routes[i].TourLogs[j].Difficulty;
                        rating += Routes[i].TourLogs[j].Childfriendliness;
                    }
                    difficutly /= Routes[i].TourLogs.Count;
                    rating /= Routes[i].TourLogs.Count;
                }
                Routes[i].Rating = rating;
                Routes[i].Difficulty = difficutly;
            }
        }

    }
}
