using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Knie_Schwarz_TourPlanner_project.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        private string greetingText = "Hello";

        public string GreetingName { get; set; } = "World";

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
    }
}
