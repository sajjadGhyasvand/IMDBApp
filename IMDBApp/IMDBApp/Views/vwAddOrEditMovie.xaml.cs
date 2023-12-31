﻿using DataLayer.Context;
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
            if (_dialog!=null && !string.IsNullOrEmpty(_dialog.FileName))
            {
                var path = AppDomain.CurrentDomain.BaseDirectory + "\\Images\\Movie\\";
                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
              /*  if (!string.IsNullOrEmpty(Movie.Poster) && File.Exists(Varaible.ImageFullPath+Movie.Poster))
                  File.Delete(Varaible.ImageFullPath+Movie.Poster);*/

                var imageName = Guid.NewGuid().ToString().Replace("-","");  
                var ext = System.IO.Path.GetExtension(_dialog.SafeFileName);
                var fullImageName = imageName + ext;
                File.Copy(_dialog.FileName, path + fullImageName);
                Movie.Poster = fullImageName;
            }
            if (Movie.Id == 0)
            {
                Movie.CreateDate = System.DateTime.Now;
                _context.Movies.Add(Movie);
            }
            else
            {
                var dbModel = _context.Movies.Single(c => c.Id == Movie.Id);
                dbModel.Title = Movie.Title;
                dbModel.Description = Movie.Description;
                dbModel.IMDBRate = Movie.IMDBRate;
                dbModel.DirectorId = (int)cmbDirector.SelectedValue;
                dbModel.Poster = Movie.Poster;  
                dbModel.TagLine = Movie.TagLine;
                dbModel.Year = Movie.Year;
                dbModel.Description = Movie.Description;
            }
            _context.SaveChanges();
            this.DialogResult = true;
        }

        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var directoes = _context.Directors.ToList();
            directoes.Insert(0, new Director() { Id=0, FullName="انتخاب کنید" });
            cmbDirector.ItemsSource = directoes;
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
