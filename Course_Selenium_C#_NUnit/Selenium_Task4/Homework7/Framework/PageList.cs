using Homework8.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework8.Framework
{
    public class PageList
    {
        public ButtonsPage Buttons => _buttons ??= new ButtonsPage(_driver);
        private ButtonsPage _buttons;

        public WebTablesPage WebTables => _webTables ??= new WebTablesPage(_driver);
        private WebTablesPage _webTables;

        private readonly IWebDriver _driver;

        public PageList(IWebDriver driver)
        {
            _driver = driver;
        }

    }
}
