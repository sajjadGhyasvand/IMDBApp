using DataLayer.Context;
using DataLayer.Entities;
using IMDBApp.Utilities;
using Microsoft.Win32;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Media.Imaging;

namespace IMDBApp.Views
{
    /// <summary>
    /// Interaction logic for vwAddOrEditMovie.xaml
    /// </summary>
    public partial class vwAddOrEditMovie : Window
    {
        public Movie Movie = new Movie();
        private MovieContext _context = new MovieContext();
        OpenFileDialog _dialog = new();
        public vwAddOrEditMovie()
        {
            InitializeComponent();
           
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtPosterName.Content.ToString()) )
            {
                var path = AppDomain.CurrentDomain.BaseDirectory + "\\Images\\Movie\\";
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                var imageName = Guid.NewGuid().ToString().Replace("-","");  
                var ext = System.IO.Path.GetExtension(_dialog.SafeFileName);
                var fullImageName = imageName + ext;
                File.Copy(_dialog.FileName, path + fullImageName);
                Movie.Poster = fullImageName;
            }
            Movie.CreateDate = System.DateTime.Now;
            _context.Movies.Add(Movie);
            _context.SaveChanges();
            this.DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            cmbDirector.ItemsSource = _context.Directors.ToList();
            cmbDirector.SelectedIndex = 0;
            lstCast.ItemsSource = _context.Actors.ToList();
            this.DataContext = Movie;
            if (!string.IsNullOrEmpty(Movie.Poster))
            {
                imgPoster.Source = new BitmapImage(new Uri(Varaible.ImageFullPath+Movie.Poster));
            }
        }

        private void btnPoster_Click(object sender, RoutedEventArgs e)
        {
            _dialog.Filter = "JPG files(*.jpg)|*.jpg|PNG files(*.png)|*.png";
            if (_dialog.ShowDialog() == true)
            {
                txtPosterName.Content = _dialog.FileName;
                imgPoster.Source = new BitmapImage(new System.Uri(_dialog.FileName));
            }
        }
    }
}
