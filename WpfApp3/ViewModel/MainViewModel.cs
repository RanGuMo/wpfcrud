using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;
using WpfApp3.DB;
using WpfApp3.Models;
using WpfApp3.Views;

namespace WpfApp3.ViewModel
{
    public class MainViewModel : ViewModelBase
    {

        public MainViewModel()
        {
            localDB = new LocalDB();
            //当程序启动时，会执行,当点击查找时，会找到QueryCommand
            QueryCommand = new RelayCommand(Query);
            //当点击重置时，会找到ResetCommand
            ResetCommand = new RelayCommand(() =>
            {
                //点击重置就清空文本框
                Search = string.Empty;
                //调用Query方法
                this.Query();
            });
            ////////修改和删除命令////////////
            EditCommand = new RelayCommand<int>(t => Edit(t));
            DelCommand = new RelayCommand<int>(t => Del(t));
            ////////修改和删除命令////////////

            AddCommand = new RelayCommand(Add);
        }
        LocalDB localDB;
        private string search = string.Empty;
        public string Search { get { return search; } set { search = value; RaisePropertyChanged(); } }

        private ObservableCollection<Student> gridModelList;

        public ObservableCollection<Student> GridModelList
        {
            get { return gridModelList; }
            set { gridModelList = value; RaisePropertyChanged(); }
        }

        
        #region Command
        /// <summary>
        /// 查找命令
        /// </summary>
        public RelayCommand QueryCommand { get; set; }
        /// <summary>
        /// 重置命令
        /// </summary>
        public RelayCommand ResetCommand { get; set; }
        /// <summary>
        /// 修改命令
        /// </summary>
        public RelayCommand<int> EditCommand { get; set; }
        /// <summary>
        /// 删除命令
        /// </summary>
        public RelayCommand<int> DelCommand { get; set; }
        /// <summary>
        /// 添加命令
        /// </summary>
        public RelayCommand AddCommand { get; set; }


        #endregion
        //查找功能可以重用Query方法
        public void Query()
        {
            // //查找功能可以重用Query方法
            // var models = localDB.GetStudents();  改为以下
            var models = localDB.GetStudentByName(Search);
            GridModelList = new ObservableCollection<Student>();
            if (models != null)
            {
                models.ForEach(arg =>
                {
                    GridModelList.Add(arg);
                });

            }
        }

        public void Edit(int id)
        {
            var model = localDB.GetStudentById(id);
            if (model!=null)
            {
                UserView view = new UserView(model);
                var r = view.ShowDialog();
                if (r.Value)
                {
                    var newModel = GridModelList.FirstOrDefault(t=>t.Id==model.Id);
                    if (newModel != null)
                    {
                        newModel.Name = model.Name;
                    }
                }
            }

        }
        public void Del(int id)
        {
            var model =  localDB.GetStudentById(id);
            if (model != null)
            {
                var r = MessageBox.Show($"确认删除当前用户：{model.Name}?","操作提示",MessageBoxButton.OK,MessageBoxImage.Question);
                if (r == MessageBoxResult.OK)
                    localDB.DelStudent(model.Id);
                this.Query();
            }

        }

        public void Add()
        {
            Student student = new Student();
            UserView userView = new UserView(student);
            var r = userView.ShowDialog();
            if (r.Value)
            {
                student.Id= localDB.Students.Max(t => t.Id) + 1;
                //student.Id = GridModelList.Max(t => t.Id)+1;

                localDB.AddStudent(student);
                Search = string.Empty;
                
                this.Query();
            }
        }


    }
}