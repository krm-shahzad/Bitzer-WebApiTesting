using System;
using System.Linq;
using Xunit;
using System.Net.Http;

namespace Bitzer_WebApiTesting
{
    public class WebApiTest
    {
        public static string Environment { get; } = "Development";
        public static string BaseUrl { get; set; }
           
        #region Constructor
        public WebApiTest()
        {
            if (Environment == "Development")
            {
                BaseUrl = "http://localhost:5003";
            }
            if (Environment == "Staging")
            {
                BaseUrl = "http://api.staging.lodam.com";
            }
            if (Environment == "production")
            {
                BaseUrl = "http://api.cloud.lodam.com";
            }

        }
        #endregion
        
        [Fact]
        public void GetRoles()
        {
            using (var client = new HttpClient())
            {

                var model = client
                            .GetAsync($"{BaseUrl}/api/identity")
                            .Result.Content.ReadAsStringAsync();

                Assert.NotNull(model);
            }
        }

        [Fact]
        public void GetGateways()
        {
            using (var client = new HttpClient())
            {

                var model = client
                            .GetAsync($"{BaseUrl}/api/Gateway")
                            .Result.Content.ReadAsStringAsync();

                Assert.NotNull(model);
            }
        }

        [Fact]
        public void GetBoundaries()
        {
            using (var client = new HttpClient())
            {

                var model = client
                            .GetAsync($"{ BaseUrl}/api/Boundary")
                            .Result.Content.ReadAsStringAsync();

                Assert.NotNull(model);
            }
        }



    }
}
