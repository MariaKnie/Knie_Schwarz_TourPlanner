using Knie_Schwarz_TourPlanner_project.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Knie_Schwarz_TourPlanner_project.Services
{
    public interface IWindowManager //alternative to implemented -> will test if better this way
    {
        void ShowWindow(ViewModelBase viewModel);
        void CloseWindow();
    }
    public class WindowManager : IWindowManager
    {
        private readonly WindowMapper _windowMapper;
        public WindowManager(WindowMapper windowMapper)
        {
            _windowMapper = windowMapper;
        }
        public void ShowWindow(ViewModelBase viewModel) //opens window mapped to viewmodel
        {
            var windowType = _windowMapper.GetWindowType(viewModel.GetType());
            if(windowType != null)
            {
                var window = Activator.CreateInstance(windowType) as Window;
                window.DataContext = viewModel;
                window.Show();
                window.Closed += (o, e) => CloseWindow();
            }
        }


        public void CloseWindow()
        {
            Debug.Print($"Closed Window");
        }
    }
}
