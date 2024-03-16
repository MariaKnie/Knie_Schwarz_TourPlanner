using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Knie_Schwarz_TourPlanner_project.ViewModels;
using Knie_Schwarz_TourPlanner_project.Views;

namespace Knie_Schwarz_TourPlanner_project.Services
{
    public class WindowMapper
    {
        private readonly Dictionary<Type, Type> _mappings = new Dictionary<Type, Type>();

        public WindowMapper()
        {
            RegisterMapping<MainViewModel, MainWindow>();
            RegisterMapping<RouteManagementViewModel, RouteManagerWindow>();
            RegisterMapping<LogViewModel, LogManagerWindow>();

        }

        //maps ViewModel to Window
        public void RegisterMapping<TViewModel, TWindow>() where TViewModel : ViewModelBase where TWindow : Window
        {
            _mappings[typeof(TViewModel)] = typeof(TWindow);
        }

        //lookup type of window for viewModel mapping
        public Type? GetWindowType(Type viewModelType)
        {
            _mappings.TryGetValue(viewModelType, out var windowType);
            return windowType;
        }
    }
}
