using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp3.Models;

namespace WpfApp3.DB
{
    public class LocalDB
    {
        /// <summary>
        /// 定义LocalDB方法
        /// </summary>
        public LocalDB()
        {
            Init();
        }

        private List<Student> Students;
        /// <summary>
        /// 定义初始化数据的方法
        /// </summary>
        public void Init()
        {
            Students = new List<Student>();
            for (int i = 0; i < 30; i++)
            {
                Students.Add(new Student()
                {
                    Id = i,
                    Name = $"Sample{i}"
                });
            }
        }
        /// <summary>
        /// 获取学生信息的方法
        /// </summary>
        /// <returns></returns>
        public List<Student> GetStudents()
        {
            return Students;
        }
        /// <summary>
        /// 添加学生信息的方法
        /// </summary>
        /// <param name="stu"></param>
        public void AddStudent(Student stu)
        {
            Students.Add(stu);
        }
        /// <summary>
        /// 删除学生信息的方法
        /// </summary>
        /// <param name="id"></param>
        public void DelStudent(int id)
        {
            var model = Students.FirstOrDefault(t => t.Id == id);
            if (model != null)
            {
                Students.Remove(model);
            }
        }
        /// <summary>
        /// 根据学生名字进行模糊查询
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public List<Student> GetStudentByName(string name)
        {
            return Students.Where(q=>q.Name.Contains(name)).ToList();
        }

    }



}


