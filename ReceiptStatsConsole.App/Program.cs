using Newtonsoft.Json;
using ReceiptStatsConsole.DataAccess;
using ReceiptStatsConsole.Services;

string apiUrl = "https://interview-task-api.mca.dev/qr-scanner-codes/alpha-qr-gFpwhsQ8fkY1";

string responseData = await DataAccess.FetchData(apiUrl);

if (!String.IsNullOrWhiteSpace(responseData))
{
    List<Product> products = JsonConvert.DeserializeObject<List<Product>>(responseData);
    Services.PrintReceiptDetails(products);
}

