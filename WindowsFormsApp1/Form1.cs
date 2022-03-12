using log4net;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private static ILog log = LogManager.GetLogger(typeof(Form1));

        private void button1_Click(object sender, EventArgs e)
        {
             

            string msg = "操作完成.";
            log.Debug(msg);
            MessageBox.Show(msg, "提示", MessageBoxButtons.OK);
       

    }

        //记录直线或者曲线的对象
        private System.Drawing.Drawing2D.GraphicsPath mousePath = new System.Drawing.Drawing2D.GraphicsPath();
        //画笔透明度
        private int myAlpha = 100;
        //画笔颜色对象
        private Color myUserColor = new Color();
        //画笔宽度
        private int myPenWidth = 3;
        //签名的图片对象
        public Bitmap SavedBitmap;

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                try
                {
                    mousePath.AddLine(e.X, e.Y, e.X, e.Y);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            pictureBox1.Invalidate();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == System.Windows.Forms.MouseButtons.Left)
            {
                mousePath.StartFigure();
            }
        }

        //颜色选择
        Color c;
        private void button1_Click_2(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
            c = colorDialog1.Color;
            //MessageBox.Show(c.Name);
        }
        //实现绘画
        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            try
            {

              //  myUserColor = System.Drawing.Color.Blue;
                myUserColor = c;
                myAlpha = 255;//透明度
                //Pen CurrentPen = new Pen(Color.FromArgb(myAlpha, myUserColor), myPenWidth);

                // Convert.ToInt32(numericUpDown1.Value)   调整画笔宽度
                Pen CurrentPen = new Pen(Color.FromArgb(myAlpha, myUserColor), Convert.ToInt32(numericUpDown1.Value));
                e.Graphics.DrawPath(CurrentPen, mousePath);
            }
            catch { }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            pictureBox1.CreateGraphics().Clear(Color.White);
            mousePath.Reset();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SavedBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.DrawToBitmap(SavedBitmap, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
            //this.DialogResult = System.Windows.Forms.DialogResult.OK;

            Console.WriteLine(SavedBitmap.ToString());
            //Bitmap  b = SaveImage(pictureBox1);
            #region 保存为透明的png图片

            Bitmap bmp = SavedBitmap;
            BitmapData data = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, bmp.PixelFormat);
            int length = data.Stride * data.Height;
            IntPtr ptr = data.Scan0;
            byte[] buff = new byte[length];
            Marshal.Copy(ptr, buff, 0, length);
            for (int i = 3; i < length; i += 4)
            {
                if (buff[i - 1] >= 230 && buff[i - 2] >= 230 && buff[i - 3] >= 230)
                {
                    buff[i] = 0;
                }
            }
            Marshal.Copy(buff, 0, ptr, length);
            bmp.UnlockBits(data);
            bmp.Save("D:\\zhenglibing.png", ImageFormat.Png);

            #endregion

            Bitmap b = SaveImage(pictureBox1);
            MemoryStream ms = new MemoryStream();
            SavedBitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] bytes = ms.GetBuffer();  //byte[]   bytes=   ms.ToArray(); 这两句都可以，至于区别么，下面有解释
            ms.Close();

            var count= Connection().Insertable(new inin() { name= bytes }).ExecuteCommand();


        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form1 dlg = new Form1();
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.pictureBox1.Image = dlg.SavedBitmap;
            }
        }


        public Bitmap SaveImage(PictureBox pictureBox1)
        {
            Bitmap SavedBitmap = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.DrawToBitmap(SavedBitmap, new Rectangle(0, 0, pictureBox1.Width, pictureBox1.Height));
            return SavedBitmap;
        }

        /////////////////////////////////////////////////////////////////////////////
        public SqlSugarClient Connection()
        {
            //创建数据库对象
            SqlSugarClient db = new SqlSugarClient(new ConnectionConfig()
            {

                //ConnectionString = "data source =./sqliteDB/HD_DataBase.db",
                ConnectionString = "data source =C:/HD_DataBase.db",

                DbType = SqlSugar.DbType.Sqlite,
                IsAutoCloseConnection = true
            });

            db.Aop.OnLogExecuting = (sql, pars) =>
            {
                Console.WriteLine("****************************************************************************************************");
                Console.WriteLine(sql);//输出sql,查看执行sql
                Console.WriteLine("****************************************************************************************************");
            };



            return db;
         
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                Connection().Open();
                MessageBox.Show("连接成功");
            }
            catch (Exception)
            {

                MessageBox.Show("连接失败");
            }
        }

        // 窗体加载事件 
        private void Form1_Load(object sender, EventArgs e)
        {


            var dt = Connection().Queryable<inin>().Select(o => o).ToDataTable();
            byte[] sss = (byte[])dt.Rows[0]["name"];
            MemoryStream ms1 = new MemoryStream(sss);
            Bitmap bm = (Bitmap)Image.FromStream(ms1);
            ms1.Close();
           // pictureBox2.Image = bm;

            this.dataGridView1.DataSource = dt;
        }
    }
}
