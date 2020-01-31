using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumProjectNetCore.Pages
{
    public class EmployeePage
    {
        private IWebDriver Driver;
        private By ContentEmployee = By.Id("contentEmployee");
        public EmployeePage(IWebDriver driver)
        {
            this.Driver = driver;
        }

        public bool Displayed()
        {
            return Driver.FindElement(ContentEmployee).Displayed;
        }
    }
}
