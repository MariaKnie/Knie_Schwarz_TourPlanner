using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Knie_Schwarz_TourPlanner_project.ViewModels
{
    public class SearchBarViewModel : ViewModelBase, INotifyPropertyChanged
    {
        public ICommand SearchCommand { get; }

        private static string searchText = "Search";

        public string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SearchText)));
            }
        }
        public event PropertyChangedEventHandler? PropertyChanged;

        public SearchBarViewModel()
        {
            SearchCommand = new RelayCommand((_) => {
                Debug.WriteLine($"Search_Button_Click SearchText is {SearchText}");
                //Do search

            });
        }

    }
}
