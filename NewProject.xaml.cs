using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Linq;

namespace AVosSouhaits
{
	/// <summary>
	/// Interaction logic for NewProject.xaml
	/// </summary>
	public partial class NewProject : Window
	{
        private System.Windows.Data.CollectionViewSource customersViewSource;

		public NewProject()
		{
			this.InitializeComponent();

            //CbCivi1.Items.Add(new ComboBoxItem() { Content = "Mr", Tag = "1", IsSelected = true });
            //CbCivi1.Items.Add(new ComboBoxItem() { Content = "Mlle", Tag = "2" });
            //CbCivi2.Items.Add(new ComboBoxItem() { Content = "Mr", Tag = "1" });
            //CbCivi2.Items.Add(new ComboBoxItem() { Content = "Mlle", Tag = "2", IsSelected = true });


            using (var context = new AVosSouhaits.AVSDatabaseEntities())
            {
                // Query for all blogs with names starting with B 
                var projet = (from b in context.Projets
                            where b.Id == 1
                            select b).First();

                Binding myBinding = new Binding("projetViewSource");
                myBinding.Source = projet;

            }

            //AVSDatabaseEntities test = new AVosSouhaits.AVSDatabaseEntities();
            //AVSDatabaseEntities entities = new AVSDatabaseEntities();
            
            //// Load data into Customers. You can modify this code as needed.
            //customersViewSource = ((System.Windows.Data.CollectionViewSource)(this.FindResource("customersViewSource")));
            //System.Data.Objects.ObjectQuery<AVosSouhaits.Projet> customersQuery = this.GetP(adventureWorksLTEntities);
            //customersViewSource.Source = customersQuery.Execute(System.Data.Objects.MergeOption.AppendOnly);




            //BaseAVosSouhaitsDataSet gbdd = new BaseAVosSouhaitsDataSet();
            //gridMy.ItemsSource = gbdd.Tables[0];

            //SqlConnection con = new SqlConnection(@"Data Source=PORTABLE-HUGUES\SQLEXPRESS;Initial Catalog=AVSDatabase;Persist Security Info=True;User ID=adminEmimie;Password=Genie5959*;Pooling=False");
            //con.Open();
            //SqlCommand cmd = new SqlCommand("Select * From [Projet]", con);
            //SqlDataReader rd = cmd.ExecuteReader();
            //DataTable test = new DataTable();
            //test.Load(rd);
            //int testtest = test.Rows.Count;

			// Insert code required on object creation below this point.
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