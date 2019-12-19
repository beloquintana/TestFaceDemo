using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumProject.Pages
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
