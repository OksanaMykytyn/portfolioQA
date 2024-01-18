using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace Homework8.Pages
{
    public class ButtonsPage : BasePage
    {
        public ButtonsPage(IWebDriver driver) : base(driver)
        {
        }

        //for https://demoqa.com/buttons
        private IWebElement _buttonDoubleClick => _driver.FindElement(By.Id("doubleClickBtn"));
        private IWebElement _buttonRightClick => _driver.FindElement(By.Id("rightClickBtn"));
        private IWebElement _buttonClick => _driver.FindElement(By.XPath("//*[text() =\"Click Me\"]"));

        protected override string Url => "https://demoqa.com/buttons";

        public bool ButtonDoubleClick()
        {
            Actions act = new Actions(_driver);
            act.DoubleClick(_buttonDoubleClick).Perform();
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(15));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("doubleClickMessage")));

            return true;
        }

        public bool ButtonRightClick()
        {
            _buttonRightClick.SendKeys(Keys.Shift + Keys.F10);

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("rightClickMessage")));

            return true;
        }

        public bool ButtonClick()
        {
            _buttonClick.Click();
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementIsVisible(By.Id("dynamicClickMessage")));

            return true;
        }

        

        

    }
}
