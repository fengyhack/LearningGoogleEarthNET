using System;
using System.Drawing;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using EARTHLib;
using System.IO;
using System.Diagnostics;

namespace GEDemo1
{
    public partial class GEDemo1 : Form
    {
        private bool isGEStarted = false;
        private ApplicationGE GEApp;
        private string ssFile;
        public GEDemo1()
        {
            InitializeComponent();
        }

        private void StartGE()
        {
            if (isGEStarted)
            {
                return;
            }

            try
            {
                //启动GE
                GEApp = (ApplicationGEClass)Marshal.GetActiveObject("GoogleEarth.Application");

                isGEStarted = true;
            }
            catch
            {
                GEApp = new ApplicationGEClass();

                isGEStarted = true;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StartGE();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ssFile = Path.Combine(Application.StartupPath, System.DateTime.Now.ToString("GES_yyyyMMddHHmmss")+".jpg");

            try
            {
                //quality的取值范围在(0,100)之间，质量越高，quality越大
                GEApp.SaveScreenShot(ssFile, 100);

                //载入刚才的图像
                pictureBox1.Image = Bitmap.FromFile(ssFile);
            }
            catch (Exception ex)
            {
                MessageBox.Show("保存截屏图像时发生错误：" + ex.ToString());
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //首先杀掉GoogleEarth进程
            Process[] geProcess = Process.GetProcessesByName("GoogleEarth");
            foreach (var p in geProcess)
            {
                p.Kill();
            }

            //然后关闭窗口，退出程序
            this.Close();
            Application.Exit();
        }
    
    }
}
