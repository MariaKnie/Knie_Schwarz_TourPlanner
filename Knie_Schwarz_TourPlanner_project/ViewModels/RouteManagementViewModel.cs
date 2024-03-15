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
        public string _routeName { get; set; } = "";
        public string _routeDiscription { get; set; } = "";
        public string _routeStart { get; set; } = "";
        public string _routeGoal { get; set; } = "";
        public string _transportType { get; set; } = "";


        //public ICommand CalculateDistance { get; }
        //public ICommand CalculateDuration { get; }
        public bool complete { get; set; } = false;

        RouteModel noChanges = new RouteModel(); //if no changes are made

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
        public RelayCommand LoadRoute {  get; }
        public RelayCommand LoadRouteAdd { get; }
        public RelayCommand EditRouteCommand { get; }
        public RelayCommand CheckEditorCommand { get; }

        public CloseWindowCommand CloseWindow { get; } = new CloseWindowCommand();

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

            LoadRoute = new RelayCommand((_) =>
            {
            if (activeRoute != null && activeRoute.RouteName != "")
                {
                    noChanges = activeRoute;

                    _routeName = activeRoute.RouteName;
                    _routeDiscription = activeRoute.RouteDiscription;
                    _routeStart = activeRoute.RouteStart;
                    _routeGoal = activeRoute.RouteGoal;
                    _transportType = activeRoute.TransportType;
                }
                
            });

            LoadRouteAdd = new RelayCommand((_) =>
            {
                noChanges.RouteName = "";   //used to determine if new later
                newRoute = new RouteModel();

                _routeName = newRoute.RouteName;
                _routeDiscription = newRoute.RouteDiscription;
                _routeStart = newRoute.RouteStart;
                _routeGoal = newRoute.RouteGoal;
                _transportType = newRoute.TransportType;

            });

            CheckEditorCommand = new RelayCommand((_) =>
            {
                Debug.WriteLine($"Check if complete and correct");
                if (_routeName != "" && _routeGoal != "" && _routeStart != "" && _transportType != "")
                {
                    //TODO:
                    //check for correctness
                    complete = true;
                    try
                    {
                        if (complete)
                        {
                            int r;  //used for checking if input has correct form
                            if (Int32.TryParse(_routeName, out r) || Int32.TryParse(_routeGoal, out r) || Int32.TryParse(_routeStart, out r) || Int32.TryParse(_transportType, out r) || Int32.TryParse(_routeDiscription, out r))
                            {
                                throw new Exception("Invalid Input. Please enter only letters");
                            }
                            //set new values
                            //this.CalculateDuration.Execute(this);
                            //this.CalculateDistance.Execute(this);
                            newRoute.RouteStart = _routeStart;
                            newRoute.RouteGoal = _routeGoal;
                            newRoute.TransportType = _transportType;
                            newRoute.RouteDiscription = _routeDiscription;
                            newRoute.RouteName = _routeName;
                            newRoute.RouteDistance = 100;  //PlaceHolder
                            newRoute.EstimatedDuration = "1 hour";  //PlaceHolder
                            //add if new route
                            this.CloseWindow.Execute(this);
                            if(noChanges.RouteName == "")
                            {
                                Debug.Print($"Added new Route");
                                RouteList.Add(newRoute);
                                OnPropertyChanged(nameof(RouteList));
                            }
                            else
                            {   //updates active item
                                Debug.Print($"Updated Route");
                                int index = RouteList.IndexOf(activeRoute);
                                RouteList[index] = newRoute;
                                OnPropertyChanged(nameof(RouteList));
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.ToString());
                    }
                    complete = false;
                }
                else
                {
                    Debug.WriteLine("Incomplete Information");
                }
            });

            CreateRouteCommand = new RelayCommand((_) =>
            {
                
                //open edit window
                var routeEditWnd = new Views.RouteManagerWindow()
                {
                    DataContext = this,
                };
                this.LoadRouteAdd.Execute(this);
                routeEditWnd.Show();
            });

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

                    this.LoadRoute.Execute(this);
                    routeEditWnd.Show();
                }
                
            },
            (_) => activeRoute != null);
        }
    }
}
