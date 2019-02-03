// -----------------------------------------------------------------------------
// <copyright file="Ticker" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/2/2019 9:47:33 PM" />
// -----------------------------------------------------------------------------

namespace TradeOgreDotNet.Contracts
{
    #region Usings

    using Newtonsoft.Json;

    #endregion Usings

    public class Ticker
    {
        #region Properties

        public string TradingPair { get; set; }

        [JsonProperty(PropertyName = "intialprice")]
        public decimal InitialPrice { get; set; }

        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }

        [JsonProperty(PropertyName = "high")]
        public decimal High { get; set; }

        [JsonProperty(PropertyName = "low")]
        public decimal Low { get; set; }

        [JsonProperty(PropertyName = "volume")]
        public decimal Volume { get; set; }

        [JsonProperty(PropertyName = "bid")]
        public decimal Bid { get; set; }

        [JsonProperty(PropertyName = "ask")]
        public decimal Ask { get; set; }

        #endregion Properties
    }
}