using NUnit.Framework;
using SeleniumProject.Models;
using SeleniumProject.Pages;
using SeleniumProject.TestFaceClient;
using SeleniumProject.Tests.Base;
using System.Collections.Generic;

namespace SeleniumProject.Tests
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
