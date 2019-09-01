using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HoloLensMeetupFunctionApp.Models
{
    public class History
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("timestamp")]
        public DateTimeOffset Timestamp { get; set; }
        [JsonProperty("snapshot")]
        public AlertInfo Snapshot { get; set; }
    }
}
