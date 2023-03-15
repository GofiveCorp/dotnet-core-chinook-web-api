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
    public class PlaylistController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IMapper _mapper;
        private readonly ILogging _logger;
        private readonly IPlaylistRepository _dbPlaylist;
        public PlaylistController(IMapper mappingConfig,
                                  ILogging logging,
                                  IPlaylistRepository dbContext)
        {
            this._response = new();
            _mapper = mappingConfig;
            _logger = logging;
            _dbPlaylist = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetPlaylists()
        {
            try
            {
                _logger.Log("Get All Playlists", "");
                IEnumerable<Playlist> playlists = await _dbPlaylist.GetAllAsync();
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

        [HttpGet("{id:int}", Name = "GetPlaylist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetPlaylist(int id)
        {
            try
            {
                if (id == 0)
                {
                    _logger.Log("Get a Playlist", "");
                    return BadRequest();
                }
                var playlist = await _dbPlaylist.GetAsync(u => u.PlaylistId == id);

                if (playlist == null)
                {
                    return NotFound();
                }
                _response.Result = _mapper.Map<PlaylistDto>(playlist);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorsMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreatePlaylist([FromBody] PlaylistDto CreatePlaylistDto)
        {
            try
            {

                if (CreatePlaylistDto == null)
                {
                    return BadRequest(CreatePlaylistDto);
                }
                if (CreatePlaylistDto.PlaylistId > 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
                Playlist playlist = _mapper.Map<Playlist>(CreatePlaylistDto);
                await _dbPlaylist.CreateAsync(playlist);

                _response.Result = _mapper.Map<PlaylistDto>(playlist);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetPlaylist", new { id = playlist.PlaylistId }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorsMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("{id:int}", Name = "DeletePlaylist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeletePlaylist(int id)
        {
            try
            {

                if (id == 0)
                {
                    return BadRequest();
                }
                var playlist = await _dbPlaylist.GetAsync(u => u.PlaylistId == id);
                if (id == null)
                {
                    return NotFound();
                }
                await _dbPlaylist.RemoveAsync(playlist);
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorsMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPut("{id:int}", Name = "UpdatePlaylist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdatePlaylist(int id, [FromBody] PlaylistDto updatePlaylistDto)
        {
            try
            {
                if (updatePlaylistDto == null || id != updatePlaylistDto.PlaylistId)
                {
                    return BadRequest();
                }
                Playlist playlist = _mapper.Map<Playlist>(updatePlaylistDto);
                await _dbPlaylist.UpdateAsync(playlist);
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorsMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPatch]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdatePartialPlaylist(int id, JsonPatchDocument<PlaylistDto> patchPlaylistDTO)
        {
            try
            {
                if (patchPlaylistDTO == null || id == 0)
                {
                    return BadRequest();
                }
                var playlist = await _dbPlaylist.GetAsync(u => u.PlaylistId == id, tracked: false);

                PlaylistDto playlistDto = _mapper.Map<PlaylistDto>(playlist);

                if (playlist == null)
                {
                    return BadRequest();
                }
                patchPlaylistDTO.ApplyTo(playlistDto, ModelState);

                Playlist model = _mapper.Map<Playlist>(playlistDto);

                await _dbPlaylist.UpdateAsync(model);
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.NoContent;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorsMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }
    }
}
