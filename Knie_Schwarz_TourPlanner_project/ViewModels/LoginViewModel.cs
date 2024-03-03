using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace Knie_Schwarz_TourPlanner_project.ViewModels
{
    public class LoginViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public ICommand LoginCommand { get; }
        public ICommand GreetCommand { get; }

        private static string greetingText = "Hello";

        public static string GreetingName { get; set; } = "World";

        public string GreetingText
        {
            get => greetingText;
            set
            {
                greetingText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(GreetingText)));
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand((_) => {
                Debug.WriteLine($"Button_Click GreetingName is {GreetingName}");
                GreetingText = $"You have logged in, {GreetingName}!";
                Debug.WriteLine($"Button_Click GreetingText is {GreetingText}");

                //ShowPopup_Click(sender, e);   //unsure how to implement rn
            });

            GreetCommand = new RelayCommand((_) => {
                Debug.WriteLine($"Button_Click GreetingName is {GreetingName}");
                GreetingText = $"Hello {GreetingName}!";
                Debug.WriteLine($"Button_Click GreetingText is {GreetingText}");

                //ShowPopup_Click(sender, e);   //unsure how to implement rn
            });
        }
    }
}
