using Knie_Schwarz_TourPlanner_project.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Knie_Schwarz_TourPlanner_project.Commands;
using System.Windows.Input;

namespace Knie_Schwarz_TourPlanner_project
{
    public class MainViewModel : ViewModelBase
    {
        public LoginViewModel Login { get; } = new LoginViewModel(); 

        public ExitCommand Exit { get; } = new ExitCommand();
    }
}
