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
using AVosSouhaits.HeritageEntities;

namespace AVosSouhaits
{
    /// <summary>
    /// Interaction logic for NewProject.xaml
    /// </summary>
    public partial class NewProject : Window
    {
        public NewProject(int idProjet)
        {
            this.InitializeComponent();

            if (idProjet > -1)
            {
                using (var context = new AVosSouhaits.AVSouhaitsDBEntities())
                {
                    // Query for all blogs with names starting with B 
                    var projet = (from b in context.Projets
                                  where b.IdProjet == idProjet
                                  select b).FirstOrDefault();

                    LayoutRoot.DataContext = projet;
                }
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Projet projet = null;

            projet = new Projet();

            using (var context = new AVosSouhaits.AVSouhaitsDBEntities())
            {
                if (idProjet.Text != string.Empty)
                {
                    long idProj = long.Parse(idProjet.Text);

                    projet = (from b in context.Projets
                              where b.IdProjet == idProj
                              select b).FirstOrDefault();
                }
                else
                {
                    context.Projets.Add(projet);
                }

                projet.Civilite1 = long.Parse(CbCivi1.SelectedValue.ToString());
                projet.Nom1 = nom1.Text;
                projet.Prenom1 = prenom1.Text;
                projet.Civilite2 = long.Parse(CbCivi2.SelectedValue.ToString());
                projet.Nom2 = nom2.Text;
                projet.Prenom2 = prenom2.Text;
                projet.Telephone = telephone.Text;
                projet.Ville = ville.Text;
                projet.Email = email.Text;
                projet.Adresse = adresse.Text;
                projet.CodePostal = codepostal.Text;
                projet.Budget = long.Parse(budget.Text);
                projet.DateDuMariage = DateTime.Parse(dateDuMarriage.Text);
                
                context.SaveChanges();
            }

            this.Close();
        }
    }
}