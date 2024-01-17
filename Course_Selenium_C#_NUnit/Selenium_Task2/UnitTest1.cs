using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Selenium_Task2
{
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void Test1()
        {
            var xpath = "//div[@class=\"card mt-4 top-card\"]";
            driver.Navigate().GoToUrl("http://demoqa.com/");
            IList<IWebElement> elements = driver.FindElements(By.XPath(xpath));

        }

        [Test]
        public void Test2()
        {
            var xpath = "//span[contains(text(), 'Practice Form')]//..";
            driver.Navigate().GoToUrl("https://demoqa.com/forms");
            IWebElement element = driver.FindElement(By.XPath(xpath));
        }

        [Test]
        public void Test3()
        {
            var xpath = "//a[contains(text(),'Main Item 3')]\r\n";
            driver.Navigate().GoToUrl("https://demoqa.com/menu");
            IWebElement element = driver.FindElement(By.XPath(xpath));
        }

        [TearDown]
        public void TearDown()
        {
            driver.Quit();
        }
    }
}