using AppTracker.Watch;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using AppTracker;

namespace Project1
{
    class Loader
    {
        public static List<Watch> Load(string path)
        {
            var returnVal = new List<Watch>();
            JArray array = JArray.Parse(File.ReadAllText(path));
            foreach (JObject obj in array)
            {
                string name = obj["name"].ToObject<string>();
                TimeSpan totaltimeplayed = obj["timeplayed"].ToObject<TimeSpan>();
                List<Session> sessions = obj["sessions"].ToObject<List<Session>>();
                returnVal.Add(new Watch(name, totaltimeplayed, sessions));
            }
            return returnVal;
        }
        public static void Save(string path, List<Watch> watches)
        {
            JArray obj = new JArray();
            foreach (Watch w in WatchManager.Watches)
            {
                obj.Add(w.ToJObject());
            }
            string result = obj.ToString();
            File.WriteAllText(path, result);
        }
    }
}
