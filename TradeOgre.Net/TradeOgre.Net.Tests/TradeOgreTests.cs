// -----------------------------------------------------------------------------
// <copyright file="TradeOgreTests" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/4/2019 7:27:48 PM" />
// -----------------------------------------------------------------------------

namespace TradeOgre.Net.Tests
{
    #region Usings

    using FileRepository;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using global::TradeOgre.Net.Contracts;
    using Xunit;

    #endregion Usings

    public class TradeOgreTests : IDisposable
    {
        #region Properties

        public ITradeOgre _service;
        public string configPath = "config.json";

        #endregion Properties

        #region Constructor/Destructor

        public TradeOgreTests()
        {
            IFileRepository _fileRepo = new FileRepository();
            ApiCredentials creds = null;
            if (_fileRepo.FileExists(configPath))
            {
                creds = _fileRepo.GetDataFromFile<ApiCredentials>(configPath);
            }
            if (creds != null || !string.IsNullOrEmpty(creds.ApiKey))
            {
                _service = new TradeOgre(creds);
            }
            else
            {
                _service = new TradeOgre();
            }
        }

        public void Dispose()
        {
            _service = null;
        }

        #endregion Constructor/Destructor

        #region Public Api Tests

        [Fact]
        public void GetMarkets_Test()
        {
            var markets = _service.GetMarkets().Result;

            Assert.NotNull(markets);
        }

        [Fact]
        public void GetMarketsII_Test()
        {
            var markets = _service.GetMarketsConverted().Result;

            Assert.NotNull(markets);
        }

        [Fact]
        public void GetMarketPairs_Test()
        {
            var markets = _service.GetMarketPairs().Result;

            Assert.NotNull(markets);
        }

        [Fact]
        public void GetOrderBook_Test()
        {
            var pair = "BTC-LTC";
            var books = _service.GetOrderBook(pair).Result;

            Assert.NotNull(books);
        }

        [Fact]
        public void GetOrderBookII_Test()
        {
            var pair = "BTC-LTC";
            var books = _service.GetOrderBookConverted(pair).Result;

            Assert.NotNull(books);
        }

        [Fact]
        public void GetTicker_Test()
        {
            var pair = "BTC-LTC";
            var ticker = _service.GetTicker(pair).Result;

            Assert.NotNull(ticker);
        }

        [Fact]
        public void GetTradeHistory_Test()
        {
            var pair = "BTC-LTC";
            var history = _service.GetTradeHistory(pair).Result;

            Assert.NotNull(history);
        }

        #endregion Public Api Tests

        #region Private Api Tests

        [Fact]
        public void PlaceOrder_Test()
        {
            var pair = "BTC-LTC";
            var side = Side.Sell;
            var price = 0.050M;
            var quantity = 10.0M;
            var order = _service.PlaceOrder(pair, side, price, quantity).Result;

            Assert.NotNull(order);
        }

        [Fact]
        public void LimitOrder_Test()
        {
            var pair = "BTC-LTC";
            var side = Side.Sell;
            var price = 0.050M;
            var quantity = 10.0M;
            var order = _service.LimitOrder(pair, side, price, quantity).Result;

            Assert.NotNull(order);
        }

        [Fact]
        public void MarketOrder_Test()
        {
            var pair = "BTC-LTC";
            var side = Side.Sell;
            var quantity = 10.0M;
            var order = _service.MarketOrder(pair, side, quantity).Result;

            Assert.NotNull(order);
        }

        [Fact]
        public void CancelOrder_Test()
        {
            var orderId = "12ebf61c-0352-06c0-6f3d-a2a42e2ce567";
            var order = _service.CancelOrder(orderId).Result;

            Assert.True(order);
        }

        [Fact]
        public void GetOrder_Test()
        {
            var orderId = "12ebf61c-0352-06c0-6f3d-a2a42e2ce567";
            var order = _service.GetOrder(orderId).Result;

            Assert.NotNull(order);
        }

        [Fact]
        public void GetOrders_Test()
        {
            var orders = _service.GetOrders().Result;

            Assert.NotNull(orders);
        }

        [Fact]
        public void GetBalance_Test()
        {
            var symbol = "BTC";
            var balance = _service.GetBalance(symbol).Result;

            Assert.NotNull(balance);
        }

        [Fact]
        public void GetBalances_Test()
        {
            var balances = _service.GetBalances().Result;

            Assert.NotNull(balances);
        }

        #endregion Private Api Tests
    }
}