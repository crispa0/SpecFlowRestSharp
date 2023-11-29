using System;
using System.Net;
using System.Reflection.Emit;
using System.Security.Policy;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;
using NUnit.Framework;
using RestSharp;

namespace SpecFlowRestSharp.StepDefinitions
{
    [Binding]
    public sealed class PUTStepDefinitions
    {
        private RestClient restClient = new RestClient("https://reqres.in/api");
        private RestRequest restRequest;
        private IRestResponse restResponse;

        [Given(@"I executed PUT with ""([^""]*)"" ""([^""]*)"" ""([^""]*)""")]
        public void GivenIExecutedPUTWithUsersMorpheusZionResident(string url, string name, string job)
        {
            restRequest = new RestRequest(url, Method.PUT);

            restRequest.AddJsonBody(new
            {
                name = name,
                job = job
            });
            restResponse = restClient.Execute(restRequest);
        }

        [Then("the Status Code from PUT call should be (.*)")]
        public void ThenStatusCodeShouldBe(int code)
        {
            HttpStatusCode statusCode = restResponse.StatusCode;
            Assert.AreEqual(code, (int)statusCode);
            var content = restResponse.Content;
            Console.WriteLine(content);
        }

        [Then(@"the updated payload after PUT call should be ""([^""]*)"" ""([^""]*)""")]
        public void ThenTheUpdatedPayloadShouldBe(string name, string job)
        {
            dynamic jObject = JObject.Parse(restResponse.Content);
            Console.WriteLine(jObject);

            Assert.AreEqual(name, jObject.name.ToString());
            Assert.AreEqual(job, jObject.job.ToString());

        }
    }
}
