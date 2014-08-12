using System;
using System.Windows.Forms;
using System.ComponentModel;
using EARTHLib;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;
using System.Drawing.Drawing2D;


namespace GEDemo4
{
    public partial class GEDemo4 : Form
    {
        private IntPtr GEHMainWnd = (IntPtr)0;
        private IntPtr GEHRenderWnd = (IntPtr)0;

        private ApplicationGE GEApp = null;
        private bool isGEStarted = false;

        public GEDemo4()
        {
            InitializeComponent();
            SetBackgroundImage(tabGEViewer);
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

            if (isGEStarted)
            {
                ResizeTabPage(tabGEViewer);
            }
        }

        #region GEFunctions

        /// <summary>
        /// 功能:尝试启动Google Earth实例
        /// </summary>
        /// <param>
        /// 参数:parentDocker
        /// 含义:GE渲染窗口所停靠的父窗口
        /// </param>
        private void TryStartGE(Control parentDocker)
        {
            try
            {
                //创建GE新实例
                GEApp = new ApplicationGE();
                //取得GE主窗口句柄
                GEHMainWnd = (IntPtr)GEApp.GetMainHwnd();
                //隐藏GoogleEarth主窗口
                NativeMethods.SetWindowPos(GEHMainWnd, NativeMethods.HWND_BOTTOM,
                    0, 0, 0, 0, NativeMethods.SWP_NOSIZE | NativeMethods.SWP_HIDEWINDOW);
                //取得GE的影像窗口(渲染窗口)句柄
                GEHRenderWnd = (IntPtr)GEApp.GetRenderHwnd();
                //调整视图窗口尺寸
                ResizeTabPage(tabGEViewer);
                //启动成功,设置标记
                isGEStarted = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Starting GE");
            }
        }

        /// <summary>
        /// 功能:尝试关闭GE
        /// </summary>
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
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error Shutdown GE");
            }
        }

        /// <summary>
        /// 功能:重设GE渲染窗口的尺寸
        /// <param>
        /// 参数:parentDocker
        /// 含义:GE渲染窗口所停靠的父窗口
        /// </param>
        private void ResizeTabPage(TabPage parentDocker)
        {
            RECT rect = new RECT();
            NativeMethods.GetClientRect(GEHRenderWnd, out rect);

            int left = (parentDocker.Width - rect.Width) / 2;
            int top = (parentDocker.Height - rect.Height) / 2;
            if (left < 0) left = 0;
            if (top < 0) top = 0;
            parentDocker.AutoScrollMinSize = new Size(rect.Width, rect.Height);
            //将渲染窗口嵌入到父窗体合适位置
            NativeMethods.MoveWindow(GEHRenderWnd, left, top, rect.Width, rect.Height, true);
            NativeMethods.SetParent(GEHRenderWnd, parentDocker.Handle);
        }

        #endregion GEFunctions

        #region MessageHandlers

        private void btnStartGE_Click(object sender, EventArgs e)
        {
            if (CheckGEState(false, "Startup Google Earth"))
            {
                SetBackgroundImage(tabGEViewer, true);
                TryStartGE(tabGEViewer);
                ResizeTabPage(tabGEViewer);
            }
        }

        private void btnStopGE_Click(object sender, EventArgs e)
        {
            if (CheckGEState(true, "Shutdown Google Earth"))
            {
                SetBackgroundImage(tabGEViewer);
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
                NativeMethods.BitBlt(hMemDC, rect.left, rect.top, rect.Width, rect.Height, hRenderDC, 0, 0, NativeMethods.SRCCOPY);

                #region SaveImage

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

                #endregion SaveImage
            }

        }

        #endregion MessageHandlers

        private bool CheckGEState(bool bExpRun, string caption)
        {
            bool state = true;
            if (bExpRun)
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
                if (isGEStarted)
                {
                    MessageBox.Show("Goolge Earth is running currently", caption);
                    state = false;
                }
            }

            return state;
        }

        private void SetBackgroundImage(Control control, bool reset=false)
        {
            if (reset)
            {
                control.BackgroundImage = null;
            }
            else
            {
                control.BackgroundImage = Properties.Resources.GEBgnd;
                control.BackgroundImageLayout = ImageLayout.Stretch;
            }
        }

    }
}
