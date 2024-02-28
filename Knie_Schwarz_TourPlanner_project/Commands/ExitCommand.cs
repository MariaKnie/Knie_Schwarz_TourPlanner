using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Knie_Schwarz_TourPlanner_project.Commands
{
    public class ExitCommand : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            Debug.WriteLine("ButtonExit_Click");
            System.Environment.Exit(0);
            //Application.Current.Shutdown();
        }
    }
}
