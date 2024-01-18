using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework8.Pages
{
    public class WebTablesPage : BasePage
    {
        public WebTablesPage(IWebDriver driver) : base(driver)
        {
        }

        protected override string Url => "https://demoqa.com/webtables";

        private IWebElement _buttonAdd => _driver.FindElement(By.Id("addNewRecordButton"));
        private IWebElement _lineSearch => _driver.FindElement(By.Id("searchBox"));
        private IWebElement _buttonLineSearch => _driver.FindElement(By.ClassName("input-group-append"));
        private IWebElement _firstName => _driver.FindElement(By.XPath("//input[@id=\"firstName\"]"));
        private IWebElement _lastName => _driver.FindElement(By.XPath("//input[@id=\"lastName\"]"));
        private IWebElement _userEmail => _driver.FindElement(By.XPath("//input[@id=\"userEmail\"]"));
        private IWebElement _age => _driver.FindElement(By.XPath("//input[@id=\"age\"]"));
        private IWebElement _salary => _driver.FindElement(By.XPath("//input[@id=\"salary\"]"));
        private IWebElement _department => _driver.FindElement(By.XPath("//input[@id=\"department\"]"));
        private IWebElement _submitButton => _driver.FindElement(By.XPath("//*[@id=\"submit\"]"));

        public void AddNewAndFillRegistrationForm(string firstName, string lastName, string userEmail, string age, string salary, string department)
        {
            _buttonAdd.Click();

            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementToBeClickable(_firstName));
            _firstName.SendKeys(firstName);
            _lastName.SendKeys(lastName);
            _userEmail.SendKeys(userEmail);
            _age.SendKeys(age);
            _salary.SendKeys(salary);
            _department.SendKeys(department);
            _submitButton.Click();
            string xpath = "//div[text()=\"" + firstName + "\"]";
            wait.Until(ExpectedConditions.ElementIsVisible(By.XPath(xpath)));
        }
    }
}
