using HoloLensMeetupFunctionApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Documents;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HoloLensMeetupFunctionApp
{
    public class SignalRFunctions
    {
        private readonly ILogger _log;

        public SignalRFunctions(ILoggerFactory loggerFactory)
        {
            _log = loggerFactory.CreateLogger<SignalRFunctions>();
        }

        [FunctionName("negotiate")]
        public SignalRConnectionInfo Negotiate([HttpTrigger]HttpRequest req,
            [SignalRConnectionInfo(HubName = "hololens")]SignalRConnectionInfo connectionInfo) => connectionInfo;

        [FunctionName(nameof(SendMessage))]
        public static async Task<IActionResult> SendMessage([HttpTrigger]HttpRequest req,
            [SignalR(HubName = "hololens")]IAsyncCollector<SignalRMessage> messages)
        {
            await messages.AddAsync(new SignalRMessage
            {
                Target = "addMessage",
                Arguments = new object[] { (string)req.Query["message"] }
            });
            return new OkResult();
        }

        [FunctionName("SampleFunction")]
        public async Task<IActionResult> SampleFunction(
            [HttpTrigger(AuthorizationLevel.Function, "post", "get", Route = "sample")]HttpRequest req)
        {
            string name = req.Query["name"];
            if (string.IsNullOrEmpty(name))
            {
                return new BadRequestResult();
            }

            return new OkObjectResult($"Hello {name}");
        }

        [FunctionName("CosmosDbTriggerSample")]
        public async Task CosmosDbSample(
            [CosmosDBTrigger(
                "dbName",
                "alert",
                ConnectionStringSetting = "CosmosDb",
                CreateLeaseCollectionIfNotExists = true,
                LeaseCollectionPrefix = "hololens")]IReadOnlyList<Document> documents,
            [SignalR(HubName = "hololens")]IAsyncCollector<SignalRMessage> messages,
            ILogger log)
        {
            var alerts = documents.Select(x => (AlertInfo)(dynamic)x);
            foreach (var m in alerts.Select(
                x => new SignalRMessage
                {
                    Target = "addMessage",
                    Arguments = new object[] { x.Message }
                }))
            {
                await messages.AddAsync(m);
                log.LogInformation($"Alert added: {m.Arguments.First()}");
            }
        }

        [FunctionName("CosmosDbInput")]
        public async Task<IActionResult> CosmosDbInputSample(
            [HttpTrigger]HttpRequest req,
            [CosmosDB("dbName", "alert", ConnectionStringSetting = "CosmosDb", Id = "{Query.id}")]AlertInfo alert,
            [CosmosDB("dbName", "alert-read-histories", ConnectionStringSetting = "CosmosDb", CreateIfNotExists = true)]IAsyncCollector<History> histories)
        {
            if (alert == null)
            {
                return new NotFoundResult();
            }

            await histories.AddAsync(new History { Timestamp = DateTimeOffset.UtcNow, Snapshot = alert });
            return new OkObjectResult(alert);
        }

    }
}
