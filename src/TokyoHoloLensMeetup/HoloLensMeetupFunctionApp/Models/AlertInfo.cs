using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HoloLensMeetupFunctionApp.Models
{
    public class AlertInfo
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("message")]
        public string Message { get; set; }
    }
}
