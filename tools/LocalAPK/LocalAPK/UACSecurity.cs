using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace LocalAPK
{
    public static class UACSecurity
    {
        [DllImport("user32")]
        public static extern uint SendMessage(IntPtr hWnd, uint msg, uint wParam, uint lParam);

        private const int BcmFirst = 0x1600; //Normal button
        private const int BcmSetshield = (BcmFirst + 0x000C); //Elevated button

        public static void AddShieldToButton(Button b)
        {
            b.FlatStyle = FlatStyle.System;
            SendMessage(b.Handle, BcmSetshield, 0, 0xFFFFFFFF);
        }
    }
}
