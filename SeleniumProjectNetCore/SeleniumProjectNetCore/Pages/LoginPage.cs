using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumProjectNetCore.Pages
{
    public class LoginPage
    {
        private IWebDriver Driver;
        private By UserName = By.Id("user");
        private By PassWord = By.Id("pass");
        private By LoginButton = By.Id("loginButton");
        public LoginPage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        public EmployeePage Login(string user, string pass)
        {
            Driver.FindElement(UserName).SendKeys(user);
            Driver.FindElement(PassWord).SendKeys(pass);
            Driver.FindElement(LoginButton).Click();

            return new EmployeePage(Driver);
        }
    }
}
