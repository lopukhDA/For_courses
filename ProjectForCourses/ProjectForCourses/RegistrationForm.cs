using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectForCourses
{
    public class RegistrationFormManager
    {
        public By Username_Input { get; set; } = By.XPath("//input[@id='user_username']");
        public By Email_Input { get; set; } = By.Id("user_email");
        public By Password_Input { get; set; } = By.CssSelector("#user_password");
        public By PasswordConfirm_Input { get; set; } = By.Name("user[password_confirmation]");
        public By Name_Input { get; set; } = By.XPath("//input[@id='user_first_name']");
        public By LastName_Input { get; set; } = By.XPath("//input[@id='user_last_name']");
        public By Position_Input { get; set; } = By.XPath("//input[@id='user_current_position']");
        public By Company_Link { get; set; } = By.XPath("//div[@id='s2id_current_company_id']");
        public By Company_Input { get; set; } = By.XPath("//input[@id='s2id_autogen1_search']");
        public By Company_List { get; set; } = By.CssSelector(".select2-match");
        public By Agreement_Checkbox { get; set; } = By.XPath("//input[@id='user_agreement']//..");
        public By Submit_Button { get; set; } = By.XPath("//input[contains(@class, 'submit')]");


        public void FillForm(IWebDriver driver, RegistrationFormConfig config)
        {
            driver.FindElement(Username_Input).SendKeys(config.Username);
            driver.FindElement(Email_Input).SendKeys(config.Email);
            driver.FindElement(Password_Input).SendKeys(config.Password);
            driver.FindElement(PasswordConfirm_Input).SendKeys(config.Password);
            driver.FindElement(Name_Input).SendKeys(config.Name);
            driver.FindElement(LastName_Input).SendKeys(config.LastName);
            driver.FindElement(Position_Input).SendKeys(config.Position);
            driver.FindElement(Company_Link).Click();
            driver.FindElement(Company_Input).SendKeys(config.Company);
            driver.FindElement(Company_List).Click();

            var checkboxAgreement = driver.FindElement(Agreement_Checkbox);
            var stateAgreement = checkboxAgreement.GetAttribute("class").Contains("Off") ? false : true;
            if (stateAgreement != config.Agreement)
            {
                checkboxAgreement.Click();
            }
        }

        public void Submit(IWebDriver driver)
        {
            driver.FindElement(Submit_Button).Click();
        }
    }
}
