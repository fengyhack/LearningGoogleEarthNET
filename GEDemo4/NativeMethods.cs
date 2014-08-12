
using System;
using System.Runtime.InteropServices;
using System.Drawing;

namespace GEDemo4
{
    public class NativeMethods
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, UInt32 uflags);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr PostMessage(IntPtr hWnd, int msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, uint Msg, int wParam, int lParam);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int GetMessage(out MSG msg, IntPtr hWnd, int wMsgFilterMin, int wMsgFilterMax);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int PeekMessage(out MSG msg, IntPtr hWnd, int wMsgFilterMin, int wMsgFilterMax);
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern long DispatchMessage(MSG msg);

        [DllImport("user32.dll")]
        public static extern IntPtr FindWindow(string className, string windowTitle);
        [DllImport("user32.dll")]
        public static extern bool ShowWindowAsync(int hWnd, int nCmdShow);

        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hWnd, out RECT rect);

        [DllImport("user32.dll")]
        public static extern bool GetClientRect(IntPtr hWnd, out RECT rect);

        [DllImport("user32.dll")]
        public static extern IntPtr GetDesktopWindow();

        [DllImport("user32")]
        public static extern IntPtr GetWindowDC(IntPtr hwnd);

        [DllImport("user32")]
        public static extern IntPtr GetDC(IntPtr hwnd);

        [DllImport("user32")]
        public static extern long ReleaseDC(IntPtr handle, IntPtr hdc);

        [DllImport("user32")]
        public static extern IntPtr WindowFromPoint(Point point);

        [DllImport("user32")]
        public static extern bool PrintWindow(IntPtr hWnd, IntPtr hdcBlt, UInt32 nFlags);

        [DllImport("kernel32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CloseHandle(IntPtr hObject);

        #region 预定义

        public static readonly IntPtr HWND_BOTTOM = new IntPtr(1);
        public static readonly IntPtr HWND_NOTOPMOST = new IntPtr(-2);
        public static readonly IntPtr HWND_TOP = new IntPtr(0);
        public static readonly IntPtr HWND_TOPMOST = new IntPtr(-1);
        public static readonly uint SWP_NOSIZE = 1U;
        public static readonly uint SWP_NOMOVE = 2U;
        public static readonly uint SWP_NOZORDER = 4U;
        public static readonly uint SWP_NOREDRAW = 8U;
        public static readonly uint SWP_NOACTIVATE = 16U;
        public static readonly uint SWP_FRAMECHANGED = 32U;
        public static readonly uint SWP_SHOWWINDOW = 64U;
        public static readonly uint SWP_HIDEWINDOW = 128U;
        public static readonly uint SWP_NOCOPYBITS = 256U;
        public static readonly uint SWP_NOOWNERZORDER = 512U;
        public static readonly uint SWP_NOSENDCHANGING = 1024U;
        public static readonly int WM_COMMAND = 0x0112;
        public static readonly int WM_QT_PAINT = 0xC2DC;
        public static readonly int WM_PAINT = 0x000F;
        public static readonly int WM_SIZE = 0x0005;

        #endregion

        public delegate int EnumWindowsProc(IntPtr hWnd, int lParam);

        [DllImport("user32", CharSet = CharSet.Auto)]
        public extern static IntPtr GetParent(IntPtr hWnd);

        [DllImport("user32", CharSet = CharSet.Auto)]
        public extern static bool MoveWindow(IntPtr hWnd, int X, int Y, int nWidth, int nHeight, bool bRepaint);

        [DllImport("user32", CharSet = CharSet.Auto)]
        public extern static IntPtr SetParent(IntPtr hWndChild, IntPtr hWndNewParent);

        [DllImport("user32.dll", ExactSpelling = true, CharSet = CharSet.Auto)]
        public static extern IntPtr GetWindow(IntPtr hWnd, int uCmd);

        public static int GW_CHILD = 5;
        public static int GW_HWNDNEXT = 2;

        #region GDI绘图函数

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleDC(IntPtr hwnd);

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc, int nWidht, int nHeight);

        [DllImport("gdi32.dll")]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr hgdiobj);

        [DllImport("gdi32.dll")]
        public static extern int DeleteDC(IntPtr hdc);

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateDC(string lpszDriver, string lpszDevice, string lpszOutput, IntPtr lpInitData);
        /// <summary>
        /// API函数BitBlt
        /// </summary>
        /// <param name="hdcDest">DC目标设备句柄</param>
        /// <param name="nXDest">目标对象的左上角X坐标</param>
        /// <param name="nYDest">目标对象的左上角Y坐标</param>
        /// <param name="nWidth">目标对象的矩形宽度</param>
        /// <param name="nHeight">目标对象的矩形高度</param>
        /// <param name="hdcSrc">DC源设备句柄</param>
        /// <param name="nXSrc">源对象的左上角X坐标</param>
        /// <param name="nYSrc">源对象的左上角Y坐标</param>
        /// <param name="dwRop">光栅操作值</param>
        /// <returns></returns>
        [DllImport("gdi32.dll")]
        public static extern int BitBlt(IntPtr hdcDest, int nXDest, int nYDest, int nWidth, int nHeight, IntPtr hdcSrc, int nXSrc, int nYSrc, int dwRop);
        /// <summary>
        /// 使用当前选定的画笔和画刷进行矩形的绘制
        /// </summary>
        /// <param name="hdc">DC句柄</param>
        /// <param name="nLeftRect">左上角x坐标</param>
        /// <param name="nTopRect">左上角y坐标</param>
        /// <param name="nRightRect">右下角x坐标</param>
        /// <param name="nBottomRect">右下角y坐标</param>
        /// <returns></returns>
        [DllImport("gdi32.dll")]
        public static extern bool Rectangle(IntPtr hdc, int nLeftRect, int nTopRect, int nRightRect, int nBottomRect);

        #region Raster operation（BitBlt函数最后一个参数）
        /// <summary>
        /// 以黑色填充目标矩形区域。
        /// </summary>
        public static int RP_BLACKNESS = 0x42;
        /// <summary>
        /// 先将源矩形图像与目标矩形图像进行布尔“或”运算，然后再将图像进行反相。
        /// </summary>
        public static int RP_NOTSRCERASE = 0x001100A6;
        /// <summary>
        /// 将源矩形图像进行反相，复制到目标矩形上。
        /// </summary>
        public static int RP_NOTSRCCOPY = 0x330008;
        /// <summary>
        /// 将目标矩形图像进行反相.
        /// </summary>
        public static int RP_DSTINVERT = 0x550009;
        /// <summary>
        /// 将源矩形图像进行反相，与目标矩形图像进行布尔“或”运算。
        /// </summary>
        public static int RP_MERGEPAINT = 0x0BB0226;
        /// <summary>
        /// 将源矩形图像与指定的图案刷（Pattern）进行布尔“与”运算
        /// </summary>
        public static int RP_MERGECOPY = 0x00C000CA;
        /// <summary>
        /// 将源矩形图像与目标矩形图像进行布尔“与”运算。
        /// </summary>
        public static int RP_SRCAND = 0x008800C6;
        /// <summary>
        /// 将目标矩形图像直接复制到目标矩形。
        /// </summary>
        public static int RP_SRCCOPY = 0x00CC0020;
        /// <summary>
        /// 将目标矩形图像进行反相，再与源矩形图像进行布尔“与”运算。
        /// </summary>
        public static int RP_SRCERASE = 0x440328;
        /// <summary>
        /// 将源矩形图像与目标矩形图像进行布尔“或”运算。
        /// </summary>
        public static int RP_SRCPAINT = 0x00EE0086;
        /// <summary>
        /// 将源矩形图像与目标矩形图像进行布尔“异或”运算。
        /// </summary>
        public static int RP_SRCINVERT = 0x660046;
        /// <summary>
        /// 将指定的图案刷复制到目标矩形上。
        /// </summary>
        public static int RP_PATCOPY = 0x00F00021;
        /// <summary>
        /// 将指定的图案刷与目标矩形图像进行布尔“异或”运算。
        /// </summary>
        public static int RP_PATINVERT = 0x005A0049;
        /// <summary>
        /// 先将源矩形图像进行反相，与指定的图案刷进行布尔“或”运算，再与目标矩形图像进行布尔“或”运算
        /// </summary>
        public static int RP_PATPAINT = 0x00FB0A09;
        /// <summary>
        /// 用白色填充矩形区域。
        /// </summary>
        public static int RP_WHITENESS = 0x00FF0062;
        #endregion

        #endregion
    }
}