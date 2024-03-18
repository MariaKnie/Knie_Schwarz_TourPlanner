using Knie_Schwarz_TourPlanner_project.Models;
using Knie_Schwarz_TourPlanner_project.Services;
using Knie_Schwarz_TourPlanner_project.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace Knie_Schwarz_TourPlanner_project.ViewModels
{
    public class LogViewModel : ViewModelBase
    {
        public float _Duration { get; set; }
        public float _Distance { get; set; }
        public float _Difficulty { get; set; }
        public int _Childfriendliness { get; set; }


        public IItemService ItemService { get; set; }
        public RelayCommand AddLog { get; set; }
        public RelayCommand DeleteLog { get; set; }
        public RelayCommand UpdateLog { get; set; }
        public RelayCommand LoadLogAdd { get; set; }
        public RelayCommand LoadLogEdit { get; set; }
        public RelayCommand SaveLog { get; set; }
        public CloseWindowCommand CloseWindow { get; } = new CloseWindowCommand();
        private bool editLog = false;


        public RouteModel? ActiveRoute
        {
            get => ItemService.ActiveRoute;
            set
            {
                ItemService.ActiveRoute = value;
                OnPropertyChanged(nameof(ItemService.ActiveRoute));
            }
        }

        public TourLogModel? ActiveTourLogModel
        {
            get => ItemService.ActiveLogModel;
            set
            {
                ItemService.ActiveLogModel = value;
                DeleteLog.RaiseCanExecuteChanged();
                UpdateLog.RaiseCanExecuteChanged();
                Debug.Print("Update Logs");
                OnPropertyChanged(nameof(ItemService.ActiveLogModel));
            }
        }
        public LogViewModel(IItemService itemService)
        {
            ItemService = itemService;
            AddLog = new RelayCommand((_) =>
            {
                var logEditWnd = new Views.LogManagerWindow()
                {
                    DataContext = this,
                };
                this.LoadLogAdd.Execute(this);
                logEditWnd.Show();
            },
            (_) => ItemService.ActiveRoute != null);

            LoadLogAdd = new RelayCommand((_) =>
            {
                _Childfriendliness = 0;
                _Difficulty = 0;
                _Distance = 0;
                _Duration = 0;
                editLog = false;    //indicator for ADDING new Logs
            });

            LoadLogEdit = new RelayCommand((_) =>
            {
                if(ActiveTourLogModel != null)
                {
                    _Childfriendliness = ActiveTourLogModel.Childfriendliness;
                    _Difficulty = ActiveTourLogModel.Difficulty;
                    _Distance = ActiveTourLogModel.Distance;
                    _Duration = ActiveTourLogModel.Duration;
                }
                editLog = true;    //indicator for ADDING new Logs
            });

            SaveLog = new RelayCommand((_) =>
            {
                Debug.WriteLine($"Check if complete and correct");
                try
                {
                    if (!editLog) // adding log
                    {
                        Debug.Print($"Added new Log {_Childfriendliness}");
                        TourLogModel Log = new TourLogModel();                   
                        Log.Childfriendliness = _Childfriendliness;
                        Log.Difficulty = _Difficulty;
                        Log.Distance = _Distance;
                        Log.Duration = _Duration;
                        Log.Date = DateTime.Now;

                        ItemService.ActiveRoute.TourLogs.Add(Log);

                        ItemService.ActiveLogModel = Log;

                        OnPropertyChanged(nameof(ItemService.ActiveLogModel));
                    }
                    else // updating
                    {   //updates active item
                        Debug.Print($"Updated Log {_Childfriendliness}");
                        ItemService.ActiveLogModel.Childfriendliness = _Childfriendliness;
                        ItemService.ActiveLogModel.Difficulty = _Difficulty;
                        ItemService.ActiveLogModel.Distance = _Distance;
                        ItemService.ActiveLogModel.Duration = _Duration;
                        ItemService.ActiveLogModel.Difficulty = _Difficulty;
                        ItemService.ActiveLogModel.Date = DateTime.Now;


                        //int index = ItemService.ActiveRoute.TourLogs.IndexOf(ItemService.ActiveLogModel);
                        //ItemService.ActiveRoute.TourLogs[index] = Log;

                        //Debug.Print($"Found to updatee at {index}");

                        OnPropertyChanged(nameof(ItemService.ActiveLogModel));
                    }
                    this.CloseWindow.Execute(this);
                }
                catch (Exception ex) // converting error
                {
                    Debug.WriteLine(ex.ToString());
                }
            });

            DeleteLog = new RelayCommand((_) =>
            {
                ItemService.ActiveRoute.TourLogs.Remove(ActiveTourLogModel);
                OnPropertyChanged(nameof(ActiveTourLogModel));
            },
            (_) => ActiveTourLogModel != null && ItemService.ActiveRoute != null);

            UpdateLog = new RelayCommand((_) =>
            {
                var logEditWnd = new Views.LogManagerWindow()
                {
                    DataContext = this,
                };
                this.LoadLogEdit.Execute(this);
                logEditWnd.Show();
            },
            (_) => ActiveTourLogModel != null && ItemService.ActiveRoute != null);
        }
    }
}
