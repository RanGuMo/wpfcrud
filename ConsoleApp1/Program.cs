using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    public class Program
    {
        static void Main(string[] args)
        {
            string message1 = "你好！";  
            string message2 = "小明！";  
            SendMessage(message1,ref message2);
            Console.WriteLine(message1); //返回值1
            Console.WriteLine(message2); //返回值2
            Console.Read();//将当前窗体保留

        }
        public static string SendMessage(string message1,ref string message2) {

            message2 = message2 + "对message2进行处理";
            return message1;
           
        }

    }
}
