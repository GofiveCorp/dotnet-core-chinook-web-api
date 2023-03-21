using MyChinook_Utility.Enum;
using MyChinook_Web.Models.Dtos;
using MyChinook_Web.Models.Responses;
using MyChinook_Web.Services.IServices;

namespace MyChinook_Web.Services.Services
{
    public class ArtistService : BaseService, IArtistService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string myChinookUrl;

        public ArtistService(IHttpClientFactory clientFactory,IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            myChinookUrl = configuration.GetValue<string>("ServiceUrls:MyChinookAPI");
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = RequestType.ApiType.GET
                ,Url = myChinookUrl + "/api/artist"
            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = RequestType.ApiType.GET
                ,Url = myChinookUrl + "/api/artist/" + id
            });
        }

        public Task<T> CreateAsync<T>(ArtistDto artistDto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = RequestType.ApiType.POST
                ,Data = artistDto  
                ,Url = myChinookUrl + "/api/artist"
            });
        }

        public Task<T> UpdateAsync<T>(ArtistDto artistDto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = RequestType.ApiType.PUT
                ,Data = artistDto
                ,Url = myChinookUrl + "/api/artist/" + artistDto.ArtistId
            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = RequestType.ApiType.DELETE
                ,Url = myChinookUrl + "/api/artist/" + id
            });
        }



  
    }
}
