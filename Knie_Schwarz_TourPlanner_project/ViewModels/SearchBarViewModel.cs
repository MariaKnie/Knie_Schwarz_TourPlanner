using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Knie_Schwarz_TourPlanner_project.Models;

namespace Knie_Schwarz_TourPlanner_project.ViewModels
{
    public class SearchBarViewModel : ViewModelBase
    {
        public ICommand SearchCommand { get; }
        public RelayCommand DeleteRouteCommand { get; }
        private RouteModel? activeRoute;
        public ObservableCollection<RouteModel> RouteList { get; set; } = new ObservableCollection<RouteModel>()
        {
            new RouteModel()
            {
                 RouteName = "Wienerwald", RouteStart = "Here", RouteGoal = "There", RouteDistance = 9900, EstimatedDuration = "02:22"
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

        private string searchText = "Search";

        public string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;
                OnPropertyChanged(nameof(SearchText));
            }
        }

        public RouteModel? ActiveRoute
        {
            get => activeRoute;
            set
            {
                activeRoute = value;
                DeleteRouteCommand.RaiseCanExecuteChanged();
            }
        }

        public SearchBarViewModel()
        {
            SearchCommand = new RelayCommand((_) =>
            {
                Debug.WriteLine($"Search_Button_Click SearchText is {SearchText}");
                //Do search

            });
            DeleteRouteCommand = new RelayCommand((_) =>
            {
                Debug.Print($"Delete route {activeRoute?.RouteName}");
                if (activeRoute != null)
                    RouteList.Remove(activeRoute);
                OnPropertyChanged(nameof(RouteList));
            },
            (_) => activeRoute != null);
        }

    }
}
