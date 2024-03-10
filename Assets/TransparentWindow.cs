using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class TransparentWindow : MonoBehaviour
{
    [DllImport("user32.dll")]
    public static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);
    
    [DllImport("user32.dll")]
    private static extern IntPtr GetActiveWindow();

    private struct MARGINS {
        public int cxLeftWidth;
        public int cxRightWidth;
        public int cyTopHeigh;
        public int cyBottomHeight;
    }
    
    [DllImport("Dwmapi.dll")]
    private static extern uint DwmExtendFrameIntoClientArea(IntPtr hWnd, ref MARGINS margins);

    private void Start() {
        //MessageBox(new IntPtr(0), "Hello world!", "Test text", 0);

        IntPtr hWnd = GetActiveWindow();
        MARGINS margins = new MARGINS {cxLeftWidth = -1 };
        
        DwmExtendFrameIntoClientArea(hWnd, ref margins);
    }
}
