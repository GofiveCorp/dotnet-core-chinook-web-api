using MyChinook_Utility.Enum;
using MyChinook_Web.Models.Dtos;
using MyChinook_Web.Models.Responses;
using MyChinook_Web.Services.IServices;

namespace MyChinook_Web.Services.Services
{
    public class AlbumService : BaseService, IAlbumService
    {
        private readonly IHttpClientFactory _clientFactory;
        private string myChinookUrl;

        public AlbumService(IHttpClientFactory clientFactory
                            ,IConfiguration configuration) : base(clientFactory)
        {
            _clientFactory = clientFactory;
            myChinookUrl = configuration.GetValue<string>("ServiceUrls:MyChinookAPI");
        }

        public Task<T> GetAllAsync<T>()
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = RequestType.ApiType.GET
                ,Url = myChinookUrl + "/api/Album"
            });
        }

        public Task<T> GetAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = RequestType.ApiType.GET
                ,Url = myChinookUrl + "/api/Album/" + id
            });
        }

        public Task<T> CreateAsync<T>(AlbumDto albumDto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = RequestType.ApiType.POST
                ,Data = albumDto  
                ,Url = myChinookUrl + "/api/Album"
            });
        }

        public Task<T> UpdateAsync<T>(AlbumDto albumDto)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = RequestType.ApiType.PUT
                ,Data = albumDto
                ,Url = myChinookUrl + "/api/Album/" + albumDto.AlbumId
            });
        }

        public Task<T> DeleteAsync<T>(int id)
        {
            return SendAsync<T>(new APIRequest()
            {
                ApiType = RequestType.ApiType.DELETE
                ,Url = myChinookUrl + "/api/Album/" + id
            });
        }



  
    }
}
