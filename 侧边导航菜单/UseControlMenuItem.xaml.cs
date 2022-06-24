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
using 侧边导航菜单.ViewModel;

namespace 侧边导航菜单
{
    /// <summary>
    /// UseControlMenuItem.xaml 的交互逻辑
    /// </summary>
    public partial class UseControlMenuItem : UserControl
    {
        MainWindow _context;
        public UseControlMenuItem(ItemMenu itemMenu, MainWindow context)
        {
            InitializeComponent();
            _context = context;
            //折叠菜单的可视性（没有子项，不可见）
            ExpanderMenu.Visibility = itemMenu.SubItems == null ? Visibility.Collapsed : Visibility.Visible;
            //列表视图项菜单 的可见性（没有子项，可见）
            ListViewItemMenu.Visibility = itemMenu.SubItems == null ? Visibility.Visible : Visibility.Collapsed;

            this.DataContext = itemMenu;
        }

        private void ListViewMenu_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
             _context.SwitchScreen(((SubItem)((ListView)sender).SelectedItem).Screen);
        }
    }
}
