using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Project1;

class GloabalKeyListener
{
    private const int WH_KEYBOARD_LL = 13;
    private const int WM_KEYDOWN = 0x0100;
    private const int WM_KEYUP = 0x0101;
    private static LowLevelKeyboardProc _proc = HookCallback;
    private static IntPtr _hookID = IntPtr.Zero;

    private static Keys altcode;
    private static bool ctrl, alt, T;

    public static IntPtr AttachKeyListener()
    {
        _hookID = SetHook(_proc);
        return _hookID;
    }
    public static void RemoveListener()
    {
        UnhookWindowsHookEx(_hookID);
    }
    private static IntPtr SetHook(LowLevelKeyboardProc proc)
    {
        using (Process curProcess = Process.GetCurrentProcess())
        using (ProcessModule curModule = curProcess.MainModule)
        {
            return SetWindowsHookEx(WH_KEYBOARD_LL, proc,
                GetModuleHandle(curModule.ModuleName), 0);
        }
    }

    private delegate IntPtr LowLevelKeyboardProc(
        int nCode, IntPtr wParam, IntPtr lParam);

    private static IntPtr HookCallback(
        int nCode, IntPtr wParam, IntPtr lParam)
    {
        if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
        {
            int vkCode = Marshal.ReadInt32(lParam);
            Keys key = (Keys)vkCode;
            if (key == Keys.Control || key == Keys.ControlKey || key == Keys.LControlKey || key == Keys.RControlKey)
            {
                ctrl = true;
            }
            if (key == Keys.Alt || key == Keys.LMenu || key == Keys.RMenu)
            {
                altcode = key;
                alt = true;
            }
            if (key == Keys.T)
            {
                T = true;
            }
            if ((ctrl && alt) && T)
            {
                UIManager.ShowWindow = true;
            }
        }
        else if (nCode >= 0 && wParam == (IntPtr)WM_KEYUP)
        {
            int vkCode = Marshal.ReadInt32(lParam);
            Keys key = (Keys)vkCode;
            if (key == Keys.Control || key == Keys.ControlKey || key == Keys.LControlKey || key == Keys.RControlKey)
            {
                ctrl = false;
            }
            if (key == Keys.Alt || key == Keys.LMenu || key == Keys.RMenu)
            {
                alt = false;
            }
            if (key == Keys.T)
            {
                T = false;
            }
        }
        return CallNextHookEx(_hookID, nCode, wParam, lParam);
    }

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr SetWindowsHookEx(int idHook,
        LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool UnhookWindowsHookEx(IntPtr hhk);

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
        IntPtr wParam, IntPtr lParam);

    [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    private static extern IntPtr GetModuleHandle(string lpModuleName);
}
