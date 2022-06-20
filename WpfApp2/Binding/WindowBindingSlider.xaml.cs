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

namespace WpfApp2.Binding
{
    /// <summary>
    /// WindowBindingSlider.xaml 的交互逻辑
    /// </summary>
    public partial class WindowBindingSlider : Window
    {
        public WindowBindingSlider()
        {
            InitializeComponent();
            this.DataContext = new Test() { Name = "小明" };
        }

        public class Test{
            public string Name { get; set; }

         }



    }
}
