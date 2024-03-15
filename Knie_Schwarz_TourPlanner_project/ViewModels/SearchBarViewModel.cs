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


        public SearchBarViewModel()
        {
            SearchCommand = new RelayCommand((_) =>
            {
                Debug.WriteLine($"Search_Button_Click SearchText is {SearchText}");
                //Do search

            });
            
        }

    }
}
