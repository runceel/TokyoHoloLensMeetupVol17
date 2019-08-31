using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.SignalRService;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace HoloLensMeetupFunctionApp
{
    public class SignalRFunctions
    {
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
    }
}
