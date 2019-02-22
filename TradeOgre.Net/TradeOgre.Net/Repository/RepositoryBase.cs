// -----------------------------------------------------------------------------
// <copyright file="RepositoryBase" company="Matt Scheetz">
//     Copyright (c) Matt Scheetz All Rights Reserved
// </copyright>
// <author name="Matt Scheetz" date="2/2/2019 9:39:56 PM" />
// -----------------------------------------------------------------------------

namespace TradeOgre.Net.Repository
{
    #region Usings

    using DateTimeHelpers;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Newtonsoft.Json;
    using global::TradeOgre.Net.Contracts;
    using RESTApiAccess.Interface;
    using RESTApiAccess;

    #endregion Usings

    public class RepositoryBase
    {
        #region Properties

        private string baseUrl = "https://tradeogre.com/api/v1";
        private IRESTRepository _rest;
        private ApiCredentials _apiCreds;
        private DateTimeHelper _dtHelper;
        JsonSerializerSettings settings = new JsonSerializerSettings
        {
            NullValueHandling = NullValueHandling.Ignore,
            MissingMemberHandling = MissingMemberHandling.Ignore
        };

        #endregion Properties

        /// <summary>
        /// Constructor for public endpoints
        /// </summary>
        public RepositoryBase()
        {
            LoadBase();
        }

        /// <summary>
        /// Constructor for secure endpoints
        /// </summary>
        /// <param name="apiCredentials">Api credentials</param>
        public RepositoryBase(ApiCredentials apiCredentials)
        {
            _apiCreds = apiCredentials;
            LoadBase();
        }

        /// <summary>
        /// Load repository base
        /// </summary>
        private void LoadBase()
        {
            _rest = new RESTRepository();
            _dtHelper = new DateTimeHelper();
        }

        /// <summary>
        /// Set api credentials
        /// </summary>
        /// <param name="apiCredentials">Api Credentials to set</param>
        public void SetApiCredentials(ApiCredentials apiCredentials)
        {
            _apiCreds = apiCredentials;
        }

        /// <summary>
        /// Initiate a Get request
        /// </summary>
        /// <typeparam name="T">Object to return</typeparam>
        /// <param name="endpoint">Endpoint of request</param>
        /// <param name="parms">Parameters to pass</param>
        /// <param name="secure">Secure endpoint?</param>
        /// <returns>Object from response</returns>
        public async Task<T> Get<T>(string endpoint, SortedDictionary<string, object> parms, bool secure = false)
        {
            var queryString = DictionaryToQueryString(parms);

            if(!string.IsNullOrEmpty(queryString))
            {
                endpoint += $@"?{queryString}";
            }

            return await OnGet<T>(endpoint, secure);
        }

        /// <summary>
        /// Initiate a Get request
        /// </summary>
        /// <typeparam name="T">Object to return</typeparam>
        /// <param name="endpoint">Endpoint of request</param>
        /// <param name="secure">Secure endpoint?</param>
        /// <returns>Object from response</returns>
        public async Task<T> Get<T>(string endpoint, bool secure = false)
        {
            return await OnGet<T>(endpoint, secure);
        }

        /// <summary>
        /// Initiate a Get request
        /// </summary>
        /// <typeparam name="T">Object to return</typeparam>
        /// <param name="endpoint">Endpoint of request</param>
        /// <param name="secure">Secure endpoint?</param>
        /// <returns>Object from response</returns>
        private async Task<T> OnGet<T>(string endpoint, bool secure)
        {
            var url = baseUrl + endpoint;

            try
            {
                var response = secure
                    ? await _rest.GetApiStream<T>(url, _apiCreds.ApiKey, _apiCreds.ApiSecret)
                    : await _rest.GetApiStream<T>(url);

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Initiate a Post request
        /// </summary>
        /// <typeparam name="T">Object to return</typeparam>
        /// <param name="endpoint">Endpoint of request</param>
        /// <param name="secure">Secure endpoint?</param>
        /// <returns>Object from response</returns>
        public async Task<T> Post<T>(string endpoint, bool secure = true)
        {
            var url = baseUrl + endpoint;

            try
            {
                var response = secure 
                    ? await _rest.PostApi<T>(url, _apiCreds.ApiKey, _apiCreds.ApiSecret)
                    : await _rest.PostApi<T>(url);

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Initiate a Post request
        /// </summary>
        /// <typeparam name="T">Object to return</typeparam>
        /// <param name="endpoint">Endpoint of request</param>
        /// <param name="body">Request body data</param>
        /// <param name="secure">Secure endpoint?</param>
        /// <returns>Object from response</returns>
        public async Task<T> Post<T, U>(string endpoint, U body, bool secure = true)
        {
            var url = baseUrl + endpoint;

            try
            {
                var response = secure 
                    ? await _rest.PostApi<T, U>(url, body, _apiCreds.ApiKey, _apiCreds.ApiSecret)
                    : await _rest.PostApi<T, U>(url, body);

                return response;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        /// <summary>
        /// Convert a dictionary to a querystring
        /// </summary>
        /// <param name="data">Dictionary to convert</param>
        /// <returns>String of dictionary data</returns>
        private string DictionaryToQueryString(SortedDictionary<string, object> data)
        {
            var queryString = string.Empty;

            foreach(var kvp in data)
            {
                if(!string.IsNullOrEmpty(queryString))
                {
                    queryString += @"&";
                }
                queryString += $@"{kvp.Key}={kvp.Value.ToString()}";
            }

            return queryString;
        }
    }
}