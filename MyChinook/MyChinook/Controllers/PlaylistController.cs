using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MyChinook.Customizes.Logging;
using MyChinook.Models.Dtos;
using MyChinook.Models.Responses;
using MyChinook.Repositories.IRepositories;
using System.Net;

namespace MyChinook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IMapper _mapper;
        private readonly ILogging _logger;
        private readonly IPlaylistRepository playlistService;
        public PlaylistController(IMapper mappingConfig,
                                  ILogging logging,
                                  IPlaylistRepository dbContext)
        {
            this._response = new();
            _mapper = mappingConfig;
            _logger = logging;
            playlistService = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetPlaylists(CancellationToken cancellationToken)
        {
            try
            {
                _logger.Log("Get All Playlists", "");
                var playlists = await playlistService.GetAllPlaylistsAsync(cancellationToken);
                _response.Result = _mapper.Map<List<PlaylistDto>>(playlists);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorsMessages = new List<string>() { ex.ToString() };
                return _response;
            }
        }
    }
}

