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
    /// WindowCellTemplate.xaml 的交互逻辑
    /// </summary>
    public partial class WindowCellTemplate : Window
    {
        public WindowCellTemplate()
        {
            InitializeComponent();

            List<Student> students = new List<Student>();
            students.Add(new Student() { UserName = "小王", ClassName = "高二三班", Address = "广州市" });
            students.Add(new Student() { UserName = "小李", ClassName = "高三六班", Address = "清远市" });
            students.Add(new Student() { UserName = "小张", ClassName = "高一一班", Address = "深圳市" });
            students.Add(new Student() { UserName = "小黑", ClassName = "高一三班", Address = "赣州市" });
            gd.ItemsSource = students;


        }

        public class Student{ 
        public string UserName { get; set; }
        public string ClassName { get; set; }
        public string Address { get; set; }
        }




    }
}
