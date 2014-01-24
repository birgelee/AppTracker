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

            Thread terminationThread = new Thread(() =>
            {
                while (true)
                {
                    if (EndProgram)
                    {
                        UIManager.window.Close();
                        UIManager.window.Dispose();
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
        }


    }
