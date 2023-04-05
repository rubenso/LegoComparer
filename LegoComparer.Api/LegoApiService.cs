using LegoComparer.ApiSource.Abstraction;
using LegoComparer.Model.LegoApi;
using System.Text.Json;
using System.Xml.Linq;

namespace LegoComparer.ApiSource
{
    public class LegoApiService : ApiClient, ILegoApiService
    {
        public LegoApiService(string serviceUrl) : base(serviceUrl)
        {
        }

        private readonly JsonSerializerOptions _jsonSerializerOptions = new()
        {
            AllowTrailingCommas = true,
            PropertyNameCaseInsensitive = true
        };

        protected async Task<T> MapResponse<T>(JsonDocument? apiResponse)
        {
            if (apiResponse == null)
            {
                throw new HttpRequestException("No response returned");
            }

            if (!apiResponse.RootElement.TryGetProperty("isError", out var isError) &&
                isError.ValueKind == JsonValueKind.Undefined)
            {
                var successResult = apiResponse.Deserialize<T>(_jsonSerializerOptions);

                if (successResult != null)
                {
                    return await Task.FromResult(successResult);
                }
                else throw new Exception("Deserialization exception:" + apiResponse.RootElement);
            }
            else
            {
                throw new Exception(apiResponse.ToString());
            }
        }


        public async Task<Users> GetUsers()
        {
            var apiResponse = await GetEndpointData("users");
            return await MapResponse<Users>(apiResponse);
        }

        public async Task<User> GetUserByUserName(string name)
        {
            var apiResponse = await GetEndpointData($"user/by-username/{name}");
            return await MapResponse<User>(apiResponse);
        }

        public async Task<User> GetUserByUserId(string id)
        {
            var apiResponse = await GetEndpointData($"user/by-id/{id}");
            return await MapResponse<User>(apiResponse);
        }

        public async Task<Sets> GetSets()
        {
            var apiResponse = await GetEndpointData("sets");
            return await MapResponse<Sets>(apiResponse);
        }

        public async Task<Set> GetSetByName(string name)
        {
            var apiResponse = await GetEndpointData($"set/by-name/{name}");
            return await MapResponse<Set>(apiResponse);
        }

        public async Task<Set> GetSetById(string id)
        {
            var apiResponse = await GetEndpointData($"set/by-id/{id}");
            return await MapResponse<Set>(apiResponse);
        }

        public async Task<Colours> GetColours()
        {
            var apiResponse = await GetEndpointData("colours");
            return await MapResponse<Colours>(apiResponse);
        }
    }
}
