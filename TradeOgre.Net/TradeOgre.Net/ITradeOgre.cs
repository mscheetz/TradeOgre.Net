// -----------------------------------------------------------------------------
// <copyright file="ITradeOgre" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/2/2019 10:47:46 PM" />
// -----------------------------------------------------------------------------

namespace TradeOgre.Net
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using global::TradeOgre.Net.Contracts;

    #endregion Usings

    public interface ITradeOgre
    {
        #region Public Api

        /// <summary>
        /// Retrieve a listing of all markets and basic information including current price, volume, high, low, bid and ask.
        /// </summary>
        /// <returns>Dictionary of markets and ticker data</returns>
        Task<Dictionary<string, Ticker>> GetMarkets();

        /// <summary>
        /// Retrieve the current order book for a trading pair.
        /// </summary>
        /// <param name="pair">Trading pair</param>
        /// <returns>OrderBook data</returns>
        Task<OrderBookExchange> GetOrderBook(string pair);

        /// <summary>
        /// Retrieve the ticker for a trading pair, volume, high, and low are in the last 24 hours, initial price is the price from 24 hours ago.
        /// </summary>
        /// <param name="pair">Trading pair</param>
        /// <returns>Ticker object</returns>
        Task<Ticker> GetTicker(string pair);

        /// <summary>
        /// Retrieve the history of the last trades on a trading pair limited to 100 of the most recent trades. The date is a Unix UTC timestamp.
        /// </summary>
        /// <param name="pair">Trading pair</param>
        /// <returns>Collection of TradeHistory</returns>
        Task<TradeHistory[]> GetTradeHistory(string pair);

        #endregion Public Api

        #region Private Api

        /// <summary>
        /// Place an order
        /// </summary>
        /// <param name="pair">Trading pair</param>
        /// <param name="side">Trade side</param>
        /// <param name="price">Order price</param>
        /// <param name="quantity">Order quantity</param>
        /// <returns>Order response object</returns>
        Task<OrderResponse> PlaceOrder(string pair, Side side, decimal price, decimal quantity);

        /// <summary>
        /// Cancel an order
        /// </summary>
        /// <param name="orderId">Order Id to cancel</param>
        /// <returns>Boolean when complete</returns>
        Task<bool> CancelOrder(string orderId);

        /// <summary>
        /// Get all orders for current account
        /// </summary>
        /// <returns>Collection of order objects</returns>
        Task<Order[]> GetOrders();

        /// <summary>
        /// Get all orders for a trading pair for current account
        /// </summary>
        /// <param name="pair">Trading pair</param>
        /// <returns>Collection of order objects</returns>
        Task<Order[]> GetOrders(string pair);

        /// <summary>
        /// Get an order
        /// </summary>
        /// <param name="orderId">Order Id to find</param>
        /// <returns>OrderDetail object</returns>
        Task<OrderDetail> GetOrder(string orderId);

        /// <summary>
        /// Get balance for a currency for current account
        /// </summary>
        /// <param name="symbol">Symbol of a currency</param>
        /// <returns>Currency balance object</returns>
        Task<CurrencyBalance> GetBalance(string symbol);

        /// <summary>
        /// Get all balances for current account
        /// </summary>
        /// <returns>CurrencyBalances object</returns>
        Task<CurrencyBalances> GetBalances();
        
        #endregion Private Api
    }
}