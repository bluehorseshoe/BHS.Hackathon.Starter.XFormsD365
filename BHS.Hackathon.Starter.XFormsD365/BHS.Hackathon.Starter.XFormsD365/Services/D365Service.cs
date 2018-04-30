using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BHS.Hackathon.Starter.XFormsD365.Helpers;
using BHS.Hackathon.Starter.XFormsD365.Models;

namespace BHS.Hackathon.Starter.XFormsD365.Services
{
    public class D365Service
    {
        public D365Service()
        {
        }

        #region Authentication

        /// <summary>
        /// Generate D365 HTTP Client.
        /// </summary>
        /// <returns>HTTP Client.</returns>
        private static async Task<HttpClient> GenerateD365HttpClient()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri(Settings.D365URL + "/data/");

            var authHeader = await D365AuthHelper.GetAuthorizationHeader();

            client.DefaultRequestHeaders.TryAddWithoutValidation("Authorization", authHeader);

            return client;
        }

        #endregion Authentication

        #region Customer

        public static async Task<List<Customer>> GetCustomers()
        {
            List<Customer> customers = null;

            try
            {
                var client = await GenerateD365HttpClient();
                var dataJsonStr = await client.GetStringAsync($"Customers");

                // show pulling back certain fields and filtering
                //var dataJsonStr = await client.GetStringAsync($"Customers?$select=Name,CustomerAccount&$filter=CustomerAccount eq '{customerAccount}'");

                customers = JsonConvert.DeserializeObject<CustomerJson.Rootobject>(dataJsonStr)?.value?.ToList();
            }
            catch (Exception ex)
            {
            }

            return customers;
        }

        #endregion Customer
    }
}