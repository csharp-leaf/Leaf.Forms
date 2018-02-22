using System;
using System.Runtime.InteropServices;
using System.Text;

namespace Leaf.Forms
{
    internal static class NativeMethods
    {
        #region SendMessage
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr hWnd, uint msg, IntPtr wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);
        #endregion

        #region InternetGetCookieEx
        [DllImport("wininet.dll", SetLastError = true)]
        public static extern bool InternetGetCookieEx([MarshalAs(UnmanagedType.LPWStr)]string url,
            [MarshalAs(UnmanagedType.LPWStr)]string cookieName,
            [MarshalAs(UnmanagedType.LPWStr)]StringBuilder cookieData,
            ref int size, int dwFlags, IntPtr lpReserved);        
        #endregion
    }
}
