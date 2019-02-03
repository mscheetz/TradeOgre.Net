// -----------------------------------------------------------------------------
// <copyright file="CurrencyBalances" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/2/2019 10:43:38 PM" />
// -----------------------------------------------------------------------------

namespace TradeOgreDotNet.Contracts
{
    #region Usings

    using Newtonsoft.Json;
    using System.Collections.Generic;

    #endregion Usings

    public class CurrencyBalances : ResponseBase
    {
        #region Properties

        [JsonProperty(PropertyName = "balances")]
        public Dictionary<string, decimal> Balances { get; set; }

        #endregion Properties
    }
}