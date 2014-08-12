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
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            //关闭窗口
            NativeMethods.PostMessage(GEHMainWnd, WM_QUIT, 0, 0);
        }
    }
}
