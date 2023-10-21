using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace IMDBApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
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

        }
    }
}
