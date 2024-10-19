using Mango.Web.Models;
using Mango.Web.Service.IService;
using Newtonsoft.Json;
using System.Linq.Expressions;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json.Serialization;
using static Mango.Web.Utility.StaticDetails;

namespace Mango.Web.Service
{
    public class BaseService : IBaseServicecs
    {
        //Here we will call the API. Previously we use DI for HttpClient to call the API. 
        //Now It has been moved away from HttpClient to using IHttpClientFactory

        private readonly IHttpClientFactory _httpClientFactory;
        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ResponseDto?> SendAsync(RequestDto requestDto)
        {
            try
            {
                // Created client with anyname
                HttpClient client = _httpClientFactory.CreateClient("MangoApi");
                //creating a Http request message
                HttpRequestMessage message = new();
                message.Headers.Add("Accept", "application/json");

                //Token

                //Added Url
                message.RequestUri = new Uri(requestDto.Url);

                //Seralize data 
                if (requestDto.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(requestDto.Data), Encoding.UTF8, "application/json");
                }

                HttpResponseMessage? apiResponse = null;

                //configure message.method based on request api type
                switch (requestDto.ApiType)
                {
                    case ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;

                    case ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;

                    case ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;

                    default:
                        message.Method = HttpMethod.Get;
                        break;

                }
                //calling api
                apiResponse = await client.SendAsync(message);

                //checking response then desearlizing the response 
                switch (apiResponse.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Not Found"
                        };
                    case HttpStatusCode.Forbidden:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Forbidden"
                        };
                    case HttpStatusCode.Unauthorized:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Unauthorized"
                        };
                    case HttpStatusCode.InternalServerError:
                        return new()
                        {
                            IsSuccess = false,
                            Message = "Internel Server Error"
                        };
                    default:
                        var apiContent = await apiResponse.Content.ReadAsStringAsync();
                        //desearlizing the response
                        var apiResponseDto = JsonConvert.DeserializeObject<ResponseDto>(apiContent);
                        return apiResponseDto;
                }
            }
            catch (Exception ex)
            {
                var dto = new ResponseDto()
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };
                return dto;
            }

        }
    }
}

