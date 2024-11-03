using Common.ViewModels;
using Newtonsoft.Json;


namespace Common.Services.FetchDataServiceAPIs
{
    public class FetchDataAPI
    {
        public async Task<FetchStockHistoryViewModel> FetchData(string symbol, string from, string to)
        {
            string url = $"https://dchart-api.vndirect.com.vn/dchart/history?resolution=1D&symbol={symbol}&from={from}&to={to}";
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
