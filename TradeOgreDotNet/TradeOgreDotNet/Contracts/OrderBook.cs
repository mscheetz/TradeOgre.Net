// -----------------------------------------------------------------------------
// <copyright file="OrderBook" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/2/2019 9:56:17 PM" />
// -----------------------------------------------------------------------------

namespace TradeOgreDotNet.Contracts
{
    using Newtonsoft.Json;
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Text;


    #endregion Usings

    public class OrderBook : ResponseBase
    {
        #region Properties

        [JsonProperty(PropertyName = "buy")]
        public Dictionary<decimal, decimal> Buy { get; set; }

        [JsonProperty(PropertyName = "sell")]
        public Dictionary<decimal, decimal> Sell { get; set; }

        #endregion Properties
    }
}