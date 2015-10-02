using AVosSouhaits.HeritageEntities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public static readonly DependencyProperty DataListProperty =
        DependencyProperty.Register("DataList", typeof(ObservableCollection<ProjetAmelio>), typeof(MainWindow));

        public MainWindow()
        {
            InitializeComponent();

            LoadProjets();
            this.DataContext = this;            
        }

        private void LoadProjets()
        {
            using (var context = new AVosSouhaits.AVSouhaitsDBEntities())
            {
                // Query for all blogs with names starting with B 
                var projet = (from b in context.Projets
                              orderby b.DateDuMariage
                              select b).ToList();

                ObservableCollection<ProjetAmelio> projs2 = new ObservableCollection<ProjetAmelio>();

                projet.ForEach(x => projs2.Add(new ProjetAmelio(x)));
                //this.DataContext = projs;

                this.SetValue(MainWindow.DataListProperty, projs2);
            }
        }

        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            RectGray.Visibility = Visibility.Visible;
            NewProject wind = new NewProject(-1);
            wind.Owner = this;
            wind.Show();
            wind.Closing += new System.ComponentModel.CancelEventHandler(wind_Closing);
        }

        private void EditProjet(object sender, System.Windows.RoutedEventArgs e)
        {
            int idProjet = int.Parse(((Button)sender).Tag.ToString());

            RectGray.Visibility = Visibility.Visible;
            NewProject wind = new NewProject(idProjet);
            wind.Owner = this;
            wind.Show();
            wind.Closing += new System.ComponentModel.CancelEventHandler(wind_Closing);
        }

        private void wind_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            LoadProjets();
            RectGray.Visibility = Visibility.Hidden;
        }
    }
}
