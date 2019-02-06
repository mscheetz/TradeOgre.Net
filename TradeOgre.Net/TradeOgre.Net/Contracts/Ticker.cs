// -----------------------------------------------------------------------------
// <copyright file="Ticker" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/2/2019 9:47:33 PM" />
// -----------------------------------------------------------------------------

namespace TradeOgre.Net.Contracts
{
    #region Usings

    using Newtonsoft.Json;

    #endregion Usings

    public class Ticker
    {
        #region Properties

        public string TradingPair { get; set; }

        [JsonProperty(PropertyName = "initialprice")]
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

        #region Constructor

        public Ticker()
        { }

        public Ticker(Ticker ticker)
        {
            this.Ask = ticker.Ask;
            this.Bid = ticker.Bid;
            this.High = ticker.High;
            this.InitialPrice = ticker.InitialPrice;
            this.Low = ticker.Low;
            this.Price = ticker.Price;
            this.Volume = ticker.Volume;
        }

        #endregion Constructor
    }
}