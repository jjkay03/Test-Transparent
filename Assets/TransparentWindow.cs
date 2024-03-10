using System;
using System.Runtime.InteropServices;
using UnityEngine;

public class TransparentWindow : MonoBehaviour
{
    [DllImport("user32.dll")]
    public static extern int MessageBox(IntPtr hWnd, string text, string caption, uint type);

    private void Start() {
        MessageBox(new IntPtr(0), "Hello world!", "Test text", 0);
    }
}
