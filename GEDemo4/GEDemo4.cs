using System;
using System.Windows.Forms;
using System.ComponentModel;
using EARTHLib;
using System.Drawing;
using System.Drawing.Imaging;


namespace GEDemo4
{
    public partial class GEDemo4 : Form
    {
        static readonly Int32 WM_QUIT = 0x0012;
        private IntPtr GEHMainWnd = (IntPtr)0;
        private IntPtr GEHRenderWnd = (IntPtr)0;

        private ApplicationGE GEApp;
        public GEDemo4()
        {
            InitializeComponent();
        }

        //重写OnLoad比实现Form_Load更高效
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //启动GoogleEarth实例
            GEApp = new ApplicationGE();

            GEHMainWnd = (IntPtr)GEApp.GetMainHwnd();
            //隐藏GoogleEarth主窗口
            NativeMethods.SetWindowPos(GEHMainWnd, NativeMethods.HWND_BOTTOM,
                0, 0, 0, 0,
                NativeMethods.SWP_NOSIZE | NativeMethods.SWP_HIDEWINDOW);

            GEHRenderWnd = (IntPtr)GEApp.GetRenderHwnd();
            //将渲染窗口嵌入到主窗体
            NativeMethods.MoveWindow(GEHRenderWnd, 2, 2, tabPage1.Width - 20, tabPage1.Height - 20, true);
            NativeMethods.SetParent(GEHRenderWnd, tabPage1.Handle);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            //关闭窗口
            NativeMethods.PostMessage(GEHMainWnd, WM_QUIT, 0, 0);
        }

        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            ResizeGERenderViewer();
        }

        private void ResizeGERenderViewer()
        {
            NativeMethods.SendMessage(GEHMainWnd, (uint)NativeMethods.WM_COMMAND, NativeMethods.WM_PAINT, 0);
            NativeMethods.PostMessage(GEHMainWnd, NativeMethods.WM_QT_PAINT, 0, 0);

            RECT mainRect = new RECT();
            NativeMethods.GetWindowRect(GEHMainWnd, out mainRect);
           int left = (tabPage1.Width - mainRect.width) / 2;
           int top = (tabPage1.Height - mainRect.height) / 2;

            NativeMethods.SetWindowPos(GEHMainWnd, NativeMethods.HWND_TOP,
                left, top, mainRect.width, mainRect.height, NativeMethods.SWP_FRAMECHANGED);

            NativeMethods.SendMessage(GEHMainWnd, (uint)NativeMethods.WM_COMMAND, NativeMethods.WM_SIZE, 0);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (GEApp != null && GEApp.IsInitialized() > 0)
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
                        toolTip1.Show("\'"+sfd.FileName + "\' Saved", tabPage1, 300, 200, 2000);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            RECT rect = new RECT();
            NativeMethods.GetClientRect(GEHRenderWnd, out rect);

            if (GEHRenderWnd != IntPtr.Zero)
            {
                // 取得Render DC
                IntPtr hRenderDC = NativeMethods.GetWindowDC(GEHRenderWnd);
                // 创建hBitmap
                IntPtr hBitmap = NativeMethods.CreateCompatibleBitmap(hRenderDC, rect.width, rect.height);
                // 创建MEM DC
                IntPtr hMemDC = NativeMethods.CreateCompatibleDC(hRenderDC);
                // 将Bitmap Select到MemDC
                NativeMethods.SelectObject(hMemDC, hBitmap);
                // 直接拷屏
                NativeMethods.BitBlt(hMemDC, 0, 0, rect.width, rect.height,
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
                            toolTip1.Show("\'" + sfd.FileName + "\' Saved", tabPage1, 300, 200, 2000);
                        }
                    }

                    //销毁资源
                    NativeMethods.DeleteDC(hRenderDC);
                    NativeMethods.DeleteDC(hMemDC);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            double tmplat, tmplng, tmpalt, tmprange, tmptilt, tmpAzimuth, tmpSpeed;
            tmplat = 32.0; //焦点纬度
            tmplng = 118.0; //焦点经度 
            tmpalt = 0;  //焦点高度 
            tmprange = 500;  //视场范围
            tmptilt = 45; //镜头倾角 
            tmpAzimuth = 0;//镜头方位角 
            tmpSpeed = 5;//相机移动速度  
            GEApp.SetCameraParams(tmplat, tmplng, tmpalt, AltitudeModeGE.RelativeToGroundAltitudeGE, tmprange, tmptilt, tmpAzimuth, tmpSpeed);
        }

    }
}
