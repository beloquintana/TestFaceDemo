﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using SeleniumProjectNetCore.Models;
using SeleniumProjectNetCore.Pages;
using SeleniumProjectNetCore.TestFaceClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumProjectNetCore.Tests.Base
{
    public abstract class TestBase
    {
        protected IWebDriver Driver;
        protected LoginPage LoginPage;

        [SetUp]
        public void BeforeEachTest()
        {
            var config = TestFace.GetConfigData<Config>();

            Driver = GetBrowserDriver(config.Browser);
            Driver.Navigate().GoToUrl(config.Url);
        }

        [TearDown]
        public void AfterEachTest()
        {
            if (Driver != null)
            {
                Driver.Quit();
            }
        }

        private IWebDriver GetBrowserDriver(string browser)
        {
            switch (browser)
            {
                case "Firefox":
                    return new FirefoxDriver();
                case "Chrome":
                    return new ChromeDriver();
                default:
                    throw new Exception("Browser " + browser + " not found");
            }
        }
    }
}
