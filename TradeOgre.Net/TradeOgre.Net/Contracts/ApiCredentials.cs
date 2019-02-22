// -----------------------------------------------------------------------------
// <copyright file="ApiCredentials" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/2/2019 9:41:49 PM" />
// -----------------------------------------------------------------------------

using Newtonsoft.Json;

namespace TradeOgre.Net.Contracts
{
    public class ApiCredentials
    {
        #region Properties

        [JsonProperty(PropertyName = "apiKey")]
        public string ApiKey { get; set; }

        [JsonProperty(PropertyName = "apiSecret")]
        public string ApiSecret { get; set; }

        #endregion Properties
    }
}