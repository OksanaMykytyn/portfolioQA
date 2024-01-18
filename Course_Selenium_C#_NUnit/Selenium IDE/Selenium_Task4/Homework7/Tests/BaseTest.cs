using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Homework8.Framework;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using NUnit.Framework.Interfaces;
using AventStack.ExtentReports.Reporter;


namespace Homework8.Tests
{
    public class BaseTest
    {
        protected ExtentReports extentReports;
        protected ExtentTest extentTest;
        protected IWebDriver Driver { get; set; }
        protected PageList Pages { get; private set; }

        [OneTimeSetUp]
        public void SetupReporting()
        {
            extentReports = new ExtentReports();
            string reportPath = @"C:\Users\Admin\Desktop\Інститут\Selenium\MyReport.html";
            var htmlReporter = new ExtentHtmlReporter(reportPath);
            extentReports.AttachReporter(htmlReporter);
        }

        [SetUp]
        public void Setup()
        {
            Driver = DriverHelper.GetDriver();
            Pages = new PageList(Driver);
            extentTest = extentReports.CreateTest(TestContext.CurrentContext.Test.FullName);
        }

        [TearDown]
        public void TearDown()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status == TestStatus.Passed)
            {
                extentTest.Log(Status.Pass);
            }
            else
            {
                var path = DriverHelper.MakeScreenshot(Driver, TestContext.CurrentContext.Test.MethodName);
                extentTest.AddScreenCaptureFromPath(path);
                extentTest.Log(Status.Fail);
            }
            Driver.Quit();
        }

        [OneTimeTearDown]
        public void FlushReport()
        {
            extentReports.Flush();
        }
    }
}
