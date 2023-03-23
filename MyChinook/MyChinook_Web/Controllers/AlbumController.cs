using Microsoft.AspNetCore.Mvc;
using MyChinook_Web.Models.Dtos;
using MyChinook_Web.Models.Responses;
using MyChinook_Web.Services.IServices;
using Newtonsoft.Json;

namespace MyChinook_Web.Controllers
{
    public class AlbumController : Controller
    {
        private readonly IAlbumService _albumService;

        public AlbumController(IAlbumService albumService)
        {
            _albumService = albumService;
        }

        public async Task<IActionResult> IndexAlbum()
        {
            List<AlbumDto> list = new();
            var response = await _albumService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<AlbumDto>>(Convert.ToString(response.Result));
            }
            return View(list);
        }
    }
}
