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

namespace WpfApp2.Template
{
    /// <summary>
    /// WindowItemsControl.xaml 的交互逻辑
    /// </summary>
    public partial class WindowItemsControl : Window
    {
        public WindowItemsControl()
        {
            InitializeComponent();
            List<Test> tests = new List<Test>();
            tests.Add(new Test() { Code = "1" });
            tests.Add(new Test() { Code = "2" });
            tests.Add(new Test() { Code = "3" });
            tests.Add(new Test() { Code = "4" });
            tests.Add(new Test() { Code = "6" });
            ic.ItemsSource = tests;

        }

        public class Test {
            public string Code;
        }
    }
}
