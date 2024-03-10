using System;
using System.Runtime.InteropServices;
using Unity.VisualScripting;
using UnityEngine;

public class TransparentWindow : MonoBehaviour
{
    /* -------------------------------- Variables ------------------------------- */
    const int GWL_EXSTYLE = -20;
    const int WS_EX_LAYERED = 0x80000;
    const int WS_EX_TRANSPARENT = 0x20;
    const int LWA_COLORKEY = 0x00000001;

    [StructLayout(LayoutKind.Sequential)]
    struct MARGINS {
        public int cxLeftWidth;
        public int cxRightWidth;
        public int cyTopHeight;
        public int cyBottomHeight;
    }

    [Header("Transparent Window Settings")]
    public bool stayOnTop = true;


    /* -------------------------- Windows Lib Functions ------------------------- */
    [DllImport("Dwmapi.dll")]
    private static extern uint DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS margins);

    [DllImport("user32.dll")]
    public static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern IntPtr GetActiveWindow();

    [DllImport("user32.dll", SetLastError = true)]
    private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);

    [DllImport("user32.dll", SetLastError = true)]
    private static extern int SetWindowPos(IntPtr hWnd, IntPtr hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);


    /* --------------------------------- Methods -------------------------------- */
    private void Start() {
        // Don't run code if in unity editor
        #if !UNITY_EDITOR
            IntPtr hWnd = GetActiveWindow();
            MARGINS margins = new MARGINS { cxLeftWidth = -1 };

            // Extend the frame into the client area to include the transparent parts
            DwmExtendFrameIntoClientArea(hWnd, ref margins);

            // Make the window layered and transparent
            SetWindowLong(hWnd, GWL_EXSTYLE, WS_EX_LAYERED | WS_EX_TRANSPARENT);

            // Make the window stay on top
            if (stayOnTop == true) { SetWindowPos(hWnd, HWND_TOPMOST, 0, 0, 0, 0, 0); }
            
        
        #endif
            // Run application when its in the background (not selected)
            Application.runInBackground = true;
    }
}
