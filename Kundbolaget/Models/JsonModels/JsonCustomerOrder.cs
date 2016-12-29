using System;
using System.Collections.Generic;
using Kundbolaget.Models.EntityModels;
using Newtonsoft.Json;

namespace Kundbolaget.Models.JsonModels
{
    public class JsonCustomerOrder
    {
        [JsonProperty(Required = Required.Always)]
        public int CustomerId { get; set; }
        [JsonProperty(Required = Required.DisallowNull, NullValueHandling = NullValueHandling.Ignore)]
        public int? CustomerOrderRef { get; set; }
        [JsonProperty(Required = Required.Always)]
        public DateTime DeliveryDate { get; set; }
        [JsonProperty(Required = Required.Always)]
        public int DeliveryAddressId { get; set; }
        [JsonProperty(Required = Required.Always)]
        public IList<JsonOrderRow> OrderRows { get; set; } = new List<JsonOrderRow>();

        public JsonCustomerOrder()
        {
            
        }

        public JsonCustomerOrder(Order order)
        {
            CustomerId = order.CustomerId;
            CustomerOrderRef = order.CustomerOrderRef;
            DeliveryDate = order.DesiredDeliveryDate;
            DeliveryAddressId = order.ShippingAddressId;

            foreach (var row in order.OrderRows)
            {
                OrderRows.Add(new JsonOrderRow
                {
                    ArticleId = row.ProductId,
                    Amount = row.AmountOrdered
                });
            }
        }
    }
}
