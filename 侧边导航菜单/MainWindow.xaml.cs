using MaterialDesignThemes.Wpf;
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
using 侧边导航菜单.View;
using 侧边导航菜单.ViewModel;

namespace 侧边导航菜单
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();


            var item0 = new ItemMenu("试管贴标", new UserControl(), PackIconKind.Register);

            //注册子菜单
            var menuBase = new List<SubItem>();
            menuBase.Add(new SubItem("打印记录",new UserControlPrintRecord()));
            menuBase.Add(new SubItem("打印统计",new UserControlPrintStatistics()));
            menuBase.Add(new SubItem("日志记录"));
            //注册父菜单 并 将子菜单加入进来
            var item1 = new ItemMenu("基础信息", menuBase, PackIconKind.Register);

            //注册子菜单
            var menuBaseSet = new List<SubItem>();
            menuBaseSet.Add(new SubItem("颜色设置"));
            menuBaseSet.Add(new SubItem("项目设置"));
            menuBaseSet.Add(new SubItem("打印设置"));
            menuBaseSet.Add(new SubItem("基础设置"));
            menuBaseSet.Add(new SubItem("试管颜色"));
            //注册父菜单 并 将子菜单加入进来
            var item2 = new ItemMenu("基础设置", menuBaseSet, PackIconKind.Register);

            //注册子菜单
            var deviceManagement = new List<SubItem>();
            deviceManagement.Add(new SubItem("设备设置"));
            deviceManagement.Add(new SubItem("电机设置"));
            deviceManagement.Add(new SubItem("轨道数据"));
            //注册父菜单 并 将子菜单加入进来
            var item3 = new ItemMenu("设备管理", deviceManagement, PackIconKind.Register);

            //注册子菜单
            var systemManagement = new List<SubItem>();
            systemManagement.Add(new SubItem("用户管理"));
            //注册父菜单 并 将子菜单加入进来
            var item4 = new ItemMenu("系统管理", systemManagement, PackIconKind.Register);

            Menu.Children.Add(new UseControlMenuItem(item0,this));
            Menu.Children.Add(new UseControlMenuItem(item1,this));
            Menu.Children.Add(new UseControlMenuItem(item2,this));
            Menu.Children.Add(new UseControlMenuItem(item3,this));
            Menu.Children.Add(new UseControlMenuItem(item4,this));



        }

        /// <summary>
        /// 切换导航
        /// </summary>
        /// <param name="sender"></param>
        internal void SwitchScreen(object sender)
        {
            var screen = ((UserControl)sender);

            if (screen != null)
            {
                StackPanelMain.Children.Clear();
                StackPanelMain.Children.Add(screen);
            }
        }


    }
}
