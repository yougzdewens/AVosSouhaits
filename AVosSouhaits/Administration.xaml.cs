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
        /// <summary>
        /// The data list property
        /// </summary>
        public static readonly DependencyProperty DataListProperty =
        DependencyProperty.Register("DataList", typeof(ObservableCollection<ProjetAmelio>), typeof(MainWindow));

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();

            LoadProjets();
            this.DataContext = this;            
        }

        /// <summary>
        /// Loads the projets.
        /// </summary>
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

        /// <summary>
        /// Handles the Click event of the Button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click(object sender, System.Windows.RoutedEventArgs e)
        {

            RectGray.Visibility = Visibility.Visible;
            NewProject wind = new NewProject(-1);
            wind.Owner = this;
            wind.Show();
            wind.Closing += new System.ComponentModel.CancelEventHandler(wind_Closing);
        }

        /// <summary>
        /// Edits the projet.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="System.Windows.RoutedEventArgs"/> instance containing the event data.</param>
        private void EditProjet(object sender, System.Windows.RoutedEventArgs e)
        {
            int idProjet = int.Parse(((Button)sender).Tag.ToString());

            RectGray.Visibility = Visibility.Visible;
            NewProject wind = new NewProject(idProjet);
            wind.Owner = this;
            wind.Show();
            wind.Closing += new System.ComponentModel.CancelEventHandler(wind_Closing);
        }

        /// <summary>
        /// Handles the Closing event of the wind control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        private void wind_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            LoadProjets();
            RectGray.Visibility = Visibility.Hidden;
        }
    }
}
