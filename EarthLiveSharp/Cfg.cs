using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Microsoft.Win32;
using System.Diagnostics;
using System.Windows.Forms;

namespace EarthLiveSharp
{
    public static class Cfg
    {
        public static string Version;
        public static string ImageFolder;
        public static string OriginAddr;
        public static List<string> CdnUrls;
        //public static string Cdn1Addr;
        //public static string Cdn2Addr;
        //public static string Cdn3Addr;
        //public static string Cdn4Addr;
        public static string SourceSelect;
        public static int Interval;
        public static int MaxNumber;
        public static bool Autostart;
        public static int DisplayMode; // 0 for only latest default; 1 for only latest customized style; 2 for slideshow

        private static readonly Random Rdm = new Random();

        public static void Load()
        {
            try
            {
                var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                var app = config.AppSettings;
                Version = app.Settings["version"].Value;
                ImageFolder = app.Settings["image_folder"].Value;
                OriginAddr = app.Settings["origin"].Value;
                CdnUrls = new List<string>(app.Settings["cdns"].Value.Split(','));
                SourceSelect = app.Settings["source_select"].Value;
                Interval = Convert.ToInt32(app.Settings["interval"].Value);
                MaxNumber = Convert.ToInt32(app.Settings["max_number"].Value);
                Autostart = Convert.ToBoolean(app.Settings["autostart"].Value);
                DisplayMode = Convert.ToInt32(app.Settings["display_mode"].Value);
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                MessageBox.Show("Configure error!");
                throw;
            }
        }

        public static void Save()
        {
            var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            var app = config.AppSettings;

            //app.Settings["origin"].Value = origin_addr;
            //app.Settings["cdn"].Value = cdn_addr;
            app.Settings["image_folder"].Value = ImageFolder;
            app.Settings["source_select"].Value = SourceSelect;
            app.Settings["interval"].Value = Interval.ToString();
            app.Settings["max_number"].Value = MaxNumber.ToString();
            app.Settings["autostart"].Value = Autostart.ToString();
            app.Settings["display_mode"].Value = DisplayMode.ToString();
            config.Save();
        }

        public static string GetImageHostUrl()
        {
            if (string.Equals(SourceSelect, "cdn", StringComparison.OrdinalIgnoreCase))
            {
                return GetRandomCdnUrl();
            }
            return OriginAddr;
        }

        public static string GetRandomCdnUrl()
        {
            return CdnUrls[Rdm.Next(0, CdnUrls.Count)];
        }
    }
}
