namespace StockMarket.Server._Convergence.Services.FetchDataServiceAPIs
{
    public class FetchDataAPI
    {
        public async Task<string> FetchData()
        {
            string url = "https://dchart-api.vndirect.com.vn/dchart/history?resolution=1D&symbol=DCM&from=1687132800&to=1729423904";
            using (HttpClient httpClient = new HttpClient())
            {
                HttpResponseMessage response = await httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadAsStringAsync();
                    return data;
                }

            }
            return "";
        }
    }
}
