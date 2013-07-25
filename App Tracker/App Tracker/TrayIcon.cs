using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Project1;
using System.Drawing;

namespace AppTracker
    {
    public class TrayIcon
        {
        private static NotifyIcon icon;
        public static void CreateIcon()
            {
            icon = new NotifyIcon()

            {
                ContextMenu = new ContextMenu(),
                ContextMenuStrip = new ContextMenuStrip(),

                Icon = new Icon(SystemIcons.Application, 40, 40),

                Text = "App Tracker",

                Visible = true

            };
            icon.ContextMenu.Show(new Control("test", 0, 0, 12, 12), new Point(0, 0));
            icon.ShowBalloonTip(100, "test", "test", ToolTipIcon.Info);
            }
        public static void DiscardIcon()
            {
            icon.Dispose();
            icon = null;
            }
        }
    }
