using System.Text.Json;

namespace LegoComparer.ApiSource;

public class ApiClient
{
    private readonly string _serviceUrl;
    private HttpClient? _httpClient;

    public ApiClient(string serviceUrl)
    {
        _serviceUrl = serviceUrl;
    }

    private HttpClient VarioClient => _httpClient ??= new HttpClient();

    public async Task<JsonDocument> GetEndpointData(string endpointName)
    {
        try
        {
            var result = await VarioClient.GetStringAsync($"{_serviceUrl}/{endpointName}");

            return JsonDocument.Parse(result);
        }
        catch (Exception ex)
        {
            throw new HttpRequestException($"Exception message of endpoint {endpointName} : {ex.Message}");
        }
    }
}