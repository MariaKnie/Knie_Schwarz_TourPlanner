using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Knie_Schwarz_TourPlanner_project.Models;
using Knie_Schwarz_TourPlanner_project.Interfaces;

namespace Knie_Schwarz_TourPlanner_project.ViewModels
{
    public class RouteManagementViewModel : ViewModelBase
    {

        private ObservableCollection<RouteModel> routeList { get; set;} = new ObservableCollection<RouteModel>()
        {
            new RouteModel()
            {
                 RouteName = "Wienerwald", RouteStart = "Here", RouteGoal = "There", RouteDistance = 9900, EstimatedDuration = "02:22", TransportType = "Bike", RouteDiscription = "nothing here"
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

        public ObservableCollection<RouteModel> RouteList
        {
            get => routeList;
            set
            {
                OnPropertyChanged("RouteList");
                Debug.Print("updated List");
                routeList = value;
            }
        }


        public RelayCommand DeleteRouteCommand { get; }
        public RelayCommand CreateRouteCommand { get; }
        public RelayCommand UpdateListCommand { get; }
        public RelayCommand EditRouteCommand { get; }
        private RouteModel? activeRoute;
        RouteModel newRoute = new RouteModel();
        public RouteEditViewModel REVM = new RouteEditViewModel();

        public RouteModel? ActiveRoute
        {
            get => activeRoute;
            set
            {
                activeRoute = value;
                DeleteRouteCommand.RaiseCanExecuteChanged();
                EditRouteCommand.RaiseCanExecuteChanged();
            }
        }
        public void SaveChanges()
        {
            REVM.OnSave();
        }

        public void AddRoute(RouteModel routeModel)
        {
            if (newRoute.RouteName != "")
            {
                RouteList.Add(routeModel);
            }
        }

        public void UpdateRoute(RouteModel routeModel)
        {
            activeRoute = routeModel;
        }

        
        

        public RouteManagementViewModel()
        {
            DeleteRouteCommand = new RelayCommand((_) =>
            {
                if (activeRoute != null)
                {
                    Debug.Print($"Delete route {activeRoute?.RouteName}");
                    RouteList.Remove(activeRoute);

                    Debug.Print("List items:" + RouteList.Count);

                }
                OnPropertyChanged(nameof(RouteList));
            },
            (_) => activeRoute != null);

            UpdateListCommand = new RelayCommand((_) =>
            {
                Debug.Print("List items:" + RouteList.Count);
                OnPropertyChanged(nameof(RouteList));
            });

            CreateRouteCommand = new RelayCommand((_) =>
            {
                //open edit window
                var routeEditWnd = new Views.RouteManagerWindow()
                {
                    DataContext = this,
                };
                routeEditWnd.Show();
                REVM.LoadRoute(newRoute);
            },
            (_) => activeRoute != null);

            EditRouteCommand = new RelayCommand((_) =>
            {
                if (activeRoute != null)
                {
                    Debug.Print($"Edit route {activeRoute?.RouteName}");
                    //open edit window
                    var routeEditWnd = new Views.RouteManagerWindow()
                    {
                        DataContext = this,
                    };
                    routeEditWnd.Show();
                    REVM.LoadRoute(activeRoute);
                }
                
            });
        }
    }
}
