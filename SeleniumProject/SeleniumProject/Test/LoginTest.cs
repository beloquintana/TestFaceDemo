using Newtonsoft.Json;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RestSharp;
using SeleniumProject.Models;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumProject.Test
{
    [TestFixture]
    public class LoginTest
    {
        [Test]
        public void Login()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://verstandqa.com/login-employee-v2/");

            //Get Token
            var client = new RestClient("https://autenticationapidemo.azurewebsites.net/api/Auth/autenticate");
            var request = new RestRequest
            {
                Method = Method.POST,
                RequestFormat = DataFormat.Json
            };
            request.AddParameter("application/json", "{ \"username\": \"user\", \"password\": \"123\"}", ParameterType.RequestBody);
            var response = client.Execute(request);

            dynamic acces = JsonConvert.DeserializeObject<object>(response.Content);      
            //---

            //Get Data
            client = new RestClient("https://atcsapidemo.azurewebsites.net/api/DataTests/p1/gp1/Login");
            request = new RestRequest
            {
                Method = Method.GET,
                RequestFormat = DataFormat.Json
            };
            request.AddHeader("authorization", "Bearer " + acces.token);
            response = client.Execute(request);

            List<Login> list = JsonConvert.DeserializeObject<List<Login>>(response.Content);
            //---

            driver.FindElement(By.Id("user")).SendKeys(list.First().User);
            driver.FindElement(By.Id("pass")).SendKeys(list.First().Pass);
            driver.FindElement(By.Id("loginButton")).Click();

            driver.Quit();
        }
    }
}
