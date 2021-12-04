using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace GRE_PortfolioAPI
{
    public class GREApi
    {
        [FunctionName("GetPortfolios")]
        public IActionResult GetPortfolios(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");
            
            return new OkObjectResult(new List<Portfolio>() { new Portfolio() { Id = 1, Name = "Swiss Assets"}, new Portfolio() { Id = 2, Name = "US Assets" } });
        }

        [FunctionName("GetPortfolioBalance")]
        public IActionResult GetPortfolioBalance(
            [HttpTrigger(AuthorizationLevel.Function, "get" , Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            return new OkObjectResult(new PortfolioBalance() { Id = 1, Balance = 10000 });
        }

        [FunctionName("GetAdminInfo")]
        public IActionResult GetAdminInfo(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            return new OkObjectResult(new AdminInfo());
        }
    }

    public class Portfolio
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class PortfolioBalance
    {
        public int Id { get; set; }
        public decimal  Balance { get; set; }
    }

    public class AdminInfo
    {
        public string Message { get; set; } = "Your permission has been granted by Admin";
    }
}
