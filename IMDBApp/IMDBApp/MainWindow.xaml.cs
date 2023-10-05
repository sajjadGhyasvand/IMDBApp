using System.Windows;
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
            SvMovieList.LineRight();
        }

        private void BtnMoveRight_OnClick(object sender, RoutedEventArgs e)
        {
            SvMovieList.LineLeft();
        }
    }
}
