// -----------------------------------------------------------------------------
// <copyright file="ITradeOgreExtension" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/4/2019 7:42:27 PM" />
// -----------------------------------------------------------------------------

namespace TradeOgre.Net
{
    #region Usings

    using Contracts;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    #endregion Usings

    public static class ITradeOgreExtension
    {
        #region Public Api

        /// <summary>
        /// Get all market pairs
        /// </summary>
        /// <returns>Collection of trading pairs</returns>
        public static async Task<string[]> GetMarketPairs(this ITradeOgre service)
        {
            var markets = new List<string>();

            var exchangeMkts = await service.GetMarkets();

            foreach(var market in exchangeMkts)
            {
                markets.Add(market.Key);
            }

            return markets.ToArray();
        }

        /// <summary>
        /// Get converted Markets
        /// </summary>
        /// <returns>Collection of Ticker objects</returns>
        public static async Task<List<Ticker>> GetMarketsConverted(this ITradeOgre service)
        {
            var tickers = new List<Ticker>();

            var markets = await service.GetMarkets();

            foreach(var market in markets)
            {
                var ticker = new Ticker(market.Value);
                ticker.TradingPair = market.Key;

                tickers.Add(ticker);
            }

            return tickers;
        }

        /// <summary>
        /// Get converted Order Book
        /// </summary>
        /// <param name="pair">Trading pair</param>
        /// <returns>OrderBook object</returns>
        public static async Task<OrderBook> GetOrderBookConverted(this ITradeOgre service, string pair)
        {
            var buys = new List<OrderBookDetail>();
            var sells = new List<OrderBookDetail>();

            var books = await service.GetOrderBook(pair);

            foreach(var buy in books.Buy)
            {
                var book = new OrderBookDetail { Quantity = buy.Key, Price = buy.Value };
                buys.Add(book);
            }
            foreach (var sell in books.Sell)
            {
                var book = new OrderBookDetail { Quantity = sell.Key, Price = sell.Value };
                sells.Add(book);
            }
            
            return new OrderBook { Buys = buys, Sells = sells };
        }

        #endregion Public Api

        #region Private Api

        /// <summary>
        /// Place a Limit order
        /// </summary>
        /// <param name="pair">Trading pair</param>
        /// <param name="side">Trade side</param>
        /// <param name="price">Order price</param>
        /// <param name="quantity">Order quantity</param>
        /// <returns>OrderResponse object</returns>
        public static async Task<OrderResponse> LimitOrder(this ITradeOgre service, string pair, Side side, decimal price, decimal quantity)
        {
            var order = await service.PlaceOrder(pair, side, price, quantity);

            return order;
        }

        /// <summary>
        /// Place a Market order
        /// </summary>
        /// <param name="pair">Trading pair</param>
        /// <param name="side">Trade side</param>
        /// <param name="quantity">Order quantity</param>
        /// <returns>OrderResponse object</returns>
        public static async Task<OrderResponse> MarketOrder(this ITradeOgre service, string pair, Side side, decimal quantity)
        {
            var ticker = await service.GetTicker(pair);

            var order = await service.PlaceOrder(pair, side, ticker.Price, quantity);

            return order;
        }

        #endregion Private Api
    }
}