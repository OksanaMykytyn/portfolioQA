using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;
using SeleniumExtras.WaitHelpers;

namespace Homework8.Tests
{
    public class Tests : BaseTest
    {
        
        [Test]
        public void CorrectWorkDoubleClick()
        {
            Pages.Buttons.Open();
            var actualResult = Pages.Buttons.ButtonDoubleClick();
            Assert.True(actualResult);
        }

        [Test]
        public void CorrectWorkRightClick()
        {
            Pages.Buttons.Open();
            var actualResult = Pages.Buttons.ButtonRightClick();
            Assert.True(actualResult);
        }

        [Test]
        public void CorrectWorkClick()
        {
            Pages.Buttons.Open();
            var actualResult = Pages.Buttons.ButtonClick();

            Assert.True(actualResult);
        }

        [Test]
        public void FillRegistrationForm()
        {
            Pages.WebTables.Open();
            var firsName = "FirstName";
            var lastName = "LastName";
            var userEmail = "email@gmail.com";
            var age = "19";
            var salary = "12000";
            var department = "department";
            Pages.WebTables.AddNewAndFillRegistrationForm(firsName, lastName, userEmail, age, salary, department);
        }

        [Test]
        public void NoCorrectEmailInlRegistrationForm()
        {
            Pages.WebTables.Open();
            var firsName = "FirstName";
            var lastName = "LastName";
            var userEmail = "emailgmail.com";
            var age = "19";
            var salary = "12000";
            var department = "department";
            Pages.WebTables.AddNewAndFillRegistrationForm(firsName, lastName, userEmail, age, salary, department);
        }

        [Test]
        public void EmptyAgelInlRegistrationForm()
        {
            Pages.WebTables.Open();
            var firsName = "FirstName";
            var lastName = "LastName";
            var userEmail = "email@gmail.com";
            var age = "";
            var salary = "12000";
            var department = "department";
            Pages.WebTables.AddNewAndFillRegistrationForm(firsName, lastName, userEmail, age, salary, department);
        }

    }
}