// -----------------------------------------------------------------------------
// <copyright file="Order" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/2/2019 10:30:32 PM" />
// -----------------------------------------------------------------------------

namespace TradeOgre.Net.Contracts
{
    #region Usings

    using Newtonsoft.Json;

    #endregion Usings

    public class Order
    {
        #region Properties

        [JsonProperty(PropertyName = "uuid")]
        public string OrderId { get; set; }

        [JsonProperty(PropertyName = "date")]
        public long OrderDate { get; set; }

        [JsonProperty(PropertyName = "type")]
        public Side Side { get; set; }

        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }

        [JsonProperty(PropertyName = "quantity")]
        public decimal Quantity { get; set; }

        [JsonProperty(PropertyName = "market")]
        public string TradingPair { get; set; }

        #endregion Properties
    }
}