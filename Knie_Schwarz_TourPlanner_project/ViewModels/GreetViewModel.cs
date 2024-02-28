using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace Knie_Schwarz_TourPlanner_project.ViewModels
{
    public class GreetViewModel : ViewModelBase
    {
        
        public ICommand GreetCommand { get; }

        public GreetViewModel()
        {
            GreetCommand = new RelayCommand((_) => {
                Debug.WriteLine($"Button_Click GreetingName is {GreetingName}");
                GreetingText = $"Hello {GreetingName}!";
                Debug.WriteLine($"Button_Click GreetingText is {GreetingText}");

                //ShowPopup_Click(sender, e);   //unsure how to implement rn
            });
        }
    }
}
