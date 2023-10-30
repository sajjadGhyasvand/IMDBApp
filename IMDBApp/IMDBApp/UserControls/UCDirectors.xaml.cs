using DataLayer.Context;
using System.Linq;
using System.Windows.Controls;

namespace IMDBApp.UserControls
{
    /// <summary>
    /// Interaction logic for UCDirectors.xaml
    /// </summary>
    public partial class UCDirectors : UserControl
    {
        MovieContext _context = new();
        public UCDirectors()
        {
            InitializeComponent();
            GrdList.ItemsSource =  _context.Directors.Select(c => new
            {
                c.Id,
                c.FullName,
                c.Bio,
            }).ToList();
        }
    }
}
