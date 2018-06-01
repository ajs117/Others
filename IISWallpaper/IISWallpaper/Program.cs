using Microsoft.Win32;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;

namespace IISWallpaper
{
    internal class Program
    {
        private const int SetDeskWallpaper = 20;
        private const int UpdateIniFile = 0x01;
        private const int SendWinIniChange = 0x02;

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SystemParametersInfo(int uAction, int uParam, string lpvParam, int fuWinIni);

        private static void Main(string[] args)
        {
            RemoteWebDriver driver = null;
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArgument("--headless");
            driver = new ChromeDriver(chromeOptions);

            driver.Manage().Window.FullScreen();
            driver.Navigate().GoToUrl("http://www.ustream.tv/embed/17074538?html5ui?v=3&controls=false&autoplay=true");
            Thread.Sleep(10000);
            driver.FindElementById("ComponentsContainer").Click();

            var path = Path.Combine(@"C:\Temp", "wallpaper.jpeg");
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"Control Panel\Desktop", true);
            key.SetValue(@"WallpaperStyle", 2.ToString());
            key.SetValue(@"TileWallpaper", 0.ToString());

            Console.Clear();

            while (true)
            {
                driver.GetScreenshot().SaveAsFile(path, ScreenshotImageFormat.Jpeg);

                SystemParametersInfo(SetDeskWallpaper, 0, path, UpdateIniFile | SendWinIniChange);

                Console.Clear();
                Console.WriteLine("Last updated at " + DateTime.Now.ToString());

                Thread.Sleep(60000);
            }
        }
    }
}