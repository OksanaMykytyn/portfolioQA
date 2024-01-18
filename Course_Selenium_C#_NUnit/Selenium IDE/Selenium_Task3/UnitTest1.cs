using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace Selenium_Task3
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

            var actions = new Actions(driver);

            driver.Navigate().GoToUrl("https://demoqa.com/");
            var formsButton = driver.FindElement(By.XPath("//*[contains(text(), 'Forms')]//..//..//.."));
            driver.Manage().Window.Maximize();
            formsButton.Click();

            var practiceFormButton = driver.FindElement(By.XPath("//*[contains(text(), 'Practice Form')]/.."));
            practiceFormButton.Click();

            var firstNameInput = driver.FindElement(By.XPath("//*[@id='firstName']"));
            firstNameInput.SendKeys("FirsName");

            var lastNameInput = driver.FindElement(By.XPath("//*[@id='lastName']"));
            lastNameInput.SendKeys("LastName");

            var emailInput = driver.FindElement(By.XPath("//*[@id='userEmail']"));
            emailInput.SendKeys("email@gmail.com");

            var genderfemaleInput = driver.FindElement(By.XPath("//*[contains(text(), 'Female')]"));
            genderfemaleInput.Click();

            var phoneInput = driver.FindElement(By.XPath("//*[@id='userNumber']"));
            phoneInput.SendKeys("+380231674356");

            var dateofbirthInput = driver.FindElement(By.XPath("//*[@id='dateOfBirthInput']"));
            dateofbirthInput.Click();

            var monthElement = driver.FindElement(By.XPath("//*[@class='react-datepicker__month-select']"));
            var monthSelectElement = new SelectElement(monthElement);
            monthSelectElement.SelectByText("February");

            var yearsElement = driver.FindElement(By.XPath("//*[@class='react-datepicker__year-select']"));
            var yearsSelectElement = new SelectElement(yearsElement);
            yearsSelectElement.SelectByText("2005");

            var dayElement = driver.FindElement(By.XPath("//*[text()='19']"));
            dayElement.Click();

            var subjectInput = driver.FindElement(By.XPath("//*[@id='subjectsInput']"));
            subjectInput.SendKeys("Maths");
            subjectInput.SendKeys(Keys.Enter);

            var hobbiesInput1 = driver.FindElement(By.XPath("//*[@id=\"hobbies-checkbox-1\"]"));
            actions.MoveToElement(hobbiesInput1);
            hobbiesInput1.Click();

            var hobbiesInput2 = driver.FindElement(By.XPath("//*[contains(text(), 'Reading')]/.."));
            hobbiesInput2.Click();

            var uploadPictureInput = driver.FindElement(By.XPath("//*[@id='uploadPicture']"));
            uploadPictureInput.SendKeys("D:\\Основне\\Книги\\Історія Ксені\\Обкладинка.jpg");

            var currentAddressInput = driver.FindElement(By.XPath("//*[@id='currentAddress']"));
            actions.MoveToElement(currentAddressInput).Perform();
            currentAddressInput.SendKeys("Current Address");

            var stateElement = driver.FindElement(By.XPath("//*[@id='state']"));
            actions.MoveToElement(stateElement).Perform();
            var stateSelectElement = new SelectElement(stateElement);
            stateSelectElement.SelectByText("NCR");

            var cityElement = driver.FindElement(By.XPath("//*[@id='city']"));
            actions.MoveToElement(cityElement).Perform();
            var citySelectElement = new SelectElement(cityElement);
            citySelectElement.SelectByIndex(1);

            Thread.Sleep(10 * 1000);
        }

        [TearDown] public void TearDown()
        {
            driver.Quit();
        }
    }
}