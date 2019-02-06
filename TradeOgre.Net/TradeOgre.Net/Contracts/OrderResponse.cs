// -----------------------------------------------------------------------------
// <copyright file="OrderResponse" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/2/2019 10:23:01 PM" />
// -----------------------------------------------------------------------------

namespace TradeOgre.Net.Contracts
{
    #region Usings

    using Newtonsoft.Json;

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