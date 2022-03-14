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
            //����������ʱ����ִ��,���������ʱ�����ҵ�QueryCommand
            QueryCommand = new RelayCommand(Query);
            //���������ʱ�����ҵ�ResetCommand
            ResetCommand = new RelayCommand(() =>
            {
                //������þ�����ı���
                Search = string.Empty;
                //����Query����
                this.Query();
            });
            ////////�޸ĺ�ɾ������////////////
            EditCommand = new RelayCommand<int>(t => Edit(t));
            DelCommand = new RelayCommand<int>(t => Del(t));
            ////////�޸ĺ�ɾ������////////////

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
        /// ��������
        /// </summary>
        public RelayCommand QueryCommand { get; set; }
        /// <summary>
        /// ��������
        /// </summary>
        public RelayCommand ResetCommand { get; set; }
        /// <summary>
        /// �޸�����
        /// </summary>
        public RelayCommand<int> EditCommand { get; set; }
        /// <summary>
        /// ɾ������
        /// </summary>
        public RelayCommand<int> DelCommand { get; set; }
        /// <summary>
        /// �������
        /// </summary>
        public RelayCommand AddCommand { get; set; }


        #endregion
        //���ҹ��ܿ�������Query����
        public void Query()
        {
            // //���ҹ��ܿ�������Query����
            // var models = localDB.GetStudents();  ��Ϊ����
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
                var r = MessageBox.Show($"ȷ��ɾ����ǰ�û���{model.Name}?","������ʾ",MessageBoxButton.OK,MessageBoxImage.Question);
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