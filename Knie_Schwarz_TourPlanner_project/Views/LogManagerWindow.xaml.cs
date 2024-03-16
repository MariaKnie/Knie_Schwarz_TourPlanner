using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Text.RegularExpressions;

namespace Knie_Schwarz_TourPlanner_project.Views
{
    /// <summary>
    /// Interaction logic for LogManagerWindow.xaml
    /// </summary>
    public partial class LogManagerWindow : Window
    {
        public LogManagerWindow()
        {
            InitializeComponent();
        }

        //textboxes with 'PreviewTextInput="NumberValidationTextBox"' are only allowed to have numbers input
        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

    }
}
