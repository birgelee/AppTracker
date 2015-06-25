using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;
using Project1;
using AppTracker.Watch;
using MouseKeyboardActivityMonitor;
using MouseKeyboardActivityMonitor.WinApi;
using MouseKeyboardActivityMonitor.Controls;
using System.IO;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System.Drawing;

namespace AppTracker
{
    class Program
    {

        [STAThread]
        static void Main()
        {
            GloabalKeyListener.AttachKeyListener();
            Application.EnableVisualStyles();
            if (File.Exists(@".\save.json"))
            {
                if (!File.ReadAllText(@".\save.json").Equals(""))
                    WatchManager.Watches = Loader.Load(@".\save.json");
            }
            else
            {
                (File.Create(@".\save.json")).Close();

            }
            UIManager.window = new MainWindow();
            Thread UI = new Thread(() => { while (!EndProgram) { if (UIManager.ShowWindow) { UIManager.ShowWindow = false; UIManager.window.ShowDialog(); UIManager.ShowWindow = false; } else { Thread.Sleep(300); } } });
            UI.Start();

            InitTray();

            Thread terminationThread = new Thread(() =>
            {
                while (true)
                {
                    if (EndProgram)
                    {
                        UIManager.window.InvokeCloseOperation();
                        UIManager.TrayIcon.Visible = false;
                        UIManager.TrayIcon.Dispose();
                        Save();
                        GloabalKeyListener.RemoveListener();
                        Application.Exit();
                        break;
                    }

                    UpdateThread.Update();
                    Thread.Sleep(1000);
                }
            });
            terminationThread.Start();

            Application.Run();

        }
        public static bool EndProgram { get; set; }
        public static void Save()
        {
            Loader.Save(@".\save.json", WatchManager.Watches);
        }

        private static void InitTray()
        {
            var trayMenu = UIManager.TrayMenu;
            var trayIcon = UIManager.TrayIcon;
            trayMenu = new ContextMenu();
            trayMenu.MenuItems.Add("Show", (e, sender) => UIManager.ShowWindow = true);
            trayMenu.MenuItems.Add("Exit", (e, sender) => EndProgram = true);

            // Create a tray icon. In this example we use a
            // standard system icon for simplicity, but you
            // can of course use your own custom icon too.
            trayIcon = new NotifyIcon();
            trayIcon.Text = "App Tracker";
            trayIcon.Icon = new Icon(SystemIcons.Application, 40, 40);
            trayIcon.DoubleClick += (e, sender) => UIManager.ShowWindow = true;

            // Add menu to tray icon and show it.
            trayIcon.ContextMenu = trayMenu;
            trayIcon.Visible = true;
            UIManager.TrayMenu = trayMenu;
            UIManager.TrayIcon = trayIcon;

        }
    }


}
