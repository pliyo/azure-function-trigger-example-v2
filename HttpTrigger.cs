
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using Microsoft.Extensions.Primitives;
using System.Linq;

namespace Company.Function
{
    public static class HttpTrigger
    {
        [FunctionName("HttpTrigger")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", Route = null)]HttpRequest req, TraceWriter log)
        {
            log.Info("C# HTTP trigger function processed a request.");

            if (req.Query.TryGetValue("productid", out StringValues value)) {
                return new OkObjectResult($"The product name for your product id {value.First()} is Starfruit Explosion and the description is This starfruit ice cream is out of this world!");
            }

            return new BadRequestObjectResult("Please pass a productid on the query string or in the request body");
        }
    }
}
