using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Knie_Schwarz_TourPlanner_project.Models;
using Knie_Schwarz_TourPlanner_project.Views;
using Knie_Schwarz_TourPlanner_project.Interfaces;
using System.ComponentModel;

namespace Knie_Schwarz_TourPlanner_project.ViewModels
{
    public class RouteEditViewModel : ViewModelBase
    {


        //-----------------------------------

        //NOT USED rn

        //---------------------------------






        public string _routeName { get; set; } = "";
        public string _routeDiscription { get; set; } = "";
        public string _routeStart { get; set; } = "";
        public string _routeGoal { get; set; } = "";
        public string _transportType { get; set; } = "";


        //public ICommand CalculateDistance { get; }
        //public ICommand CalculateDuration { get; }
        public bool complete { get; set; } = false;
        public RouteModel returnRoute { get; set; }
        RouteModel noChanges = new RouteModel(); //if no changes are made
        public ICommand SaveChanges { get; }
        public CloseWindowCommand CloseWindow { get; } = new CloseWindowCommand();
        public void LoadRoute(RouteModel route)
        {
            noChanges.RouteName = "";   //'soft-reset'
            noChanges = route;

            _routeName = route.RouteName;
            _routeDiscription = route.RouteDiscription;
            _routeStart = route.RouteStart;
            _routeGoal = route.RouteGoal;
            _transportType = route.TransportType;
            route.RouteDistance = 100;  //PlaceHolder
            route.EstimatedDuration = "1 hour";  //PlaceHolder
            
        }
        public RouteModel OnSave()
        {
            if(noChanges.RouteName == "")
            {
                bool done = OnSaveAdd();
                if (done)
                {
                    return returnRoute;
                }
            }
            else
            {
                bool done = OnSaveUpdate();
                if (done)
                {
                    return returnRoute;
                }
            }
            return new RouteModel();
        }

        public bool OnSaveAdd()
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
                        returnRoute.RouteStart = _routeStart;
                        returnRoute.RouteGoal = _routeGoal;
                        returnRoute.TransportType = _transportType;
                        returnRoute.RouteDiscription = _routeDiscription;
                        returnRoute.RouteName = _routeName;
                        //add if new route
                            this.CloseWindow.Execute(this);
                            Debug.Print($"Added new Route");
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
                complete = false;
                return false;
            }
            else
            {
                Debug.WriteLine("Incomplete Information");
                return false;
            }
        }
        public bool OnSaveUpdate()
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
                        returnRoute.RouteStart = _routeStart;
                        returnRoute.RouteGoal = _routeGoal;
                        returnRoute.TransportType = _transportType;
                        returnRoute.RouteDiscription = _routeDiscription;
                        returnRoute.RouteName = _routeName;
                       
                        //update
                        this.CloseWindow.Execute(this);
                        Debug.Print($"Updated Route");
                        return true;
                    }
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.ToString());
                }
                complete = false;
                return false;
            }
            else
            {
                Debug.WriteLine("Incomplete Information");
            }
            return false;
        }
        

        public RouteEditViewModel() 
        {
            //sessionContext.PropertyChanged += OnSessionContextPropertyChanged;

            //CalculateDistance = new RelayCommand((_) =>
            //{
            //    Debug.WriteLine($"Calculating distance");
            //    //Do calculations
            //    //PLACEHOLDER:
            //    route.RouteDistance = 100;
            //});

            //CalculateDuration = new RelayCommand((_) =>
            //{
            //    Debug.WriteLine($"Calculating duration");
            //    //Do calculations
            //    //PLACEHOLDER:
            //    route.EstimatedDuration = "1 hour 21 minutes";
            //});

        }
        //private void OnSessionContextPropertyChanged(object sender, PropertyChangedEventArgs e)
        //{
        //    if (e.PropertyName == "EditorFontSize")
        //    {
        //        this.noChanges = sessionContext.EditorFontSize;
        //    }
        //}
    }
}
