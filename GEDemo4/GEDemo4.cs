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
                TryCloseGE();
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

        private void TryCloseGE()
        {
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
            if (CheckGEState(false, "Startup Google Earth"))
            {
                TryStartGE(tabGEViewer);
            }
        }

        private void btnStopGE_Click(object sender, EventArgs e)
        {
            if (CheckGEState(true, "Shutdown Google Earth"))
            {
                TryCloseGE();
            }
        }

        private void btnGESnap_Click(object sender, EventArgs e)
        {
            if (CheckGEState(true, "GESnap"))
            {
                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "JPEG图片(*.jpg)|*.jpg";
                    sfd.AddExtension = true;
                    sfd.CheckPathExists = true;
                    sfd.Title = "保存Google Earth截图";

                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        GEApp.SaveScreenShot(sfd.FileName, 100);
                        msgBar.Show("\'" + sfd.FileName + "\' Saved", tabGEViewer, tabGEViewer.Width / 4, tabGEViewer.Height / 4, 2000);
                    }
                }
            }
        }

        private void btnAPISnap_Click(object sender, EventArgs e)
        {
            if (CheckGEState(true, "APISnap"))
            {

                RECT rect = new RECT();
                NativeMethods.GetClientRect(GEHRenderWnd, out rect);

                // 取得Render DC
                IntPtr hRenderDC = NativeMethods.GetWindowDC(GEHRenderWnd);
                // 创建hBitmap
                IntPtr hBitmap = NativeMethods.CreateCompatibleBitmap(hRenderDC, rect.Width, rect.Height);
                // 创建MEM DC
                IntPtr hMemDC = NativeMethods.CreateCompatibleDC(hRenderDC);
                // 将Bitmap Select到MemDC
                NativeMethods.SelectObject(hMemDC, hBitmap);
                // 直接拷屏
                NativeMethods.BitBlt(hMemDC, 0, 0, rect.Width, rect.Height,
                    hRenderDC, 0, 0, 13369376);

                using (Bitmap bmp = Bitmap.FromHbitmap(hBitmap))
                {
                    using (SaveFileDialog sfd = new SaveFileDialog())
                    {
                        sfd.Filter = "JPEG图片(*.jpg)|*.jpg|PNG图片(*.png)|*.png";
                        sfd.AddExtension = true;
                        sfd.CheckPathExists = true;
                        sfd.Title = "保存Google Earth截图";

                        if (sfd.ShowDialog() == DialogResult.OK)
                        {
                            ImageFormat imgFormat = null;
                            // 默认选择JPG
                            if (sfd.FilterIndex == 0)
                            {
                                imgFormat = ImageFormat.Jpeg;
                            }
                            // 选择PNG
                            else
                            {
                                imgFormat = ImageFormat.Png;
                            }
                            bmp.Save(sfd.FileName, imgFormat);
                            msgBar.Show("\'" + sfd.FileName + "\' Saved", tabGEViewer, tabGEViewer.Width / 4, tabGEViewer.Height / 4, 2000);
                        }
                    }

                    //销毁资源
                    NativeMethods.DeleteDC(hRenderDC);
                    NativeMethods.DeleteDC(hMemDC);
                }
            }
        }

        private bool CheckGEState(bool bExpRun, string caption)
        {
            bool state = true;
            if(bExpRun)
            {
                //期望GE运行而实际并未运行
                if (!isGEStarted)
                {
                    MessageBox.Show("Goolge Earth is not running", caption);
                    state = false;
                }
            }
            else
            {
                //期望GE关闭而实际正在运行
                if(isGEStarted)
                {
                    MessageBox.Show("Goolge Earth is running currently", caption);
                    state = false;
                }
            }

            return state;
        }

    }
}
