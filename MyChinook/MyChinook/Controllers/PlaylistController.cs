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

        [HttpGet("{id:int}", Name = "GetPlaylistTrack")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetPlaylistTrack(int id)
        {
            try
            {
                if (id == 0)
                {
                    _logger.Log("Get a PlaylistTrack", "");
                    return BadRequest();
                }
                var playlistTrack = await _dbPlaylistTrack.GetAsync(u => u.PlaylistId == id);

                if (playlistTrack == null)
                {
                    return NotFound();
                }
                _response.Result = _mapper.Map<PlaylistTrackDto>(playlistTrack);
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
        public async Task<ActionResult<APIResponse>> CreatePlaylistTrack([FromBody] PlaylistTrackDto CreatePlaylistTrackDto)
        {
            try
            {

                if (CreatePlaylistTrackDto == null)
                {
                    return BadRequest(CreatePlaylistTrackDto);
                }
                if (CreatePlaylistTrackDto.PlaylistId > 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
                PlaylistTrack playlistTrack = _mapper.Map<PlaylistTrack>(CreatePlaylistTrackDto);
                await _dbPlaylistTrack.CreateAsync(playlistTrack);

                _response.Result = _mapper.Map<PlaylistTrackDto>(playlistTrack);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetPlaylistTrack", new { id = playlistTrack.PlaylistId }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorsMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("{id:int}", Name = "DeletePlaylistTrack")]
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
                var playlistTrack = await _dbPlaylistTrack.GetAsync(u => u.PlaylistId == id);
                if (id == null)
                {
                    return NotFound();
                }
                await _dbPlaylistTrack.RemoveAsync(playlistTrack);
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

        [HttpPut("{id:int}", Name = "UpdatePlaylistTrack")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdatePlaylistTrack(int id, [FromBody] PlaylistTrackDto updatePlaylistTrackDto)
        {
            try
            {
                if (updatePlaylistTrackDto == null || id != updatePlaylistTrackDto.PlaylistId)
                {
                    return BadRequest();
                }
                PlaylistTrack playlistTrack = _mapper.Map<PlaylistTrack>(updatePlaylistTrackDto);
                await _dbPlaylistTrack.UpdateAsync(playlistTrack);
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
        public async Task<ActionResult<APIResponse>> UpdatePartialPlaylistTrack(int id, JsonPatchDocument<PlaylistTrackDto> patchPlaylistTrackDTO)
        {
            try
            {
                if (patchPlaylistTrackDTO == null || id == 0)
                {
                    return BadRequest();
                }
                var playlistTrack = await _dbPlaylistTrack.GetAsync(u => u.PlaylistId == id, tracked: false);

                PlaylistTrackDto playlistTrackDto = _mapper.Map<PlaylistTrackDto>(playlistTrack);

                if (playlistTrack == null)
                {
                    return BadRequest();
                }
                patchPlaylistTrackDTO.ApplyTo(playlistTrackDto, ModelState);

                PlaylistTrack model = _mapper.Map<PlaylistTrack>(playlistTrackDto);

                await _dbPlaylistTrack.UpdateAsync(model);
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
