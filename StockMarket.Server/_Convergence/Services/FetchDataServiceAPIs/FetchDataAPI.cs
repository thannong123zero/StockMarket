﻿using Newtonsoft.Json;
using StockMarket.Server.Models;

namespace StockMarket.Server._Convergence.Services.FetchDataServiceAPIs
{
    public class FetchDataAPI
    {
        public async Task<FetchStockHistoryViewModel> FetchData()
        {
            string url = "https://dchart-api.vndirect.com.vn/dchart/history?resolution=1D&symbol=DCM&from=1427734800&to=1729435858";
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    FetchStockHistoryViewModel fetchStockHistoryViewModel = JsonConvert.DeserializeObject<FetchStockHistoryViewModel>(data);
                    return fetchStockHistoryViewModel;
                }

            }
            return null;
        }
    }
}
