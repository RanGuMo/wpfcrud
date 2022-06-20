using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.ObjectModel;
using System.Windows;

namespace WpfApp2.ViewModel
{

    public class MainViewModel : ViewModelBase   //1.�̳�ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel()
        {
            ClassName = "�߶�����";
            Students = new ObservableCollection<Student>();
            Students.Add(new Student() { Name = "����", Age = "18", Sex = "��" });
            Students.Add(new Student() { Name = "����", Age = "16", Sex = "Ů" });
            Students.Add(new Student() { Name = "����", Age = "17", Sex = "��" });


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
            MessageBox.Show($"ѧ��������{stu.Name}ѧ�����䣺{stu.Age}ѧ���Ա�:{stu.Sex}");
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
            ClassName = "��������";
        }





    }
}