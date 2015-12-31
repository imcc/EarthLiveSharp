using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;
using Microsoft.Win32;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace EarthLiveSharp
{
    internal static class Wallpaper
    {
        public const int ColorDesktop = 1;
        public const int SpifUpdateinifile = 0x01;
        public const int SpifSendwininichange = 0x02;
        private const int SpiSetdeskwallpaper = 20;

        public static void Set(string fpath)
        {
            var extensionName = Path.GetExtension(fpath);
            if (string.Equals(extensionName, ".bmp", StringComparison.OrdinalIgnoreCase))
            {
                SystemParametersInfo(SpiSetdeskwallpaper, 0, fpath, 1); //调用，filename为图片地址，最后一个参数需要为1，0的话在重启后就变回原来的了
            }
            else
            {
                var bmpPath = Application.StartupPath + @"\wallpaper.bmp";
                var fileInfo = new FileInfo(bmpPath);
                if (fileInfo.Exists)
                {
                    fileInfo.Delete();
                }

                using (var picutrebox = new PictureBox { Image = Image.FromFile(fpath) })
                {
                    picutrebox.Image.Save(bmpPath, ImageFormat.Bmp);
                    picutrebox.Image.Dispose();
                    picutrebox.Dispose();
                }

                SystemParametersInfo(SpiSetdeskwallpaper, 0, bmpPath, 1);
            }
        }

        public static void SetDefaultStyle()
        {
            int[] elements = { ColorDesktop };
            int[] colors = { ColorTranslator.ToWin32(Color.Black) };
            SetSysColors(1, elements, colors);

            using (var rk = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true))
            {
                if (rk != null)
                {
                    rk.SetValue("TileWallpaper", "0");//0 居中 1  平铺 默认
                    rk.SetValue("WallpaperStyle", "0");//0=居中 1=平铺 2=拉伸
                }
            }
        }

        [DllImport("user32.dll")]
        private static extern bool SetSysColors(int cElements, int[] lpaElements, int[] lpaRgbValues);

        /// <summary>
        /// 调用电脑底层的接口
        /// </summary>
        /// <param name="uAction"></param>
        /// <param name="uParam"></param>
        /// <param name="lpvParam">图片的路径</param>
        /// <param name="fuWinIni"></param>
        /// <returns></returns>
        /// uAction Long，指定要设置的参数。参考uAction常数表 
        ///uParam Long，参考uAction常数表 
        ///
        ///lpvParam Any，按引用调用的Integer、Long和数据结构。 
        ///
        ///fuWinIni 这个参数规定了在设置系统参数的时候，是否应更新用户设置参数 
        ///
        ///下面是部分uAction参数，和使用它们的方法： 
        ///
        ///参数    意义和使用方法   
        ///
        ///6    设置视窗的大小，SystemParametersInfo(6, 放大缩小值, P, 0)，lpvParam为long型 
        ///
        ///17    开关屏保程序，SystemParametersInfo(17, False, P, 1)，uParam为布尔型 
        ///
        ///13，24    改变桌面图标水平和垂直间距，uParam为间距值(像素)，lpvParam为long型 
        ///
        ///15    设置屏保等待时间，SystemParametersInfo(15, 秒数, P, 1)，lpvParam为long型 
        ///
        ///20    设置桌面背景墙纸，SystemParametersInfo(20, True, 图片路径, 1) 
        ///
        ///93    开关鼠标轨迹，SystemParametersInfo(93, 数值, P, 1)，uParam为False则关闭 
        ///
        ///97    开关Ctrl+Alt+Del窗口，SystemParametersInfo(97, False, A, 0)，uParam为布尔型 
        [DllImport("user32.dll", EntryPoint = "SystemParametersInfo")]
        private static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

    }
}
