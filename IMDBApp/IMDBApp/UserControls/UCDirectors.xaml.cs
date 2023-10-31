using DataLayer.Context;
using DataLayer.Entities;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace IMDBApp.UserControls
{
    /// <summary>
    /// Interaction logic for UCDirectors.xaml
    /// </summary>
    public partial class UCDirectors : UserControl
    {
        Director _directors = new();
        MovieContext _context = new();
        public UCDirectors()
        {
            InitializeComponent();
            LoadGrid();
            SpAddDirector.DataContext = _directors;
        }

        private void BtnAddDirector_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            _context.Directors.Add(_directors);
            _context.SaveChanges();
            MessageBox.Show("رکورد جدید با موفقیت ثبن گردید");
            LoadGrid();
        }

        private void LoadGrid()
        {
            GrdList.ItemsSource =  _context.Directors.ToList();
        }

        private void BtnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button btn)
            {
                if (btn.Tag is Director director)
                {
                    _context.Directors.Update(director);
                    _context.SaveChanges();
                    MessageBox.Show("رکورد مورد نظر با موفقیت ویرایش شد");
                    LoadGrid();
                }
                 
            }
        }

        private void BtnDelete_Click(object sender, RoutedEventArgs e)
        {
            var msgBox =  MessageBox.Show("آیا از حذف این رکورد اطمینان دارید؟", "حذف کارگران", MessageBoxButton.YesNo);
            if (msgBox == MessageBoxResult.Yes)
            {
                if (sender is Button btn)
                {
                    if (btn.Tag is Director director)
                    {
                        _context.Directors.Remove(director);
                        _context.SaveChanges();
                        MessageBox.Show("رکورد مورد نظر با موفقیت حذف شد");
                        LoadGrid();
                    }

                }
            }
            
        }
    }
}
