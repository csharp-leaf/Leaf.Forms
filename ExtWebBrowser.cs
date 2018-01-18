using System.Windows.Forms;
using Microsoft.Win32;

namespace Leaf.Forms
{
    public static class ExtWebBrowser
    {
        /// <summary>
        /// Activate latest engine of IE WebView component. 
        /// </summary>
        /// <param name="wb">WebBrowser</param>
        public static bool Modernize(this WebBrowser wb)
        {
            int browserVer = wb.Version.Major;
            int regVal;

            // Set the appropriate Internet Explorer version
            if (browserVer >= 12) // Edge
                regVal = 12001;
            else switch (browserVer)
            {
                case 11:
                    regVal = 11001;
                    break;
                case 10:
                    regVal = 10001;
                    break;
                case 9:
                    regVal = 9999;
                    break;
                case 8:
                    regVal = 8888;
                    break;
                default:
                    regVal = 7000;
                    break;
            }

            // Set the actual key
            var key = Registry.CurrentUser.OpenSubKey(
                @"SOFTWARE\Microsoft\Internet Explorer\Main\FeatureControl\FEATURE_BROWSER_EMULATION", true);
            if (key == null)
                return false;
            
            // Set newest IE Version
            key.SetValue(System.Diagnostics.Process.GetCurrentProcess().ProcessName + ".exe", regVal,
                RegistryValueKind.DWord);
            key.Close();
            key.Dispose();

            return true;
        }
    }
}