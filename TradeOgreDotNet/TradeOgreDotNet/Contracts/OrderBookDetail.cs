// -----------------------------------------------------------------------------
// <copyright file="OrderBookDetail" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/4/2019 7:56:11 PM" />
// -----------------------------------------------------------------------------

namespace TradeOgre.Net.Contracts
{
    public class OrderBookDetail
    {
        #region Properties

        public decimal Price { get; set; }

        public decimal Quantity { get; set; }

        #endregion Properties
    }
}