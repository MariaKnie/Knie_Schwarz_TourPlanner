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

namespace Knie_Schwarz_TourPlanner_project
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
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
        public MainWindow()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler? PropertyChanged;  // during initialization the engine registers itself to listen to PropertyChanged events

        private void ButtonExit_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("ButtonExit_Click");
            System.Environment.Exit(0);
            //Application.Current.Shutdown();
        }

        private void ButtonGreetMe_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine($"Button_Click GreetingName is {GreetingName}");
            GreetingText = $"Hello {GreetingName}!";
            Debug.WriteLine($"Button_Click GreetingText is {GreetingText}");
        }

        private void ButtonLogin_Click(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine($"Button_Click GreetingName is {GreetingName}");
            GreetingText = $"You have logged in, {GreetingName}!";
            Debug.WriteLine($"Button_Click GreetingText is {GreetingText}");
        }
    }
}