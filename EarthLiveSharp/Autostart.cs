using System;
using System.Diagnostics;
using System.Windows.Forms;
using Microsoft.Win32;

namespace EarthLiveSharp
{
    public class Autostart
    {
        private const string Key = "EarthLiveSharp";

        public static bool Set(bool enabled)
        {
            RegistryKey runKey = null;
            try
            {
                var path = Application.ExecutablePath;
                runKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                Debug.Assert(runKey != null, "runKey != null");
                runKey.SetValue(Key, path);
                if (!enabled)
                {
                    runKey.DeleteValue(Key);
                }
                return true;
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
                return false;
            }
            finally
            {
                runKey?.Close();
            }
        }
    }
}