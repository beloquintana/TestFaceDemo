using Newtonsoft.Json;
using RestSharp;
using SeleniumProjectNetCore.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumProjectNetCore.TestFaceClient
{
    public class TestFace
    {
        private const string AUTENTICATION_API = "http://localhost:50501/api/Auth/autenticate";
        private const string TESTFACE_API = "http://localhost:61313/api";

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
                username = FWConfig.Instance.GetValue("Configuration:UserName"),
                password = FWConfig.Instance.GetValue("Configuration:Password")
            };

            request.AddParameter("application/json", credentials, ParameterType.RequestBody);
            var response = client.Execute(request);

            dynamic access = JsonConvert.DeserializeObject<object>(response.Content);
            return access.token;
        }

        public static List<T> GetTestData<T>(string testName)
        {
            string token = Login();
            var projectName = FWConfig.Instance.GetValue("Configuration:ProjectName");
            var groupTestData = FWConfig.Instance.GetValue("Configuration:GroupTestData");

            var client = new RestClient(TESTFACE_API + "/DataTests/" + projectName + "/" + groupTestData + "/" + testName);
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
            var projectName = FWConfig.Instance.GetValue("Configuration:ProjectName");
            var configName = FWConfig.Instance.GetValue("Configuration:ConfigName");

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
