using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Knie_Schwarz_TourPlanner_project.Views;
using Knie_Schwarz_TourPlanner_project.ViewModels;

namespace Knie_Schwarz_TourPlanner_project.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public LoginViewModel loginVM { get; } = new LoginViewModel();
        public SearchBarViewModel searchBarVM { get; } = new SearchBarViewModel();
        public ExitCommand Exit { get; } = new ExitCommand();

        public MainViewModel(SearchBarViewModel searchBarVM, LoginViewModel loginVM)
        {
            this.searchBarVM = searchBarVM;
            this.loginVM = loginVM;
        }




        /*
        public LoginViewModel Login { get; } = new LoginViewModel();
        public SearchBarViewModel SearchBar { get; } = new SearchBarViewModel();

        public ExitCommand Exit { get; } = new ExitCommand(); */
    }
}
