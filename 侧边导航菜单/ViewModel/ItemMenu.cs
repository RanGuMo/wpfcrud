using MaterialDesignThemes.Wpf;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace 侧边导航菜单.ViewModel
{
    public class ItemMenu
    {
        public string Header { get; set; }
        public PackIconKind Icon { get; set; }
        public List<SubItem> SubItems { get; set; }
        public UserControl Screen { get; set; }


        public ItemMenu(string header,List<SubItem> subItems,PackIconKind icon)
        {
            this.Header = header;
            this.SubItems = subItems;
            this.Icon = icon;
        }

        public ItemMenu(string header, UserControl screen, PackIconKind icon)
        {
            this.Header = header;
            this.Screen = screen;
            this.Icon = icon;
        }


    }
}
