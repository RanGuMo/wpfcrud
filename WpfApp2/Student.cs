using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public class Student : ViewModelBase
    {
        private string name;
        private string age;
        private string sex;

        public string Name
        {
            get { return name; }
            set { name = value; RaisePropertyChanged(); }
        }


        public string Age
        {
            get { return age; }
            set { age = value; RaisePropertyChanged(); }
        }


        public string Sex
        {
            get { return sex; }
            set { sex = value; RaisePropertyChanged(); }
        }
    }
}
