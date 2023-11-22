using System;
using System.Net;
using System.Reflection.Emit;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;

namespace SpecFlowRestSharp.StepDefinitions
{
    [Binding]
    public sealed class GETStepDefinitions
    {
        private RestClient restClient = new RestClient("https://reqres.in/api");
        private RestRequest restRequest;
        private IRestResponse restResponse;

        [Given("I executed GET with (.*)")]
        public void IExecutedGetWith(string listOfUsers)
        {
            restRequest = new RestRequest(listOfUsers, Method.GET);
            restResponse = restClient.Execute(restRequest);

        }
        [Then("the Status Code should be (.*)")]
        public void ThenStatusCodeShouldBe(int code)
        {
            HttpStatusCode statusCode = restResponse.StatusCode;
            Assert.AreEqual(code, (int)statusCode);
            var content = restResponse.Content;
            Console.WriteLine(content);
        }

        [Then(@"the payload should be (.*) (.*) (.*)")]
        public void ThenThePayloadShouldBe(string fname, string lname, string email)
        {
  
            dynamic jObject = JObject.Parse(restResponse.Content);

            if (fname != "")
            {
                Assert.AreEqual(fname, jObject.data.first_name.ToString());
                Assert.AreEqual(lname, jObject.data.last_name.ToString());
                Assert.AreEqual(email, jObject.data.email.ToString());
            }
        }

        [Then(@"the payload for the list should be (.*) (.*) (.*)")]
        public void ThenThePayloadForTheListShouldBe(int pageNumber, int numberOfData, int dataPerPage)
        {
            dynamic jObject = JObject.Parse(restResponse.Content);

            Assert.AreEqual(pageNumber, (int)jObject.page);
            Assert.AreEqual(numberOfData, (int)jObject.total);
            Assert.AreEqual(dataPerPage, (int)jObject.per_page);
        }

        [Given(@"I executed PUT/PATCH with ""([^""]*)"" ""([^""]*)"" ""([^""]*)"" ""([^""]*)""")]
        public void GivenIExecutedPUTWith(string url, string name, string job, string action)
        {
            if (action == "put")
            {
                restRequest = new RestRequest(url, Method.PUT);
            }
            else if (action == "patch")
            {
                restRequest = new RestRequest(url, Method.PATCH);
            }
            else
            {
                Console.WriteLine("Action is not supported");
            }
            restRequest.AddJsonBody(new
            {
                name = name,
                job = job
            });
            restResponse = restClient.Execute(restRequest);
        }

        [Then(@"the updated payload should be ""([^""]*)"" ""([^""]*)""")]
        public void ThenTheUpdatedPayloadShouldBe(string name, string job)
        {
            dynamic jObject = JObject.Parse(restResponse.Content);
            Console.WriteLine(jObject);

            Assert.AreEqual(name, jObject.name.ToString());
        }
    }
}
