// -----------------------------------------------------------------------------
// <copyright file="TradeOgre" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/2/2019 9:38:23 PM" />
// -----------------------------------------------------------------------------

namespace TradeOgre.Net
{
    #region Usings

    using System.Collections.Generic;
    using System.Threading.Tasks;
    using global::TradeOgre.Net.Contracts;
    using global::TradeOgre.Net.Repository;

    #endregion Usings

    public class TradeOgre : RepositoryBase, ITradeOgre
    {
        #region Properties
        #endregion Properties

        #region Constructor

        public TradeOgre() : base()
        { }

        public TradeOgre(string apiKey, string apiSecret) 
            : this(new ApiCredentials { ApiKey = apiKey, ApiSecret = apiSecret })
        { }

        public TradeOgre(ApiCredentials creds) : base(creds)
        { }

        #endregion Constructor

        #region Public Api

        /// <summary>
        /// Retrieve a listing of all markets and basic information including current price, volume, high, low, bid and ask.
        /// </summary>
        /// <returns>Dictionary of markets and ticker data</returns>
        public async Task<Dictionary<string, Ticker>> GetMarkets()
        {
            var endpoint = @"/markets";
            var markets = await base.Get<Dictionary<string, Ticker>[]>(endpoint);

            var marketDictionary = new Dictionary<string, Ticker>();
            foreach(var market in markets)
            {
                foreach(var kvp in market)
                {
                    marketDictionary.Add(kvp.Key, kvp.Value);
                }
            }

            return marketDictionary;
        }

        /// <summary>
        /// Retrieve the current order book for a trading pair.
        /// </summary>
        /// <param name="pair">Trading pair</param>
        /// <returns>OrderBook data</returns>
        public async Task<OrderBookExchange> GetOrderBook(string pair)
        {
            var endpoint = $@"/orders/{pair}";
            var orderBook = await base.Get<OrderBookExchange>(endpoint);

            return orderBook;
        }

        /// <summary>
        /// Retrieve the ticker for a trading pair, volume, high, and low are in the last 24 hours, initial price is the price from 24 hours ago.
        /// </summary>
        /// <param name="pair">Trading pair</param>
        /// <returns>Ticker object</returns>
        public async Task<Ticker> GetTicker(string pair)
        {
            var endpoint = $@"/ticker/{pair}";
            var ticker = await base.Get<Ticker>(endpoint);

            ticker.TradingPair = pair;

            return ticker;
        }

        /// <summary>
        /// Retrieve the history of the last trades on a trading pair limited to 100 of the most recent trades. The date is a Unix UTC timestamp.
        /// </summary>
        /// <param name="pair">Trading pair</param>
        /// <returns>Collection of TradeHistory</returns>
        public async Task<TradeHistory[]> GetTradeHistory(string pair)
        {
            var endpoint = $@"/history/{pair}";
            var ticker = await base.Get<TradeHistory[]>(endpoint);
            
            return ticker;
        }

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
        public async Task<OrderResponse> PlaceOrder(string pair, Side side, decimal price, decimal quantity)
        {
            var endpoint = side == Side.Buy ? $@"/order/buy" : $@"/order/sell";

            var body = new Dictionary<string, object>();
            body.Add("market", pair);
            body.Add("quantity", quantity);
            body.Add("price", price);

            var response = await base.Post<OrderResponse, Dictionary<string, object>>(endpoint, body);

            return response;
        }

        /// <summary>
        /// Cancel an order
        /// </summary>
        /// <param name="orderId">Order Id to cancel</param>
        /// <returns>Boolean when complete</returns>
        public async Task<bool> CancelOrder(string orderId)
        {
            var endpoint = $@"/order/cancel";

            var body = new Dictionary<string, object>();
            body.Add("uuid", orderId);

            var response = await base.Post<ResponseBase, Dictionary<string, object>>(endpoint, body);

            return response.Success;
        }

        /// <summary>
        /// Get all orders for current account
        /// </summary>
        /// <returns>Collection of order objects</returns>
        public async Task<Order[]> GetOrders()
        {
            var endpoint = $@"/account/orders";

            var response = await base.Post<Order[]>(endpoint);

            return response;
        }

        /// <summary>
        /// Get all orders for a trading pair for current account
        /// </summary>
        /// <param name="pair">Trading pair</param>
        /// <returns>Collection of order objects</returns>
        public async Task<Order[]> GetOrders(string pair)
        {
            var endpoint = $@"/account/orders";

            var body = new Dictionary<string, object>();
            body.Add("market", pair);

            var response = await base.Post<Order[], Dictionary<string, object>>(endpoint, body);

            return response;
        }

        /// <summary>
        /// Get an order
        /// </summary>
        /// <param name="orderId">Order Id to find</param>
        /// <returns>OrderDetail object</returns>
        public async Task<OrderDetail> GetOrder(string orderId)
        {
            var endpoint = $@"/account/order/{orderId}";

            var response = await base.Get<OrderDetail>(endpoint, true);

            return response;
        }

        /// <summary>
        /// Get balance for a currency for current account
        /// </summary>
        /// <param name="symbol">Symbol of a currency</param>
        /// <returns>Currency balance object</returns>
        public async Task<CurrencyBalance> GetBalance(string symbol)
        {
            var endpoint = $@"/account/balance";

            var body = new Dictionary<string, object>();
            body.Add("currency", symbol);

            var response = await base.Post<CurrencyBalance, Dictionary<string, object>>(endpoint, body);

            return response;
        }

        /// <summary>
        /// Get all balances for current account
        /// </summary>
        /// <returns>CurrencyBalances object</returns>
        public async Task<CurrencyBalances> GetBalances()
        {
            var endpoint = $@"/account/balances";

            var response = await base.Get<CurrencyBalances>(endpoint, true);

            return response;
        }

        #endregion Private Api
    }
}