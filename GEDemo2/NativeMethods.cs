// 功能：Windows API调用
using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace GEDemo2
{
    public class NativeMethods
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern bool SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int x, int y, int cx, int cy, UInt32 uflags);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr PostMessage(int hWnd, int msg, int wParam, int lParam);

        #region 预定义

        public static readonly IntPtr   HWND_BOTTOM =          new IntPtr(1);
        public static readonly IntPtr   HWND_NOTOPMOST = new IntPtr(-2);
        public static readonly IntPtr   HWND_TOP =                   new IntPtr(0);
        public static readonly IntPtr   HWND_TOPMOST =       new IntPtr(-1);

        public static readonly UInt32 SWP_NOSIZE =                           1U;
        public static readonly UInt32 SWP_NOMOVE =                        2U;
        public static readonly UInt32 SWP_NOZORDER =                    4U;
        public static readonly UInt32 SWP_NOREDRAW =                   8U;
        public static readonly UInt32 SWP_NOACTIVATE =                16U;
        public static readonly UInt32 SWP_FRAMECHANGED =         32U;
        public static readonly UInt32 SWP_SHOWWINDOW =           64U;
        public static readonly UInt32 SWP_HIDEWINDOW =            128U;
        public static readonly UInt32 SWP_NOCOPYBITS =               256U;
        public static readonly UInt32 SWP_NOOWNERZORDER =    512U;
        public static readonly UInt32 SWP_NOSENDCHANGING = 1024U;

        #endregion

        public delegate int EnumWindowsProc(IntPtr hwnd, int lParam);

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
    }
}