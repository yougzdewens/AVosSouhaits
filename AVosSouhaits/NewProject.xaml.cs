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

            expand.Visibility = System.Windows.Visibility.Visible;

            if (idProjet > -1)
            {
                using (var context = new AVosSouhaits.AVSouhaitsDBEntities())
                {
                    // Query for all blogs with names starting with B 
                    var projet = (from b in context.Projets
                                  where b.IdProjet == idProjet
                                  select b).FirstOrDefault();

                    LayoutRoot.DataContext = new ProjetAmelio(projet);
                }
            }
            else
            {
                expand.IsExpanded = true;
                LayoutRoot.DataContext = new ProjetAmelio();
            }
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Projet projet = new Projet();

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

            expand.IsExpanded = false;
        }

        private void expand_Expanded(object sender, RoutedEventArgs e)
        {
            spContentProject.Margin = new Thickness(spContentProject.Margin.Left, spContentProject.Margin.Top + 324, spContentProject.Margin.Right, spContentProject.Margin.Bottom);
        }

        private void expand_Collapsed(object sender, RoutedEventArgs e)
        {
            spContentProject.Margin = new Thickness(spContentProject.Margin.Left, spContentProject.Margin.Top - 324, spContentProject.Margin.Right, spContentProject.Margin.Bottom);
        }

        private void btnaddcompo_Click(object sender, RoutedEventArgs e)
        {
            int marginOfStackPanel = 10;
            int widthOfStackPanel = 50;

            StackPanel spNewCol = new StackPanel();
            spNewCol.Orientation = Orientation.Vertical;
            spNewCol.Margin = new Thickness(marginOfStackPanel);
            spNewCol.Width = widthOfStackPanel;
            Label lb = new Label();
            lb.Content = "coucou";

            spNewCol.Children.Add(lb);


            double widthLastLine = 0;
            double widthTotalOfChildren = 0;

            if (spContentProject.Children[spContentProject.Children.Count - 1].GetType() == typeof(StackPanel))
            {
                widthLastLine = LayoutRoot.RenderSize.Width;

                foreach (StackPanel spIntern in ((StackPanel)spContentProject.Children[spContentProject.Children.Count - 1]).Children)
                {
                    widthTotalOfChildren += spIntern.Width + spIntern.Margin.Left + spIntern.Margin.Right;
                }
            }

            StackPanel spLineToAddContent = null;

            if (widthTotalOfChildren == 0 || widthTotalOfChildren + widthOfStackPanel + (marginOfStackPanel * 2) > widthLastLine)
            {
                spLineToAddContent = new StackPanel();
                spLineToAddContent.Orientation = Orientation.Horizontal;
                spLineToAddContent.Children.Add(spNewCol);
                spContentProject.Children.Add(spLineToAddContent);
            }
            else
            {
                spLineToAddContent = (StackPanel)spContentProject.Children[spContentProject.Children.Count - 1];
                spLineToAddContent.Children.Add(spNewCol);
            }    
        }
    }
}