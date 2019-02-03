// -----------------------------------------------------------------------------
// <copyright file="OrderResponse" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/2/2019 10:23:01 PM" />
// -----------------------------------------------------------------------------

namespace TradeOgreDotNet.Contracts
{
    using Newtonsoft.Json;
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Text;


    #endregion Usings

    public class OrderResponse : ResponseBase
    {
        #region Properties

        [JsonProperty(PropertyName = "uuid")]
        public string OrderId { get; set; }

        [JsonProperty(PropertyName = "bnewbalavail")]
        public decimal BuyBalance { get; set; }

        [JsonProperty(PropertyName = "snewbalavail")]
        public decimal SellBalance { get; set; }

        #endregion Properties
    }
}