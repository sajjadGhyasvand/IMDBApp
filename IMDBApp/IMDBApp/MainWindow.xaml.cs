using DataLayer.Context;
using DataLayer.Entities;
using IMDBApp.UserControls;
using IMDBApp.Utilities;
using IMDBApp.Views;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace IMDBApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        private MovieContext _context = new MovieContext();
        Movie _movie = new Movie();
        public MainWindow()
        {
            InitializeComponent();
            /*foreach (UIElement child in SpMovieList.Children)
            {
                child.MouseDown += Child_MouseDown;
                child.MouseWheel += Child_MouseWheel;
            }     */
        }
        private void Child_MouseWheel(object sender, MouseWheelEventArgs e)
        {
            if (e.Delta > 0)
                SvMovieList.LineLeft();
            else
                SvMovieList.LineRight();
        }
        private void Child_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (MainGridPanel.Visibility != Visibility.Visible)
            {
                imgBackgorundDefault.Visibility = Visibility.Hidden;
                imgBackground.Visibility = Visibility.Visible;
                MainGridPanel.Visibility = Visibility.Visible;
            }
            var uc = (UserControl)sender;
            if (uc.Content is Border border)
                if (border.Tag is Movie movie)
                {
                    this.DataContext = movie;
                    _movie = movie;
                }
                else
                    MessageBox.Show($"Tag Value: {border.Tag}");

        }
        private void BtnClose_OnClick(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void BtmMinus_OnClick(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void RecTop_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
                this.DragMove();

            if (e.MiddleButton == MouseButtonState.Pressed)
                this.WindowState = this.WindowState == WindowState.Maximized
                    ? WindowState.Normal
                    : WindowState.Maximized;
        }

        private void BtnMoveLeft_OnClick(object sender, RoutedEventArgs e)
        {
            SvMovieList.LineLeft();
        }

        private void BtnMoveRight_OnClick(object sender, RoutedEventArgs e)
        {
            SvMovieList.LineRight();
        }

        private void BtnAddMovie_Click(object sender, RoutedEventArgs e)
        {
            var vw = new vwAddOrEditMovie()
            {
                Owner = this,
            };
            if (vw.ShowDialog() == true)
                LoadMovies();
            vw.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = _movie;
            LoadMovies();
        }
        private void LoadMovies()
        {
            SpMovieList.Children.Clear();
            foreach (var movie in _context.Movies)
            {
                var path = Varaible.ImageFullPath;
                BitmapImage poster = null;
                if (!string.IsNullOrEmpty(movie.Poster) && File.Exists(path + movie.Poster))
                    poster = new BitmapImage(new Uri(path + movie.Poster));
                else
                    poster = new BitmapImage(new Uri(path + Varaible.DeaufultPoster));
                var uc = new UCImageWithBoarder() { Value=movie, Source=poster };
                uc.MouseWheel += Child_MouseWheel;
                uc.MouseDown += Child_MouseDown;
                SpMovieList.Children.Add(uc);
            }
        }

        private void BtnEditMovie_Click(object sender, RoutedEventArgs e)
        {
            var vw = new vwAddOrEditMovie()
            {
                Owner = this,
                Movie = _movie,
            };
            vw.Title = $"ویرایش {_movie.Title}";
            vw.btnAdd.Content = "ویرایش";

            var result = vw.ShowDialog();
            DataContext = _movie = _context.Movies.AsNoTracking().Single(c=>c.Id == _movie.Id);
            if (result == true)
                LoadMovies();
        }

        private void BtnDeleteMovie_Click(object sender, RoutedEventArgs e)
        {
            _context.Movies.Remove(_movie);
            _context.SaveChanges();
        }

        private void btnConfig_Click(object sender, RoutedEventArgs e)
        {
            var vw = new vwConfig() { Owner = this, WindowStartupLocation = WindowStartupLocation.CenterOwner };
            vw.ShowDialog();
        }
    }
}
