using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
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

        [SetUp]
        public void StartBrowser()
        {
            if (_isGrid)
            {
                var capabilities = new ChromeOptions().ToCapabilities();
                var commandTimeout = TimeSpan.FromMinutes(5);
                _driver = new RemoteWebDriver(new Uri("http://localhost:4446/wd/hub"), capabilities, commandTimeout);
            }
            else
                _driver = new ChromeDriver();

            _driver.Url = "https://dev.by/registration";
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
        }

        [TearDown]
        public void CloseBrowser()
        {
            _driver.Close();
        }

        
    }
}
