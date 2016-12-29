using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace Kundbolaget.Models.JsonModels
{
    public class JsonReturnFile
    {
        [JsonProperty(Required = Required.Always)]
        public int? CustomerId { get; set; }
        [JsonProperty(Required = Required.Always)]
        public IList<JsonCustomerOrder> Orders { get; set; }
    }
}