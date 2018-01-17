using System;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Helpers.Forms
{
    static class TextBoxPlaceholder
    {
        private const int EmSetcuebanner = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);

        public static void SetPlaceholder(this TextBox tb, string text)
        {
            SendMessage(tb.Handle, EmSetcuebanner, 0, text);
        }
    }
}
