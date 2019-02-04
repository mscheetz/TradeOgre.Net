// -----------------------------------------------------------------------------
// <copyright file="TradeOgre" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/2/2019 9:38:23 PM" />
// -----------------------------------------------------------------------------

namespace TradeOgreDotNet
{
    #region Usings

    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using TradeOgreDotNet.Contracts;
    using TradeOgreDotNet.Repository;


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

        public async Task<Dictionary<string, Ticker>> GetMarkets()
        {
            var endpoint = @"/markets";
            var markets = await base.GetRequest<Dictionary<string, Ticker>>(endpoint);
                       
            return markets;
        }

        public async Task<OrderBook> GetOrderBook(string pair)
        {
            var endpoint = $@"/orders/{pair}";
            var orderBook = await base.GetRequest<OrderBook>(endpoint);

            return orderBook;
        }

        public async Task<Ticker> GetTicker(string pair)
        {
            var endpoint = $@"/ticker/{pair}";
            var ticker = await base.GetRequest<Ticker>(endpoint);

            ticker.TradingPair = pair;

            return ticker;
        }

        public async Task<TradeHistory[]> GetTradeHistory(string pair)
        {
            var endpoint = $@"/history/{pair}";
            var ticker = await base.GetRequest<TradeHistory[]>(endpoint);
            
            return ticker;
        }

        #endregion Public Api

        #region Private Api

        public async Task<OrderResponse> PlaceOrder(string pair, Side side, decimal price, decimal quantity)
        {
            var endpoint = side == Side.Buy ? $@"/order/buy" : $@"/order/sell";

            var body = new SortedDictionary<string, object>();
            body.Add("market", pair);
            body.Add("quantity", quantity);
            body.Add("price", price);

            var response = await base.PostRequest<OrderResponse>(endpoint, body, true);

            return response;
        }

        public async Task<bool> CancelOrder(string orderId)
        {
            var endpoint = $@"/order/cancel";

            var body = new SortedDictionary<string, object>();
            body.Add("uuid", orderId);

            var response = await base.PostRequest<ResponseBase>(endpoint, body, true);

            return response.Success;
        }

        public async Task<Order[]> GetOrders()
        {
            var endpoint = $@"/account/orders";

            var response = await base.PostRequest<Order[]>(endpoint);

            return response;
        }

        public async Task<Order[]> GetOrders(string pair)
        {
            var endpoint = $@"/account/orders";

            var body = new SortedDictionary<string, object>();
            body.Add("market", pair);

            var response = await base.PostRequest<Order[]>(endpoint, body, true);

            return response;
        }

        public async Task<OrderDetail> GetOrder(string orderId)
        {
            var endpoint = $@"/account/order/{orderId}";

            var response = await base.GetRequest<OrderDetail>(endpoint);

            return response;
        }

        public async Task<CurrencyBalance> GetBalance(string symbol)
        {
            var endpoint = $@"/account/balance";

            var body = new SortedDictionary<string, object>();
            body.Add("currency", symbol);

            var response = await base.PostRequest<CurrencyBalance>(endpoint, body, true);

            return response;
        }

        public async Task<CurrencyBalances> GetBalances()
        {
            var endpoint = $@"/account/balances";

            var response = await base.GetRequest<CurrencyBalances>(endpoint);

            return response;
        }

        #endregion Private Api
    }
}