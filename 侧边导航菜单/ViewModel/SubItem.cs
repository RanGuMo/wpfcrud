using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace 侧边导航菜单.ViewModel
{
    public class SubItem
    {
        public string Name { get; set; }
        public UserControl Screen { get; set; }

        public SubItem(string name, UserControl screen=null)
        {
            Name = name;
            Screen = screen;
        }
    }
}
