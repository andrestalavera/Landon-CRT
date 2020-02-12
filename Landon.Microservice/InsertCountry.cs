using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Net.Http;
using Landon.Models;

namespace Landon.Microservices.Countries.Insert
{
    public static class InsertCountry
    {
        private const string API_URL = "";

        [FunctionName("InsertCountry")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            string label = req.Query["label"];

            var country = new Country
            {
                Id = Guid.NewGuid().ToString(),
                Label = label
            };

            var json = JsonConvert.SerializeObject(country);

            using var httpClient = new HttpClient();
            var response = await httpClient.PostAsync(API_URL, new StringContent(json));
            return response.IsSuccessStatusCode ? (ActionResult)new OkObjectResult($"'{country.Label}' inserted") :
                new BadRequestObjectResult("Une erreur s'est produite");
        }
    }
}
