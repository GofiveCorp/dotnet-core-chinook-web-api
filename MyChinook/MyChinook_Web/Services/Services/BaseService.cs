using MyChinook_Utility.Enum;
using MyChinook_Web.Models.Responses;
using MyChinook_Web.Services.IServices;
using Newtonsoft.Json;
using System.Runtime.InteropServices;
using System.Text;

namespace MyChinook_Web.Services.Services
{
    public class BaseService : IBaseService
    {
        public APIResponse responseModel { get; set; }
        public IHttpClientFactory httpClient { get; set; }  
        public BaseService(IHttpClientFactory httpClient) 
        {
            this.responseModel = new();
            this.httpClient = httpClient;
        }

        public async Task<T> SendAsync<T>(APIRequest apiRequest)
        {
            try
            {
                var client = httpClient.CreateClient("MyChinookAPI");
                HttpRequestMessage message = new HttpRequestMessage();
                message.Headers.Add("Accept", "application/json");
                message.RequestUri = new Uri(apiRequest.Url);
                if (apiRequest.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(apiRequest.Data)
                        , Encoding.UTF8, "application/json");
                }
                switch (apiRequest.ApiType)
                {
                    case RequestType.ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case RequestType.ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case RequestType.ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;
                }
                HttpResponseMessage apiResponse = null;
                apiResponse = await client.SendAsync(message);
                var apiContent = await apiResponse.Content.ReadAsStringAsync();
                var APIResponse = JsonConvert.DeserializeObject<T>(apiContent);
                return APIResponse;
            }
            catch(Exception ex)
            {
                var dto = new APIResponse
                {
                    ErrorsMessages = new List<string> { Convert.ToString(ex.Message) }
                    , IsSuccess = false
                };
                var res = JsonConvert.SerializeObject(dto);
                var APIResponse = JsonConvert.DeserializeObject<T>(res);
                return APIResponse;
            }
        }
    }
}
