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
    /// PageWindow.xaml 的交互逻辑
    /// </summary>
    public partial class PageWindow : Window
    {
        public PageWindow()
        {
            InitializeComponent();

            PageModel pageModel = new PageModel();
            pageModel.ClassName = "高二三班";
            pageModel.Students = new List<Student>();
            pageModel.Students.Add(new Student() { Name = "张三", Age="18",Sex = "男"});
            pageModel.Students.Add(new Student() { Name = "李四", Age="20",Sex = "女"});
            pageModel.Students.Add(new Student() { Name = "王五", Age="19",Sex = "男"});

            this.DataContext = pageModel;

        }

        public class PageModel
        {
            public string ClassName { get; set; }
            public List<Student> Students { get; set; }
        }

        public class Student
        {
            public string Name { get; set; }
            public string Age { get; set; }
            public string Sex { get; set; }
        }


    }
}
