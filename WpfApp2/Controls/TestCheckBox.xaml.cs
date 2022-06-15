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
using System.Windows.Shapes;

namespace WpfApp2.Controls
{
    /// <summary>
    /// TestCheckBox.xaml 的交互逻辑
    /// </summary>
    public partial class TestCheckBox : Window
    {
        public TestCheckBox()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            UIElementCollection children = gridMain.Children;
            StringBuilder sbf = new StringBuilder("我的选课为:");
            foreach (UIElement item in children)
            {
                if (item is CheckBox && (item as CheckBox).IsChecked.Value)
                {
                    sbf.Append((item as CheckBox).Content + ",");
                }
            }
            MessageBox.Show(sbf.ToString());

        }
    }
}
