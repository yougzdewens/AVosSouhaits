﻿using System;
using System.Collections.Generic;
using System.IO;
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
    /// Logique d'interaction pour NewComposant.xaml
    /// </summary>
    public partial class NewComposant : Window
    {
        public NewComposant(int idComposant)
        {
            InitializeComponent();

            if (idComposant > -1)
            {
                using (var context = new AVosSouhaits.AVSouhaitsDBEntities())
                {
                    // Query for all blogs with names starting with B 
                    var composant = (from b in context.Composants
                                  where b.IdComposant == idComposant
                                  select b).FirstOrDefault();

                    LayoutRoot.DataContext = composant;
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                imgSrc.Source = new BitmapImage(new Uri(dlg.FileName));

                tbPathImage.Text = dlg.FileName;
            }
        }

        private void Button_save_Click(object sender, RoutedEventArgs e)
        {
            //string saveFolderpath = @".\ContactImages\";

            string filepath = tbPathImage.Text;

            //FileInfo fi = new FileInfo(filepath);

            //string finename = Guid.NewGuid().ToString() + fi.Extension;

            //if (!Directory.Exists(saveFolderpath))
            //{
            //    Directory.CreateDirectory(saveFolderpath);
            //}

            //System.IO.File.Copy(filepath, saveFolderpath + finename, true);

            imgSrc.Source = null;

            using (var context = new AVosSouhaits.AVSouhaitsDBEntities())
            {
                Composant compo = new Composant();

                //if (idProjet.Text != string.Empty)
                //{
                //    long idProj = long.Parse(idProjet.Text);

                //    projet = (from b in context.Projets
                //              where b.IdProjet == idProj
                //              select b).FirstOrDefault();
                //}
                //else
                //{
                context.Composants.Add(compo);
                //}

                compo.Nom = tbName.Text;
                compo.Note = tbNote.Text;
                compo.UrlPhoto = "urlPicture";
                compo.Image = ConvertImage(filepath);
                context.SaveChanges();
            }
        }

        /// <summary>
        /// Converts the image to byte array
        /// </summary>
        /// <param name="pathOfImage">The path of image.</param>
        /// <returns></returns>
        private byte[] ConvertImage(string pathOfImage)
        {
            System.Windows.Media.Imaging.BitmapFrame bitmapFrame;

            using (var fs = new System.IO.FileStream(pathOfImage, FileMode.Open))
            {
                bitmapFrame = BitmapFrame.Create(fs);
            }

            System.Windows.Media.Imaging.BitmapEncoder encoder =
                new System.Windows.Media.Imaging.JpegBitmapEncoder();
            encoder.Frames.Add(bitmapFrame);

            byte[] myBytes;
            using (var memoryStream = new System.IO.MemoryStream())
            {
                encoder.Save(memoryStream);
                myBytes = memoryStream.ToArray();
            }

            return myBytes;
        }
    }
}
