using IMDBApp.UserControls;
using System;
using System.Collections.Generic;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace IMDBApp.Views
{
    /// <summary>
    /// Interaction logic for vwConfig.xaml
    /// </summary>
    public partial class vwConfig : Window
    {
        public vwConfig()
        {
            InitializeComponent();
        }

        private void BtnDirectors_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Clear();
            MainGrid.Children.Add(new UCDirectors());
        }

        private void BtnGenres_Click(object sender, RoutedEventArgs e)
        {
            MainGrid.Children.Clear();
            MainGrid.Children.Add(new UCGenres());

        }
    }
}
