// NUnit 3 tests
// See documentation : https://github.com/nunit/docs/wiki/NUnit-Documentation
using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using RestSharp;
using System.Net;
using RestSharp.Serialization.Json;
using Newtonsoft.Json.Linq;

namespace SeleniumDemo
{
    [TestFixture]
    public class APIClass
    {
        String BaseURL = "https://petstore.swagger.io/v2";
        string GetEndpoint = "pet/";

        RestClient client;
       [Test]
        public void FindPetByIDPostMethod()
        {
            client = new RestClient(BaseURL);
            var request = new RestRequest(GetEndpoint, Method.POST);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { name = "yellow", status = "available" });
            request.AddUrlSegment("petId", 2);
            request.AddHeader("Accept", "application/json");

            // act
            IRestResponse response = client.Execute(request);
            var content = response.Content;

            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<Dictionary<string, string>>(response);
            
            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound),"Status is correct");
            
        }

        [Test]
        public void FindPetByIDGetMethod()
        {
            // arrange
            client = new RestClient(BaseURL);

            RestRequest request = new RestRequest(GetEndpoint, Method.GET);
            request.AddUrlSegment("petId", 1);
            // act
            IRestResponse response = client.Execute(request);
            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<Dictionary<string, string>>(response);
            Assert.That(output["name"], Is.EqualTo("Yellow"));
            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound));

        }
        [Test]
        public void FindPetByIDPutMethod()
        {
            client = new RestClient(BaseURL);
            var request = new RestRequest(GetEndpoint, Method.PUT);
            request.RequestFormat = DataFormat.Json;
            request.AddBody(new { name = "blue" });
            request.AddUrlSegment("petId", 2);
            request.AddHeader("Accept", "application/json");

            // act
            IRestResponse response = client.Execute(request);
            var content = response.Content;

            var deserialize = new JsonDeserializer();
            var output = deserialize.Deserialize<Dictionary<string, string>>(response);


            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.NotFound), "Status is correct");

        }

  

        [Test]
        public void FindPetByIDDeleteMethod()
        {
            // arrange
            client = new RestClient(BaseURL);

            RestRequest request = new RestRequest(GetEndpoint, Method.DELETE);
            request.AddUrlSegment("petId", 5);
            // act
            IRestResponse response = client.Execute(request);

            // assert
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

        }

    }
}
