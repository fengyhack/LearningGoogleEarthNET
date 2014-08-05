using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EARTHLib;

namespace GEDemo2
{
    public partial class GEDemo2 : Form
    {
        static readonly Int32 WM_QUIT = 0x0012;
        private IntPtr GEHMainWnd = (IntPtr)0;
        private IntPtr GEHRenderWnd = (IntPtr)0;

        private ApplicationGE GEApp;
        public GEDemo2()
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
            NativeMethods.MoveWindow(GEHRenderWnd, 0, 0, this.Width, this.Height, true);
            NativeMethods.SetParent(GEHRenderWnd, this.Handle);
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            //关闭窗口
            NativeMethods.PostMessage((int)GEHMainWnd, WM_QUIT, 0, 0);
        }
    }
}
