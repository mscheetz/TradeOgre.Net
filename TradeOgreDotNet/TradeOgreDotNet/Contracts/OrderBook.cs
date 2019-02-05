// -----------------------------------------------------------------------------
// <copyright file="OrderBook" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/4/2019 7:58:59 PM" />
// -----------------------------------------------------------------------------

namespace TradeOgre.Net.Contracts
{
    #region Usings

    using System.Collections.Generic;

    #endregion Usings

    public class OrderBook
    {
        #region Properties

        public List<OrderBookDetail> Buys { get; set; }

        public List<OrderBookDetail> Sells { get; set; }

        #endregion Properties
    }
}