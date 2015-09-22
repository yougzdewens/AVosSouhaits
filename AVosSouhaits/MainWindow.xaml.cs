using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AVosSouhaits
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {
			
			
			RectGray.Visibility = Visibility.Visible;
        	NewProject wind = new NewProject();
			wind.Owner = this;
			wind.Show();
			wind.Closing+=new System.ComponentModel.CancelEventHandler(wind_Closing);
        }

        private void wind_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
        	RectGray.Visibility = Visibility.Hidden;
        }
    }
}
