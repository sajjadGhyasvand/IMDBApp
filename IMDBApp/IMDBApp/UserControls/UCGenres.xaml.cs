using DataLayer.Context;
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

namespace IMDBApp.UserControls
{
    /// <summary>
    /// Interaction logic for UCGenres.xaml
    /// </summary>
    public partial class UCGenres : UserControl
    {
        MovieContext _context = new();
        public UCGenres()
        {
            InitializeComponent();
            GrdList.ItemsSource =  _context.Genres.ToList();

        }
    }
}
