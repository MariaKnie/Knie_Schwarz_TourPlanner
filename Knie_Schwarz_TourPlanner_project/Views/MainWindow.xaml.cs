using System.ComponentModel;
using System.Diagnostics;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Knie_Schwarz_TourPlanner_project.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        private DispatcherTimer timer;
        
        public MainWindow()
        {
            InitializeComponent();
            timer = new DispatcherTimer();
            timer.Tick += Timer_Tick;
        }

        private void ShowPopup_Click(object sender, RoutedEventArgs e)
        {
            //myPopup.IsOpen = true;
            timer.Interval = TimeSpan.FromSeconds(3); // Adjust duration here
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            //myPopup.IsOpen = false;
            timer.Stop();
        }

        private void Tourlogs_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void TourList_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}