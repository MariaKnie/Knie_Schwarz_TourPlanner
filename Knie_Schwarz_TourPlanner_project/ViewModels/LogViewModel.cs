using Knie_Schwarz_TourPlanner_project.Models;
using Knie_Schwarz_TourPlanner_project.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public TourLogModel ActiveTourLogModel
        {
            get => ItemService.ActiveLogModel;
            set
            {
                ItemService.ActiveLogModel = value;
            }
        }
        public LogViewModel(IItemService itemService)
        {
            ItemService = itemService;

            AddLog = new RelayCommand((_) =>
            {
                TourLogModel Log = new TourLogModel();
                Log.Childfriendliness = _Childfriendliness;
                Log.Difficulty = _Difficulty;
                Log.Distance = _Distance;
                Log.Difficulty = _Difficulty;
                Log.Date = DateTime.Now;

                ItemService.ActiveRoute.TourLogs.Add(Log);
            },
            (_) => ItemService.ActiveRoute != null);

            DeleteLog = new RelayCommand((_) =>
            {
                ItemService.ActiveRoute.TourLogs.Remove(ActiveTourLogModel);
            },
            (_) => ActiveTourLogModel != null && ItemService.ActiveRoute != null);

            UpdateLog = new RelayCommand((_) =>
            {
                TourLogModel Log = new TourLogModel();
                Log.Childfriendliness = _Childfriendliness;
                Log.Difficulty = _Difficulty;
                Log.Distance = _Distance;
                Log.Difficulty = _Difficulty;
                Log.Date = DateTime.Now;

                ItemService.ActiveRoute.TourLogs.Add(Log);
            },
            (_) => ActiveTourLogModel != null && ItemService.ActiveRoute != null);
        }
    }
}
