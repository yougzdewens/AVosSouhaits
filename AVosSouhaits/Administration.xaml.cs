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
    /// Logique d'interaction pour Administration.xaml
    /// </summary>
    public partial class Administration : Page
    {
        public Administration()
        {
            InitializeComponent();

            LoadComposants();
        }

        private void LoadComposants() {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RectGray.Visibility = Visibility.Visible;
            NewComposant wind = new NewComposant();
            wind.Owner = Window.GetWindow(this);
            wind.Show();
            wind.Closing += new System.ComponentModel.CancelEventHandler(wind_Closing);
        }

        private void wind_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            //LoadProjets();
            RectGray.Visibility = Visibility.Hidden;
        }
    }
}
