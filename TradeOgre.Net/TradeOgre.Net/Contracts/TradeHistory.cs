// -----------------------------------------------------------------------------
// <copyright file="TradeHistory" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/2/2019 10:07:35 PM" />
// -----------------------------------------------------------------------------

namespace TradeOgre.Net.Contracts
{
    #region Usings

    using Newtonsoft.Json;

    #endregion Usings

    public class TradeHistory
    {
        #region Properties

        [JsonProperty(PropertyName = "date")]
        public long Date { get; set; }

        [JsonProperty(PropertyName = "type")]
        public Side Side { get; set; }

        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }

        [JsonProperty(PropertyName = "quantity")]
        public decimal Quantity { get; set; }

        #endregion Properties
    }
}