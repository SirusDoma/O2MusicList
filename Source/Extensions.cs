using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace O2MusicList
{
    /// <summary>
    /// Provides extra functions to instance of Control types.
    /// </summary>
    internal static class UIExtensions
    {
        private const int EM_SETCUEBANNER = 0x1501;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern Int32 SendMessage(IntPtr hWnd, int msg, int wParam, [MarshalAs(UnmanagedType.LPWStr)]string lParam);

        static UIExtensions()
        {
        }

        /// <summary>
        /// Sets the native placeholder text associated with this control.
        /// </summary>
        /// <param name="instance">The control that placeholder will be placed.</param>
        /// <param name="placeholder">Placeholder text.</param>
        public static void SetPlaceholder(this Control instance, string placeholder)
        {
            SendMessage(instance.Handle, EM_SETCUEBANNER, 0, placeholder);
        }

        /// <summary>
        /// Sets the text associated with this control without firing TextChangedEvent
        /// </summary>
        /// <param name="instance">The control to change the text.</param>
        /// <param name="text">New value of text.</param>
        public static void SetText(this Control instance, string text)
        {
            var type  = typeof(Control);
            var field = type.GetField("text", BindingFlags.Instance | BindingFlags.NonPublic);
            var prop  = type.GetProperty("WindowText", BindingFlags.Instance | BindingFlags.NonPublic);

            field.SetValue(instance, text);
            prop.SetValue(instance, text, null);
        }
    }
}
