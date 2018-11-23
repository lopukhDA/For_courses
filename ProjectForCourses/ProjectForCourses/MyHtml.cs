using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectForCourses
{
    public class MyHtml
    {
        public By InputFields { get; set; } = By.XPath("//div[@id='input_fields']");
        public By FirstName { get; set; } = By.XPath(".//input[@name='firstname']");
        public By InputFile { get; set; } = By.XPath(".//input[@name='file']");
        public By Frame { get; set; } = By.XPath("//iframe[@class='my-frame']");
        public By LastName { get; set; } = By.XPath("//input[@id='lastName']");
        public By RadioButton { get; set; } = By.XPath("//input[@id='radio']");
    }

    public class MyHtmlTest : Base
    {
        private MyHtml _myHtml = new MyHtml();

        [Test]
        public void Test()
        {
            _driver.Navigate().GoToUrl("file:///C:/%D0%9A%D1%83%D1%80%D1%81%D1%8B/ForCourses/jstest/test.html");

            IWebElement inputFields = _driver.FindElement(_myHtml.InputFields);
            IWebElement firstName = inputFields.FindElement(_myHtml.FirstName);
            if(firstName.Enabled)
                firstName.SendKeys("First Name");

            IWebElement inputFile = _webDriverWait.Until(_driver => inputFields.FindElement(_myHtml.InputFile));
            inputFile.SendKeys("C:\\Курсы\\ForCourses\\jstest\\test.css");

            IWebElement frame = _driver.FindElement(_myHtml.Frame);
            _driver.SwitchTo().Frame(frame);
            IWebElement lastName = _driver.FindElement(_myHtml.LastName);
            lastName.SendKeys("Last Name");
            _driver.SwitchTo().DefaultContent();

            IWebElement radio = _driver.FindElement(_myHtml.RadioButton);
            new Actions(_driver).DoubleClick(radio).Build().Perform();

            IJavaScriptExecutor javaScriptExecutor = (IJavaScriptExecutor)_driver;
            string title = (string)javaScriptExecutor.ExecuteScript("return document.title");

        }
    }
}
