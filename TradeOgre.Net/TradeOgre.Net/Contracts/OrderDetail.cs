// -----------------------------------------------------------------------------
// <copyright file="OrderDetail" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/2/2019 10:35:25 PM" />
// -----------------------------------------------------------------------------

namespace TradeOgre.Net.Contracts
{
    #region Usings

    using Newtonsoft.Json;

    #endregion Usings

    public class OrderDetail : ResponseBase
    {
        #region Properties

        [JsonProperty(PropertyName = "date")]
        public long Date { get; set; }

        [JsonProperty(PropertyName = "type")]
        public Side Side { get; set; }

        [JsonProperty(PropertyName = "market")]
        public string TradingPair { get; set; }

        [JsonProperty(PropertyName = "price")]
        public decimal price { get; set; }

        [JsonProperty(PropertyName = "quantity")]
        public decimal Quantity { get; set; }

        [JsonProperty(PropertyName = "fulfilled")]
        public decimal Filled { get; set; }

        #endregion Properties
    }
}