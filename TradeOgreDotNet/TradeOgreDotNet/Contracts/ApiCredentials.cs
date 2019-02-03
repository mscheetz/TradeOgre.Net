// -----------------------------------------------------------------------------
// <copyright file="ApiCredentials" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/2/2019 9:41:49 PM" />
// -----------------------------------------------------------------------------

namespace TradeOgreDotNet.Contracts
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Text;


    #endregion Usings

    public class ApiCredentials
    {
        #region Properties

        public string ApiKey { get; set; }

        public string ApiSecret { get; set; }

        #endregion Properties
    }
}