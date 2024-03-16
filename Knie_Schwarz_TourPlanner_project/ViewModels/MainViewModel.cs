using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Knie_Schwarz_TourPlanner_project.Views;
using Knie_Schwarz_TourPlanner_project.ViewModels;
using Knie_Schwarz_TourPlanner_project.Services;

namespace Knie_Schwarz_TourPlanner_project.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        //public LoginViewModel loginVM { get; } = new LoginViewModel();
        //public SearchBarViewModel searchBarVM { get; } = new SearchBarViewModel();
        public ExitCommand Exit { get; } = new ExitCommand();
        public RelayCommand OpenLogManagerWindowCommand { get; set; }
        public IItemService ItemService { get; set; }
        private readonly IWindowManager _windowManager;
        private readonly ViewModelLocator _viewLocator;

        public RouteManagementViewModel routeManagementVM { get; }
        public LogViewModel logVM { get; set; } 

        public MainViewModel(IItemService itemService, IWindowManager windowManager, ViewModelLocator viewModelLocator, RouteManagementViewModel routeManagementVM, LogViewModel logVM)
        {
            ItemService = itemService;
            _viewLocator = viewModelLocator;
            _windowManager = windowManager;

            logVM = new LogViewModel(ItemService);

            routeManagementVM = new RouteManagementViewModel(ItemService);
            this.routeManagementVM = routeManagementVM;

            OpenLogManagerWindowCommand = new RelayCommand((_) =>
            {
                _windowManager.ShowWindow(_viewLocator.LogViewModel);
            });
            this.logVM = logVM;
        }
    }
}

