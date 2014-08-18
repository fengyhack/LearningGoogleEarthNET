using System;
using System.Windows.Forms;
using System.ComponentModel;
using EARTHLib;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;


namespace GEDemo5
{
    public struct SCamParams
    {
        public double dLat;
        public double dLon;
        public double dAlt;
        public double dRng;
        public double dAng;
        public double dAzm;
        public double dSpd;
    }
    public partial class GEDemo5 : Form
    {
        #region PrivateMembers

        private IntPtr GEHMainWnd = (IntPtr)0;
        private IntPtr GEHRenderWnd = (IntPtr)0;

        private ApplicationGE GEApp = null;
        private bool isGEStarted = false;

        SCamParams scp = new SCamParams();

        #endregion PrivateMembers

        public GEDemo5()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized; //最大化显示
            tabDocker.TabPages.Clear();
            tabDocker.TabPages.Add(tabGEViewer);
            SetBackgroundImage(tabGEViewer);
            SetParamsDefault();
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

        private void btnExitApp_Click(object sender, EventArgs e)
        {
            if (DialogResult.OK != MessageBox.Show("Are you sure to exit?", "Exit Confirm", MessageBoxButtons.OKCancel))
            {
                return;
            }
            if (isGEStarted)
            {
                TryCloseGE();
            }
            Application.Exit();
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
                        msgToolTip.Show("\'" + sfd.FileName + "\' Saved", tabGEViewer, tabGEViewer.Width / 4, tabGEViewer.Height / 4, 2000);
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
                            msgToolTip.Show("\'" + sfd.FileName + "\' Saved", tabGEViewer, tabGEViewer.Width / 4, tabGEViewer.Height / 4, 2000);
                        }
                    }
                    //销毁资源
                    NativeMethods.DeleteDC(hRenderDC);
                    NativeMethods.DeleteDC(hMemDC);
                }

                #endregion SaveImage
            }

        }

        private void btnParamsSettings_Click(object sender, EventArgs e)
        {
            if (CheckGEState(true, "Setting Camera Parameters"))
            {
                tabDocker.TabPages.Add(tabXPViewer);
                tabDocker.SelectTab(tabXPViewer);
            }
        }

        private void btnOKCamParams_Click(object sender, EventArgs e)
        {
            GetParamsValue();
            if (CheckInputParams())
            {
                GEApp.SetCameraParams(scp.dLat, scp.dLon, scp.dAlt,
                    AltitudeModeGE.AbsoluteAltitudeGE,
                    scp.dRng, scp.dAng, scp.dAzm, scp.dSpd);
                tabDocker.TabPages.Remove(tabXPViewer);
            }
            else
            {
                MessageBox.Show("Invalid Parameters!");
            }
        }

        #endregion MessageHandlers

        #region AuxFunctions

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

        //reset=true表示清除背景图片
        private void SetBackgroundImage(Control control, bool reset = false)
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

        private void GetParamsValue()
        {
            scp.dLat = TranslateLatLon(txtBoxLat.Text);
            scp.dLon = TranslateLatLon(txtBoxLon.Text);
            scp.dAlt = double.Parse(txtBoxAlt.Text);
            scp.dRng = double.Parse(txtBoxRng.Text);
            scp.dAng = double.Parse(txtBoxAng.Text);
            scp.dAzm = double.Parse(txtBoxAzm.Text);
            scp.dSpd = double.Parse(txtBoxSpd.Text);
        }

        private void SetParamsDefault()
        {
            // 上海外滩,东方明珠塔
            // (31°14'30''N 121°29'43''E)
            // (31.24167°N 121.4953°E)

            txtBoxLat.Text = "31°14'30''N";
            txtBoxLon.Text = "121°29'43''E";
            txtBoxAlt.Text = "0";
            txtBoxRng.Text = "2000";
            txtBoxAng.Text = "0";
            txtBoxAzm.Text = "0";
            txtBoxSpd.Text = "3";

            scp.dLat = 31.24167;
            scp.dLon = 121.4953;
            scp.dAlt = 0;
            scp.dRng = 2000;
            scp.dAng = 0;
            scp.dAzm = 0;
            scp.dSpd = 3;   
        }

        private bool CheckInputParams()
        {
            return (scp.dLat >= -90 && scp.dLat <= 90)&&
                (scp.dLon >= -180 && scp.dLon <= 180)&&
                (scp.dAlt >= 0) && (scp.dRng>0)&& 
                (scp.dAng >= 0)&& (scp.dSpd > 0);
        }

        public double TranslateLatLon(string slatlon)
        {
            double ddeg = 0.0;
            double dmin = 0.0;
            double dsec = 0.0;
            int start=0,pos=0;
            #region VAL
            pos = slatlon.IndexOf('°',start);
            if (pos > 0)
            {
                #region ddeg
                while (start<pos)
                {
                    if (slatlon[start] == '0') ++start;
                    else break;
                }
                if (start < pos-1)
                {
                    ddeg = double.Parse(slatlon.Substring(start, pos-start));
                }
                #endregion ddeg

                start = pos + 1;
                pos = slatlon.IndexOf('\'', start);
                if (pos > 0)
                {
                    #region dmin
                    while (start < pos)
                    {
                        if (slatlon[start] == '0') ++start;
                        else break;
                    }
                    if (start < pos-1)
                    {
                        dmin = double.Parse(slatlon.Substring(start, pos - start));
                    }
                    #endregion dmin

                    start = pos + 1;
                    pos = slatlon.IndexOf('\'', start);
                    if (pos > 0)
                    {
                        #region dsec
                        while (start < pos)
                        {
                            if (slatlon[start] == '0') ++start;
                            else break;
                        }
                        if (start < pos-1)
                        {
                            dsec = double.Parse(slatlon.Substring(start, pos - start));
                        }
                        #endregion dsec
                    } //if(pos,dsec)
                } //if(pos,dmin)
                #region SGN
                pos =slatlon.LastIndexOf('\'')+ 1;
                if (slatlon[pos] == 'S'||slatlon[pos]=='W')
                {
                    ddeg = -ddeg;
                    dmin = -dmin;
                    dsec = -dsec;
                } //if(pos,len-1)
                #endregion SGN
            } //if(pos ddeg)
            else
            {
                ddeg = double.Parse(slatlon);
            }
            #endregion VAL

            return (ddeg + dmin / 60.0 + dsec / 3600.0);
        }

        #endregion AuxFunctions

    }

}
