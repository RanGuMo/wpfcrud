using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        private const Int32 WM_SYSCOMMAND = 274;
        private const UInt32 SC_CLOSE = 61536;
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool PostMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool PostMessage(IntPtr hWnd, int Msg, uint wParam, uint lParam);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern bool PostMessage(IntPtr hWnd, uint Msg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        private static extern IntPtr FindWindow(string lpClassName, string? lpWindowName);
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern int RegisterWindowMessage(string lpString);

        public static void HideInputPanel()
        {
            IntPtr TouchhWnd = new IntPtr(0);
            TouchhWnd = FindWindow("IPTip_Main_Window", null);
            if (TouchhWnd == IntPtr.Zero)
                return;
            PostMessage(TouchhWnd, WM_SYSCOMMAND, SC_CLOSE, 0);
        }

        bool openKeyBoard = false;

        private void Form3_Load(object sender, EventArgs e)
        {
            panel1.Visible = false;
            lbl_0.Click += new EventHandler(lbl_Click);
            lbl_1.Click += new EventHandler(lbl_Click);
            lbl_2.Click += new EventHandler(lbl_Click);
            lbl_3.Click += new EventHandler(lbl_Click);
            lbl_4.Click += new EventHandler(lbl_Click);
            lbl_5.Click += new EventHandler(lbl_Click);
            lbl_6.Click += new EventHandler(lbl_Click);
            lbl_7.Click += new EventHandler(lbl_Click);
            lbl_8.Click += new EventHandler(lbl_Click);
            lbl_9.Click += new EventHandler(lbl_Click);

        }

        private void lbl_Click(object? sender, EventArgs e)
        {

            Label l = (Label)sender;
            textBox1.Text += l.Name.Substring(4, 1);
            textBox1.SelectionStart = textBox1.Text.Length;

        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            //this.panel1.Visible = true;
            //System.Diagnostics.Process.Start(@"C:\WINDOWS\system32\osk.exe");//调出屏幕键盘

        }

        private void button1_Click(object sender, EventArgs e)
        {
            byte[] head = new byte[] { 0x7e };
            byte[] type = new byte[] { 0x00 };
            byte[] content = Encoding.Default.GetBytes("ABCDEGF");
            byte[] last = new byte[] { 0x23 };
            byte[] full = new byte[head.Length + type.Length + content.Length + last.Length];

           byte[] full1 = head.Concat(type).Concat(content).Concat(last).ToArray();//这种linq方法适用于所有数组，狠，一句话搞定
            head.CopyTo(full, 0);
            type.CopyTo(full, head.Length);
            content.CopyTo(full, head.Length + type.Length);
            last.CopyTo(full, head.Length + type.Length + content.Length);
            Console.WriteLine(full[0]);
            Console.WriteLine(full[1]);


            string s = "0a";
            int w = Convert.ToInt32(s,16);
            
            MessageBox.Show(w.ToString());
            Dictionary<int,string> map = new Dictionary<int,string>();
            map.Add(1,"98");
          
        }
    }
}
