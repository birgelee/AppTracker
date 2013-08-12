using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using AppTracker.Watch;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace Project1
    {
    class UpdateThread
        {

            [DllImport("user32.dll")]

            static extern int GetForegroundWindow();

            [DllImport("user32.dll")]

            static extern int GetWindowText(int hWnd, StringBuilder text, int count);
            [DllImport("user32.dll", SetLastError = true)]
            static extern void GetWindowThreadProcessId(IntPtr hWnd, out uint lpdwProcessId);

        public static void Update()
            {
            Thread updater = new Thread(Exec);
            updater.Start();
            }
        private static List<Watch> lastUpdated = new List<Watch>();
        private static void Exec()
            {


            List<Watch> updatedWatches = new List<Watch>();
            foreach (Watch watch in WatchManager.Watches)
                {
                var processList = Process.GetProcessesByName(watch.Name);
                if (processList.Length > 0)
                    {
                        /*int handle = 0;
                        uint id = 0;
                        handle = GetForegroundWindow();
                        GetWindowThreadProcessId(new IntPtr(handle), out id);
                        if (processList[0].Id == id)
                        {
                            watch.Played();
                            updatedWatches.Add(watch);
                        }*/
                        watch.Played();
                        updatedWatches.Add(watch);

                    
                    
                    }
                watch.UpdateTab();
                }

            foreach (Watch watch in lastUpdated)
                {
                if (!updatedWatches.Contains(watch))
                    {
                    watch.Stopped();
                    }
                }
            lastUpdated = updatedWatches;
            }
        }
    }
