using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectForCourses
{
    [Parallelizable(ParallelScope.Self)]
    [Description("Demo test for course")]
    public class Demo : Base
    {
        private RegistrationFormManager _regFormManager = new RegistrationFormManager();
        private RegistrationFormConfig _config = new RegistrationFormConfig()
        {
            Username = RandomString(10),
            Email = RandomString(8) + "@test.com",
            Password = RandomString(10),
            Name = RandomString(6),
            LastName = RandomString(6),
            Position = "Test",
            Company = "EPAM",
            Agreement = true,
        };


        [Test]
        public void Test()
        {
            _regFormManager.FillForm(_driver, _config);
            _regFormManager.Submit(_driver);
        }
    }
}
