﻿using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Configuration;
using NUnit.Framework;

namespace SeleniumProject.TestFaceClient
{
    public class TestFace
    {
        private const string AUTENTICATION_API = "https://autenticationapidemo.azurewebsites.net/api/Auth/autenticate";
        private const string TESTFACE_API = "https://atcsapidemo.azurewebsites.net/api";

        private static string Login()
        {
            var client = new RestClient(AUTENTICATION_API);
            var request = new RestRequest
            {
                Method = Method.POST,
                RequestFormat = DataFormat.Json
            };

            var credentials = new
            {
                username = ConfigurationManager.AppSettings["UserName"],
                password = ConfigurationManager.AppSettings["Password"]
            };

            request.AddParameter("application/json", credentials, ParameterType.RequestBody);
            var response = client.Execute(request);

            dynamic access = JsonConvert.DeserializeObject<object>(response.Content);
            return access.token;
        }

        public static List<T> GetTestData<T>(string testName)
        {
            string token = Login();
            var projectName = ConfigurationManager.AppSettings["ProjectName"];
            var groupTestData = ConfigurationManager.AppSettings["GroupTestData"];

            var client = new RestClient(TESTFACE_API + "/DataTests/"+ projectName + "/" + groupTestData +"/" + testName);
            var request = new RestRequest
            {
                Method = Method.GET,
                RequestFormat = DataFormat.Json
            };
            request.AddHeader("authorization", "Bearer " + token);
            var response = client.Execute(request);

            return JsonConvert.DeserializeObject<List<T>>(response.Content);
        }

        public static T GetConfigData<T>()
        {
            string token = Login();
            var projectName = ConfigurationManager.AppSettings["ProjectName"];
            var configName = ConfigurationManager.AppSettings["ConfigName"];

            var client = new RestClient(TESTFACE_API + "/ProjectConfigDatas/" + projectName + "/" + configName);
            var request = new RestRequest
            {
                Method = Method.GET,
                RequestFormat = DataFormat.Json
            };
            request.AddHeader("authorization", "Bearer " + token);
            var response = client.Execute(request);

            return JsonConvert.DeserializeObject<T>(response.Content);
        }
    }
}
