
namespace ReceiptStatsConsole.DataAccess
{
    public static class DataAccess
    {
        public static async Task<string> FetchData(string apiUrl)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                try
                {

                    HttpResponseMessage response = await httpClient.GetAsync(apiUrl);


                    if (response.IsSuccessStatusCode)
                    {
                        var serilizedResponse = await response.Content.ReadAsStringAsync();
                        return serilizedResponse;
                    }
                    else
                    {
                        Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                        return null;
                    }
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    return null;
                }
            }
        }
    }
}
