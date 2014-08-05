
using System;
using System.Runtime.InteropServices;

namespace GEDemo3
{
    [StructLayout(LayoutKind.Sequential)]
    public class POINT
    {
        public int x;
        public int y;

        public POINT()
        {
        }

        public POINT(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public class POINTD
    {
        private double x;
        private double y;
        public double X
        {
            get { return this.x; }
            set { this.x = value; }
        }
        public double Y
        {
            get { return this.y; }
            set { this.y = value; }
        }

        public POINTD()
        {
            x = -1.0;
            y = -1.0;
        }

        public POINTD(double dx, double dy)
        {
            x = dx;
            y = dy;
        }
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct RECT
    {
        public int left;
        public int top;
        public int width;
        public int height;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct SCROLLINFO
    {
        public uint cbSize;
        public uint fMask;
        public int nMin;
        public int nMax;
        public uint nPage;
        public int nPos;
        public int nTrackPos;
    }

    [StructLayout(LayoutKind.Sequential)]
    public struct MSG
    {
        public IntPtr hwnd;

        public uint message;

        public IntPtr WPARAM;

        public IntPtr LPARAM;

        public long Time;

        public POINT pt;
    }
}
