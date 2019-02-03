// -----------------------------------------------------------------------------
// <copyright file="ResponseBase" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/2/2019 9:55:02 PM" />
// -----------------------------------------------------------------------------

namespace TradeOgreDotNet.Contracts
{
    using Newtonsoft.Json;
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Text;


    #endregion Usings

    public class ResponseBase
    {
        #region Properties

        [JsonProperty(PropertyName = "success")]
        public bool Success { get; set; }

        #endregion Properties
    }
}