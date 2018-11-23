using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectForCourses
{
    public class Base
    {
        private readonly bool _isGrid = false;

        protected IWebDriver _driver;
        protected WebDriverWait _webDriverWait;

        [SetUp]
        public void StartBrowser()
        {
            if (_isGrid)
            {
                var capabilities = new ChromeOptions().ToCapabilities();
                var commandTimeout = TimeSpan.FromMinutes(5);
                _driver = new RemoteWebDriver(new Uri("http://10.7.11.188:4435/wd/hub"), capabilities, commandTimeout);
            }
            else
                _driver = new ChromeDriver();

            _driver.Url = "about:blank";
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(4);
            _webDriverWait = new WebDriverWait(_driver, TimeSpan.FromSeconds(3));
        }

        [TearDown]
        public void CloseBrowser()
        {
            _driver.Quit();
        }
    }
}
