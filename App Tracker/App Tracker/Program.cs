using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows.Forms;
using System.Threading;
using Project1;
using AppTracker.Watch;

namespace AppTracker
    {
    class Program
        {
        [STAThread]
        static void Main()
            {
            WatchManager.Watches.Add(new Watch.Watch("Borderlands2"));
            WatchManager.Watches.Add(new Watch.Watch("firefox"));
            WatchManager.Watches.Add(new Watch.Watch("notepad++"));
            UIManager.window = new MainWindow();
            Thread UI = new Thread(() => { UIManager.window.ShowDialog(); });
            UI.Start();
            while (true)
                {
                UpdateThread.Update();
                Thread.Sleep(1000);
                }
            }
        }
    }
