using Microsoft.Win32;
using PaddleOCRSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfOCR
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnOCR_Click(object sender, RoutedEventArgs e)
        {
            StartDistinguish();
        }

        private void BtnClose_Click(object sender, RoutedEventArgs e)
        {
            ImgPreview.Source = null;
            TxtPreview.Text = "";
        }

        /// <summary>
        /// 调用核心
        /// </summary>
        private void StartDistinguish()
        {
            OpenFileDialog openFile = new()
            {
                Filter = "图片(*.bmp;*.jpg;*.jpeg;*.png)|*.bmp;*.jpg;*.jpeg;*.png"
            };

            if (!(bool)openFile.ShowDialog()) return;

            Dispatcher.BeginInvoke(new Action(() =>
            {
                ImgPreview.Source = new BitmapImage(new Uri(openFile.FileName, UriKind.RelativeOrAbsolute));
            }));

            Task.Run(() =>
            {
                var imagebyte = File.ReadAllBytes(openFile.FileName);

                Bitmap bitmap = new(new MemoryStream(imagebyte));

                OCRModelConfig? config = null;

                OCRParameter oCRParameter = new();
                OCRResult ocrResult = new();

                using (PaddleOCREngine engine = new PaddleOCREngine(config, oCRParameter))
                {
                    ocrResult = engine.DetectText(bitmap);
                }
                if (ocrResult != null)
                {
                    Dispatcher.BeginInvoke(new Action(() =>
                    {
                        TxtPreview.Text = ocrResult.Text;
                    }));
                }
            });
        }




    }
}
