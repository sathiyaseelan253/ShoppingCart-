using Newtonsoft.Json;
using ShoppingCart.Web.Models;
using ShoppingCart.Web.Repository;
using System.Net;
using System.Text;
using static ShoppingCart.Web.Utility.SharedComponent;

namespace ShoppingCart.Web.Services
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public BaseService(IHttpClientFactory httpClientFactory)
        {
            this._httpClientFactory = httpClientFactory;
        }
        public async Task<ResponseDto?> SendAsync(RequestDto? requestDto)
        {
            try
            {
                HttpClient httpClient = _httpClientFactory.CreateClient("ShoppingCartAPI");
                HttpRequestMessage httpRequestMessage = new();
                httpRequestMessage.Headers.Add("Accept", "application/json");

                httpRequestMessage.RequestUri = new Uri(requestDto.Url);
                if (requestDto.Data != null)
                {
                    httpRequestMessage.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");
                }
                switch (requestDto.RequestType)
                {
                    case ApiType.Post:
                        httpRequestMessage.Method = HttpMethod.Post;
                        break;
                    case ApiType.Put:
                        httpRequestMessage.Method = HttpMethod.Put;
                        break;
                    case ApiType.Delete:
                        httpRequestMessage.Method = HttpMethod.Delete;
                        break;
                    default:
                        httpRequestMessage.Method = HttpMethod.Get;
                        break;
                }
                HttpResponseMessage? httpResponse = null;
                httpResponse = await httpClient.SendAsync(httpRequestMessage);

                switch (httpResponse.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return new() { Error = "Not Found", IsSuccess = false };
                    case HttpStatusCode.Forbidden:
                        return new() { Error = "Access Denied", IsSuccess = false };
                    case HttpStatusCode.Unauthorized:
                        return new() { Error = "Unauthorized", IsSuccess = false };
                    case HttpStatusCode.InternalServerError:
                        return new() { Error = "Internal Server Error", IsSuccess = false };
                    default:
                        var apiResponse = await httpResponse.Content.ReadAsStringAsync();
                        var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(apiResponse);
                        return apiResponseDto;

                }
            }
            catch (Exception ex)
            {
                var responseDto = new ResponseDto()
                {
                    IsSuccess = false,
                    Error = ex.Message.ToString(),
                };
                return responseDto;
            }
        }
    }
}
