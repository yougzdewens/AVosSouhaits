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
using System.Windows.Shapes;

namespace AVosSouhaits
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

            AVosSouhaits.AVSDatabaseDataSet aVSDatabaseDataSet = ((AVosSouhaits.AVSDatabaseDataSet)(this.FindResource("aVSDatabaseDataSet")));
            // Load data into the table Projet. You can modify this code as needed.
            AVosSouhaits.AVSDatabaseDataSetTableAdapters.ProjetTableAdapter aVSDatabaseDataSetProjetTableAdapter = new AVosSouhaits.AVSDatabaseDataSetTableAdapters.ProjetTableAdapter();
            aVSDatabaseDataSetProjetTableAdapter.Fill(aVSDatabaseDataSet.Projet);
            System.Windows.Data.CollectionViewSource projetViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("projetViewSource")));
            projetViewSource.View.MoveCurrentToFirst();
        }
    }
}
