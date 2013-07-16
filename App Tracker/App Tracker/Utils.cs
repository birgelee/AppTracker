using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Project1
    {
    class Utils
        {
        public static void ShowInfo(String text)
            {
            InfoBox iBox = new InfoBox(text);
            iBox.Show();
            }
        }
    }
