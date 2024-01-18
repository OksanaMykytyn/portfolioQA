// Generated by Selenium IDE
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using NUnit.Framework;
[TestFixture]
public class EnterformTest {
  private IWebDriver driver;
  public IDictionary<string, object> vars {get; private set;}
  private IJavaScriptExecutor js;
  [SetUp]
  public void SetUp() {
    driver = new ChromeDriver();
    js = (IJavaScriptExecutor)driver;
    vars = new Dictionary<string, object>();
  }
  [TearDown]
  protected void TearDown() {
    driver.Quit();
  }
  [Test]
  public void enterform() {
    driver.Navigate().GoToUrl("https://demoqa.com/automation-practice-form");
    driver.FindElement(By.XPath("//input[@id=\'firstName\']")).Click();
    driver.FindElement(By.XPath("//input[@id=\'firstName\']")).SendKeys("Name");
    driver.FindElement(By.XPath("//input[@id=\'lastName\']")).Click();
    driver.FindElement(By.XPath("//input[@id=\'lastName\']")).SendKeys("Surname");
    driver.FindElement(By.XPath("//input[@id=\'userEmail\']")).Click();
    driver.FindElement(By.XPath("//input[@id=\'userEmail\']")).SendKeys("name@example.com");
    driver.FindElement(By.XPath("//label[contains(.,\'Female\')]")).Click();
    driver.FindElement(By.XPath("//input[@id=\'userNumber\']")).Click();
    driver.FindElement(By.XPath("//input[@id=\'userNumber\']")).SendKeys("0999999999");
    driver.FindElement(By.XPath("//input[@id=\'dateOfBirthInput\']")).Click();
    driver.FindElement(By.XPath("//div[2]/select")).Click();
    {
      var dropdown = driver.FindElement(By.CssSelector(".react-datepicker__year-select"));
      dropdown.FindElement(By.XPath("//option[. = '2005']")).Click();
    }
    driver.FindElement(By.XPath("//select")).Click();
    {
      var dropdown = driver.FindElement(By.CssSelector(".react-datepicker__month-select"));
      dropdown.FindElement(By.XPath("//option[. = 'March']")).Click();
    }
    driver.FindElement(By.XPath("//div[2]/div/div[4]")).Click();
    driver.FindElement(By.XPath("//div[@id=\'subjectsContainer\']/div/div")).Click();
    driver.FindElement(By.XPath("//input[@id=\'subjectsInput\']")).SendKeys("Maths");
    driver.FindElement(By.XPath("//input[@id=\'subjectsInput\']")).SendKeys(Keys.Enter);
    driver.FindElement(By.XPath("//label[contains(.,\'Sports\')]")).Click();
    driver.FindElement(By.XPath("//label[contains(.,\'Reading\')]")).Click();
    driver.FindElement(By.XPath("//textarea[@id=\'currentAddress\']")).Click();
    js.ExecuteScript("window.scrollTo(0,0)");
    driver.FindElement(By.XPath("//textarea[@id=\'currentAddress\']")).SendKeys("Current Address");
    driver.FindElement(By.XPath("//button[@id=\'submit\']")).Click();
    driver.Close();
  }
}
