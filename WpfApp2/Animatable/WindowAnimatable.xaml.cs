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

namespace WpfApp2.Animatable
{
    /// <summary>
    /// WindowAnimatable.xaml 的交互逻辑
    /// </summary>
    public partial class WindowAnimatable : Window
    {
        public WindowAnimatable()
        {
            InitializeComponent();
        }

        private void ThicknessAnimation_Completed(object sender, EventArgs e)
        {

        }
    }
}
