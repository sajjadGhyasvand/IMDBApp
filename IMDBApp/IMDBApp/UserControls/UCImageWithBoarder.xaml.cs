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
    /// Interaction logic for UCImageWithBoarder.xaml
    /// </summary>
    public partial class UCImageWithBoarder : UserControl
    {
        #region DP Properties
        public  ImageSource Source
        {
            get { return (ImageSource)GetValue(ImageSourceProperty); }
            set { SetValue(ImageSourceProperty, value); }
        }
        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(UCImageWithBoarder), new PropertyMetadata(null));



        public object Value 
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(object), typeof(UCImageWithBoarder), new PropertyMetadata(null));  
        #endregion
        public UCImageWithBoarder()
        {
            InitializeComponent();
            this.DataContext = this;
        }
    }
}
