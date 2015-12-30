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
    /// Logique d'interaction pour Administration.xaml
    /// </summary>
    public partial class Administration : Page
    {
        /// <summary>
        /// The data list property
        /// </summary>
        public static readonly DependencyProperty DataListProperty =
        DependencyProperty.Register("DataList", typeof(ObservableCollection<LineOfComponent>), typeof(Administration));

        /// <summary>
        /// Initializes a new instance of the <see cref="Administration"/> class.
        /// </summary>
        public Administration()

        {
            InitializeComponent();

            LoadComposants();

            this.DataContext = this; 
        }

        /// <summary>
        /// Loads the composants.
        /// </summary>
        private void LoadComposants() {
            using (var context = new AVosSouhaits.AVSouhaitsDBEntities())
            {
                DateTime now = DateTime.Now;

                ObservableCollection<LineOfComponent> linesOfComponent = new ObservableCollection<LineOfComponent>();

                // Query for all blogs with names starting with B 
                var compos = (from b in context.Composants
                              orderby b.Nom
                              select b).ToList();

                Parallel.For(0, compos.Count / 4, i =>
                    {
                        int value = i * 4;

                        LineOfComponent line = new LineOfComponent();

                        line.compo1 = compos[value];


                        if (value + 1 < compos.Count)
                        {
                            line.compo2 = compos[value + 1];
                        }

                        if (value + 2 < compos.Count)
                        {
                            line.compo3 = compos[value + 2];
                        }

                        if (value + 3 < compos.Count)
                        {
                            line.compo4 = compos[value + 3];
                        }

                        linesOfComponent.Add(line);
                    });

                TimeSpan ts = DateTime.Now - now;

                this.SetValue(Administration.DataListProperty, linesOfComponent);
            }
        }

        /// <summary>
        /// Handles the Click event of the Button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="RoutedEventArgs"/> instance containing the event data.</param>
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RectGray.Visibility = Visibility.Visible;
            NewComposant wind = new NewComposant(-1);
            wind.Owner = Window.GetWindow(this);
            wind.Show();
            wind.Closing += new System.ComponentModel.CancelEventHandler(wind_Closing);
        }

        private void EditComposant(object sender, System.Windows.RoutedEventArgs e)
        {
            int idComposant = int.Parse(((Button)sender).Tag.ToString());

            RectGray.Visibility = Visibility.Visible;
            NewComposant wind = new NewComposant(idComposant);
            wind.Owner = Window.GetWindow(this);
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
            LoadComposants();
            RectGray.Visibility = Visibility.Hidden;
        }

        private void Btn1_click(object sender, RoutedEventArgs e)
        {

        }
    }
}
