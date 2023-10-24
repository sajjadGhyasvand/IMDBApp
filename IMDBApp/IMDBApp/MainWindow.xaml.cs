using DataLayer.Context;
using IMDBApp.UserControls;
using IMDBApp.Views;
using System;
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
        public MainWindow()
        {
                InitializeComponent();
                foreach (UIElement child in SpMovieList.Children)
                {
                    child.MouseDown += Child_MouseDown;
                    child.MouseWheel += Child_MouseWheel;
                }      
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
            var uc = (UserControl)sender;
            if (uc.Content is Border border)
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
            {
                
            }
            vw.ShowDialog();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadMovies();
        }
        private void LoadMovies()
        {
            foreach (var movie in _context.Movies)
            {
                var path = AppDomain.CurrentDomain.BaseDirectory + "\\Images\\Movie\\";
                var poster = new BitmapImage(new Uri(path + movie.Poster));
                var uc = new UCImageWithBoarder() { Value=movie, Source=poster };
                uc.MouseWheel += Child_MouseWheel;
                uc.MouseDown += Child_MouseDown;

                SpMovieList.Children.Add(uc);
            }
        }
    }
}
