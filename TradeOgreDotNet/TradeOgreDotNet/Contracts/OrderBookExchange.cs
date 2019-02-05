// -----------------------------------------------------------------------------
// <copyright file="OrderBook" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/2/2019 9:56:17 PM" />
// -----------------------------------------------------------------------------

namespace TradeOgre.Net.Contracts
{
    #region Usings

    using Newtonsoft.Json;
    using System.Collections.Generic;

    #endregion Usings

    public class OrderBookExchange : ResponseBase
    {
        #region Properties

        [JsonProperty(PropertyName = "buy")]
        public Dictionary<decimal, decimal> Buy { get; set; }

        [JsonProperty(PropertyName = "sell")]
        public Dictionary<decimal, decimal> Sell { get; set; }

        #endregion Properties
    }
}