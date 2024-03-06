using System.Configuration;
using System.Data;
using System.Windows;
using Knie_Schwarz_TourPlanner_project.Views;

namespace Knie_Schwarz_TourPlanner_project
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var searchBarVM = new ViewModels.SearchBarViewModel();
            var loginVM = new ViewModels.LoginViewModel();

            var wnd = new Views.MainWindow()
            {
                DataContext = new ViewModels.MainViewModel(searchBarVM, loginVM),
                //SearchBar = { DataContext = searchBarVM } //template for other windows?
            };
            wnd.Show();
        }
    }

}
