using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MyChinook.Customizes.Logging;
using MyChinook.Models.Dtos;
using MyChinook.Models.Entities;
using MyChinook.Models.Responses;
using MyChinook.Repositories.IRepositories;
using System.Net;

namespace MyChinook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistTrackController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IMapper _mapper;
        private readonly ILogging _logger;
        private readonly IPlaylistTrackRepository _dbPlaylistTrack;

        public PlaylistTrackController(IMapper mappingConfig,
                                  ILogging logging,
                                  IPlaylistTrackRepository dbContext)
        {
            this._response = new();
            _mapper = mappingConfig;
            _logger = logging;
            _dbPlaylistTrack = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetPlaylistTracks()
        {
            try
            {
                _logger.Log("Get All PlaylistTracks", "");
                IEnumerable<PlaylistTrack> playlistTracks = await _dbPlaylistTrack.GetAllAsync();
                _response.Result = _mapper.Map<List<PlaylistTrackDto>>(playlistTracks);
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

        [HttpGet("playlist/{id}")]
        public async Task<ActionResult<APIResponse>> GetByPlaylist(int id)
        {
            try
            {
                if (id < 0 || id == 0)
                {
                    return BadRequest();
                }
                IEnumerable<PlaylistTrack> playlistTracks = await _dbPlaylistTrack.GetPlaylistTrackByPlaylistAsync(id);
                _response.Result = _mapper.Map<List<PlaylistTrackDto>>(playlistTracks);
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

        [HttpGet("track/{id}")]
        public async Task<ActionResult<APIResponse>> GetbyTrack(int id)
        {
            try
            {
                if (id < 0 || id == 0)
                {
                    return BadRequest();
                }
                IEnumerable<PlaylistTrack> playlistTracks = await _dbPlaylistTrack.GetPlaylistTrackByTrackAsync(id);
                _response.Result = _mapper.Map<List<PlaylistTrackDto>>(playlistTracks);
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
