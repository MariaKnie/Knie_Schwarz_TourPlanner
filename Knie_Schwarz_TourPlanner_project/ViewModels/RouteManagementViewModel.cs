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
using Knie_Schwarz_TourPlanner_project.Services;

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


        public IItemService ItemService { get; set; }

        //Get List from ItemService
        public ObservableCollection<RouteModel> RouteList
        {
            get => ItemService.Routes;
            set
            {
                OnPropertyChanged(nameof(ItemService.Routes));
                OnPropertyChanged(nameof(RouteList));
                Debug.Print("updated List");
                ItemService.Routes = value;
            }
        }



        public RelayCommand DeleteRouteCommand { get; }
        public RelayCommand CreateRouteCommand { get; }
        public RelayCommand LoadRoute { get; }
        public RelayCommand LoadRouteAdd { get; }
        public RelayCommand EditRouteCommand { get; }
        public RelayCommand CheckEditorCommand { get; }

        public CloseWindowCommand CloseWindow { get; } = new CloseWindowCommand();

        RouteModel newRoute = new RouteModel();
        //public RouteEditViewModel REVM = new RouteEditViewModel();

        public RouteModel? ActiveRoute
        {
            get => ItemService.ActiveRoute;
            set
            {
                ItemService.ActiveRoute = value;
                DeleteRouteCommand.RaiseCanExecuteChanged();
                EditRouteCommand.RaiseCanExecuteChanged();
                OnPropertyChanged(nameof(ItemService.ActiveRoute));
            }
        }

        public RouteManagementViewModel(IItemService itemService)
        {
            ItemService = itemService;
            DeleteRouteCommand = new RelayCommand((_) =>
            {
                if (ActiveRoute != null)
                {
                    Debug.Print($"Delete route {ActiveRoute?.RouteName}");
                    RouteList.Remove(ActiveRoute);

                    Debug.Print("List items:" + RouteList.Count);

                }
                OnPropertyChanged(nameof(RouteList));
            },
            (_) => ActiveRoute != null);

            LoadRoute = new RelayCommand((_) =>
            {
                if (ActiveRoute != null && ActiveRoute.RouteName != "")
                {
                    noChanges = ActiveRoute;

                    _routeName = ActiveRoute.RouteName;
                    _routeDiscription = ActiveRoute.RouteDiscription;
                    _routeStart = ActiveRoute.RouteStart;
                    _routeGoal = ActiveRoute.RouteGoal;
                    _transportType = ActiveRoute.TransportType;
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
                            if (noChanges.RouteName == "")
                            {
                                Debug.Print($"Added new Route");
                                RouteList.Add(newRoute);
                                ActiveRoute = newRoute;
                                OnPropertyChanged(nameof(RouteList));
                            }
                            else
                            {   //updates active item
                                Debug.Print($"Updated Route");
                                int index = RouteList.IndexOf(ActiveRoute);
                                RouteList[index] = newRoute;
                                ActiveRoute = newRoute;
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
                if (ActiveRoute != null)
                {
                    Debug.Print($"Edit route {ActiveRoute?.RouteName}");
                    //open edit window
                    var routeEditWnd = new Views.RouteManagerWindow()
                    {
                        DataContext = this,
                    };

                    this.LoadRoute.Execute(this);
                    routeEditWnd.Show();
                }

            },
            (_) => ActiveRoute != null);
        }
    }
}
