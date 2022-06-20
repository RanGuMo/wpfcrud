using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows;

namespace WpfApp2.ViewModel
{

    public class MainViewModel : ViewModelBase   //1.继承ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ClassName = "高二三班";
            Students = new ObservableCollection<Student>();
            Students.Add(new Student() { Name = "张三", Age = "18", Sex = "男" });
            Students.Add(new Student() { Name = "李四", Age = "16", Sex = "女" });
            Students.Add(new Student() { Name = "王五", Age = "17", Sex = "男" });


        }

        private string className;
        public string ClassName
        {
            get { return className; }
            set { className = value; RaisePropertyChanged(); }
        }

        public ObservableCollection<Student> students;
        public ObservableCollection<Student> Students
        {
            get { return students; }
            set { students = value; RaisePropertyChanged(); }
        }

        private RelayCommand<Student> command;
        public RelayCommand<Student> Command
        {
            get
            {
                if (command == null)
                    command = new RelayCommand<Student>((t) => Rcommand(t));
                return command;

            }
        }

        private void Rcommand(Student stu)
        {
            MessageBox.Show($"学生姓名：{stu.Name}学生年龄：{stu.Age}学生性别:{stu.Sex}");
        }


        private RelayCommand updateCommand;

        public RelayCommand UpdateCommand
        {
            get
            {
                if (updateCommand == null)
                    updateCommand = new RelayCommand(() => UpdateText());
                return updateCommand;
            }
        }

        private void UpdateText()
        {
            ClassName = "高三三班";
        }





    }
}