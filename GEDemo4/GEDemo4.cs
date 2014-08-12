using System;
using System.Windows.Forms;
using System.ComponentModel;
using EARTHLib;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;


namespace GEDemo4
{
    public partial class GEDemo4 : Form
    {
        static readonly Int32 WM_QUIT = 0x0012;
        private IntPtr GEHMainWnd = (IntPtr)0;
        private IntPtr GEHRenderWnd = (IntPtr)0;

        private ApplicationGE GEApp;
        private bool isGEStarted;

        public GEDemo4()
        {
            InitializeComponent();
            isGEStarted = false;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            if (isGEStarted)
            {
                ShutDownGE();
            }
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);

            ResizeGERenderWindow(tabGEViewer);
        }

        #region GEOperations

        private void TryStartGE(Control parentDocker)
        {
            if (isGEStarted)
            {
                MessageBox.Show("Google Earth is running currently", "Warning");
                return;
            }
                try
                {
                    GEApp = new ApplicationGE();

                    GEHMainWnd = (IntPtr)GEApp.GetMainHwnd();
                    //隐藏GoogleEarth主窗口
                    NativeMethods.SetWindowPos(GEHMainWnd, NativeMethods.HWND_BOTTOM,
                        0, 0, 0, 0, NativeMethods.SWP_NOSIZE | NativeMethods.SWP_HIDEWINDOW);

                    GEHRenderWnd = (IntPtr)GEApp.GetRenderHwnd();
                    //将渲染窗口嵌入到父窗体
                    NativeMethods.MoveWindow(GEHRenderWnd, 0, 0, parentDocker.Width, parentDocker.Height, true);
                    NativeMethods.SetParent(GEHRenderWnd, parentDocker.Handle);

                    isGEStarted = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Starting GE");
                }
        }

        private void ShutDownGE()
        {
            if (!isGEStarted)
            {
                MessageBox.Show("Google Earth is not running currently", "Warning");
                return;
            }

            try
            {
                //杀掉GoogleEarth进程
                Process[] geProcess = Process.GetProcessesByName("GoogleEarth");
                foreach (var p in geProcess)
                {
                    p.Kill();
                }
                //清除内容
                GEApp = null;
                GEHMainWnd = (IntPtr)0;
                GEHRenderWnd = (IntPtr)0;
                isGEStarted = false;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Shutdown GE");
            }
        }

        private void ResizeGERenderWindow(Control parentDocker)
        {
            if (!isGEStarted)
            {
                return;
            }

            //
        }

        #endregion GEOperations
        

        private void btnStartGE_Click(object sender, EventArgs e)
        {
            TryStartGE(tabGEViewer);
        }

        private void btnStopGE_Click(object sender, EventArgs e)
        {
            ShutDownGE();
        }

    }
}
