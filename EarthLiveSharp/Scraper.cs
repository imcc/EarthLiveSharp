using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace EarthLiveSharp
{
    public static class Scraper
    {
        public static string ImageHost { get; set; }
        public static string ImageFolder { get; set; }
        public static string SavedPath { get; set; }
        public static int MaxNumber { get; set; }

        /// <summary>
        /// 上次调用latest接口返回的图片名称
        /// </summary>
        public static string LastImageName { get; set; }


        /// <summary>
        /// 最后保存的那种图片的Url
        /// </summary>
        private static string _latestImageUrl = "";
        private static int _imageCount;
        private const string JsonUrl = "http://himawari8.nict.go.jp/img/D531106/latest.json";

        static Scraper()
        {
            InitFolder();
        }


        public static void Reset()
        {
            _imageCount = 0;
            _latestImageUrl = "";
            //_savedAddress = "";
        }

        public static string GetLatestAddress()
        {
            var imageUrl = string.Empty;

            var request = WebRequest.Create(JsonUrl) as HttpWebRequest;
            if (request == null)
            {
                return imageUrl;
            }
            try
            {
                using (var response = request.GetResponse() as HttpWebResponse)
                {
                    string date;
                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        date = reader.ReadToEnd();
                    }

                    if (date.Length > 30)
                    {
                        //var resultRegex = new Regex(@"""date"":\""(?<date>[\d-\s:]+\d)"".+""file"":""(?<name>[\w\.]+)""");
                        //var nameRegex = new Regex(@"""file"":""(?<name>[\w\.]+)""");
                        //if (nameRegex.IsMatch(date))
                        //{
                        //    var fileName = nameRegex.Match(date).Groups[1].Value;
                        //    if (!string.IsNullOrEmpty(fileName))
                        //    {
                        //        _latestAddress = fileName;
                        //    }
                        //}

                        //2015-12-31 06:10:00 转换成2015/12/31/061000
                        var dateFormated = date.Substring(9, 19).Replace("-", "/").Replace(" ", "/").Replace(":", "");
                        imageUrl = $"{ImageHost}{dateFormated}_0_0.png";

                        Trace.WriteLine("[get latest address] " + date);
                    }
                    else
                    {
                        Trace.WriteLine("[pic address is too short]"); // do nothing
                    }
                }
            }
            catch (Exception e)
            {
                Trace.WriteLine(e.Message);
            }

            return imageUrl;
        }

        public static void SaveImage(string imageUrl)
        {
            var imagePath = $"{ImageFolder}\\{_imageCount}.png";
            //if(File.Exists(image_path))
            //{
            //    File.Delete(image_path + image_cnt.ToString() + ".png");
            //}
            using (var client = new WebClient())
            {
                try
                {
                    client.DownloadFile(imageUrl, imagePath);
                    SavedPath = imagePath;
                    _latestImageUrl = imageUrl;

                    Trace.WriteLine("[save image] " + imageUrl + " > " + imagePath);
                    //if (Directory.GetFiles(ImageFolder, "*.png").Length == 1)
                    //{
                    //    File.Copy(imagePath, ImageFolder + @"\" + "1.png", true);
                    //}
                }
                catch (Exception e)
                {
                    Trace.WriteLine(e.Message + "[latest_address] " + imageUrl + " [image_path] " + imagePath);
                }
            }
            _imageCount = (_imageCount + 1) % MaxNumber;
        }

        private static void InitFolder()
        {
            if (string.IsNullOrEmpty(ImageFolder))
            {
                ImageFolder = Application.StartupPath + @"\images";
            }
            // ReSharper disable once InvertIf
            if (!Directory.Exists(ImageFolder))
            {
                Trace.WriteLine("[create folder]");
                Directory.CreateDirectory(ImageFolder);
            }
        }

        public static void UpdateImage()
        {
            var imageUrl = GetLatestAddress();
            if (!string.IsNullOrEmpty(imageUrl))
            {
                if (!string.IsNullOrEmpty(_latestImageUrl) && 
                    imageUrl.Substring(imageUrl.Length - 85, 85).Equals(_latestImageUrl.Substring(imageUrl.Length - 85, 85)))
                {
                    return;
                }

                SaveImage(imageUrl);
            }
        }
    }
}