using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework8.Framework
{
    public class DriverHelper
    {
        public static IWebDriver GetDriver()
        {
            var driver = new ChromeDriver();

            driver.Manage().Window.Maximize();

            return driver;
        }

        internal static string MakeScreenshot(IWebDriver driver, string testName)
        {
            string screenshotsFolder = @"C:\Users\Admin\Desktop\Інститут\Selenium\Reports";
            string screenshotPath = string.Empty;

            if (driver != null)
            {
                Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();

                var dateTimeStr = DateTime.Now.ToString("yyyy-MM-dd-hhmm-ss");
                var screenhotName = $"{testName}-{dateTimeStr}.png";

                screenshotPath = Path.Combine(screenshotsFolder, screenhotName);
                screenshot.SaveAsFile(screenshotPath, ScreenshotImageFormat.Png);
            }

            return screenshotPath;
        }
    }

    
}
