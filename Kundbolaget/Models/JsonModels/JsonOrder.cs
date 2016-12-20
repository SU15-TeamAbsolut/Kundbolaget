using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Kundbolaget.Models.JsonModels
{
    public class JsonOrder
    {
        [JsonProperty(Required = Required.Always)]
        public int CustomerId { get; set; }
        [JsonProperty(Required = Required.AllowNull)]
        public int? CustomerOrderRef { get; set; }
        [JsonProperty(Required = Required.Always)]
        public DateTime DeliveryDate { get; set; }
        [JsonProperty(Required = Required.Always)]
        public int DeliveryAddressId { get; set; }
        [JsonProperty(Required = Required.Always)]
        public IEnumerable<JsonOrderRow> OrderRows { get; set; }
    }
}
