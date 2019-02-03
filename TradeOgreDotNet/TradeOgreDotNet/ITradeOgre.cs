// -----------------------------------------------------------------------------
// <copyright file="ITradeOgre" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/2/2019 10:47:46 PM" />
// -----------------------------------------------------------------------------

namespace TradeOgreDotNet
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using TradeOgreDotNet.Contracts;


    #endregion Usings

    public interface ITradeOgre
    {
        #region Public Api

        Task<Dictionary<string, Ticker>> GetMarkets();

        Task<OrderBook> GetOrderBook(string pair);

        Task<Ticker> GetTicker(string pair);

        Task<TradeHistory[]> GetTradeHistory(string pair);

        #endregion Public Api

        #region Private Api

        Task<OrderResponse> PlaceOrder(string pair, Side side, decimal price, decimal quantity);

        Task<bool> CancelOrder(string orderId);

        Task<Order[]> GetOrders();

        Task<Order[]> GetOrders(string pair);

        Task<OrderDetail> GetOrder(string orderId);

        Task<CurrencyBalance> GetBalance(string symbol);

        Task<CurrencyBalances> GetBalances();
        
        #endregion Private Api
    }
}