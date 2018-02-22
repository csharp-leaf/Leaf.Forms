using System;
using System.Windows.Forms;

namespace Leaf.Forms
{
    public static class TextBoxExtensions
    {
        private const int EmSetCueBanner = 0x1501;

        public static void SetPlaceholder(this TextBox tb, string text)
        {
            NativeMethods.SendMessage(tb.Handle, EmSetCueBanner, IntPtr.Zero, text);
        }
    }
}
