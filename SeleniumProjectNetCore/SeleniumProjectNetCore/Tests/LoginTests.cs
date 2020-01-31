using NUnit.Framework;
using SeleniumProjectNetCore.Models;
using SeleniumProjectNetCore.Pages;
using SeleniumProjectNetCore.TestFaceClient;
using SeleniumProjectNetCore.Tests.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumProjectNetCore.Tests
{
    [TestFixture]
    public class LoginTests : TestBase
    {
        static List<Login> LoginTestData = TestFace.GetTestData<Login>("Login");

        [Test, TestCaseSource("LoginTestData")]
        public void LoginTest(Login loginCredentials)
        {
            LoginPage = new LoginPage(Driver);
            EmployeePage EmployeePage = LoginPage.Login(loginCredentials.User, loginCredentials.Pass);

            Assert.IsTrue(EmployeePage.Displayed());
        }
    }
}
