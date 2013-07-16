using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using AppTracker.Watch;
using System.Diagnostics;

namespace Project1
    {
    class UpdateThread
        {
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
                if (Process.GetProcessesByName(watch.Name).Length > 0)
                    {
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
