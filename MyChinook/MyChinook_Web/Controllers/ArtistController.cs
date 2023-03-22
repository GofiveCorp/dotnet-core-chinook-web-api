using Microsoft.AspNetCore.Mvc;
using MyChinook_Web.Models.Dtos;
using MyChinook_Web.Models.Responses;
using MyChinook_Web.Services.IServices;
using Newtonsoft.Json;
using System.Reflection;

namespace MyChinook_Web.Controllers
{
    public class ArtistController : Controller
    {
        private readonly IArtistService _artistService;

        public ArtistController(IArtistService artistService)
        {
            _artistService = artistService;
        }

        public async Task<IActionResult> IndexArtist()
        {
            List<ArtistDto> list = new();
            var response = await _artistService.GetAllAsync<APIResponse>();
            if (response != null && response.IsSuccess)
            {
                list = JsonConvert.DeserializeObject<List<ArtistDto>>(Convert.ToString(response.Result));
            }
            return View(list);
        }

        public async Task<IActionResult> CreateArtist()
        {        
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateArtist(ArtistDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _artistService.CreateAsync<APIResponse>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexArtist));
                }
            }
            return View(model);
        }

        public async Task<IActionResult> UpdateArtist(int artistId)
        {           
            var response = await _artistService.GetAsync<APIResponse>(artistId);
            if (response != null && response.IsSuccess)
            {
                ArtistDto model = JsonConvert.DeserializeObject<ArtistDto>(Convert.ToString(response.Result));
                return View(model);
            }
            return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateArtist(ArtistDto model)
        {
            if (ModelState.IsValid)
            {
                var response = await _artistService.UpdateAsync<APIResponse>(model);
                if (response != null && response.IsSuccess)
                {
                    return RedirectToAction(nameof(IndexArtist));
                }
            }
            return View(model);
        }
    }
}
