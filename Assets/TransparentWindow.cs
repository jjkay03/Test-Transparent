using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class TransparentWindow : MonoBehaviour
{
    /* -------------------------------- Variables ------------------------------- */
    const int GWL_EXSTYLE = -20;
    const uint WS_EX_LAYERED = 0x00080000;
    const uint WS_EX_TRANSPARENT = 0x00000020;

    private struct MARGINS {
        public int cxLeftWidth;
        public int cxRightWidth;
        public int cyTopHeigh;
        public int cyBottomHeight;
    }

    /* ------------------------------ Unity methods ----------------------------- */
    // START
    private void Start() {
        //MessageBox(new IntPtr(0), "Hello world!", "Test text", 0);

        #if !UNITY_EDITOR
            IntPtr hWnd = GetActiveWindow();
            MARGINS margins = new MARGINS {cxLeftWidth = -1 };

            DwmExtendFrameIntoClientArea(hWnd, ref margins);
            SetwindowLong(hWnd, GWL_EXSTYLE, WS_EX_LAYERED | WS_EX_TRANSPARENT);

        #endif
            Application.runInBackground = true;

    }

    /* ----------------------------- Windows methods ---------------------------- */
    
    [DllImport("user32.dll")]
    public static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);
    
    [DllImport("user32.dll")]
    private static extern IntPtr GetActiveWindow();

    [DllImport("user32.dll")]
    private static extern int SetwindowLong(IntPtr hWnd, int nIndex, uint dwNewLong);
    
    [DllImport("Dwmapi.dll")]
    private static extern uint DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS margins);

    
}
