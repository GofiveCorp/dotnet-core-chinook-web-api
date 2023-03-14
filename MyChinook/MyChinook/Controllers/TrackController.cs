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
    public class TrackController : ControllerBase
    {
        protected APIResponse _response;       
        private readonly IMapper _mapper;
        private readonly ILogging _logger;
        private readonly ITrackRepository _dbTrack;

        public TrackController( IMapper mappingConfig,
                                ILogging logging,
                                ITrackRepository dbContext)
        {
            this._response = new();
            _mapper = mappingConfig;
            _logger = logging;
            _dbTrack = dbContext;                   
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetTracks()
        {
            try
            {
                _logger.Log("Get All Tracks", "");
                IEnumerable<Track> tracks = await _dbTrack.GetAllAsync();
                _response.Result = _mapper.Map<List<TrackDto>>(tracks);
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

        [HttpGet("{id:int}", Name = "GetTrack")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetTrack(int id)
        {
            try
            {
                if (id == 0)
                {
                    _logger.Log("Get a Track", "");
                    return BadRequest();
                }
                var track = await _dbTrack.GetAsync(u => u.TrackId == id);

                if (track == null)
                {
                    return NotFound();
                }
                _response.Result = _mapper.Map<TrackDto>(track);
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

        [HttpGet("album/id")]
        public async Task<ActionResult<APIResponse>> GetByAlbum(int id)
        {
            try
            {
                IEnumerable<Track> tracks = await _dbTrack.GetTrackByAlbumAsync(id);
                if (tracks == null)
                {
                    return NotFound();
                }
                _response.Result = _mapper.Map<List<TrackDto>>(tracks);
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

        [HttpGet("genre/id")]
        public async Task<ActionResult<APIResponse>> GetByGenre(int id)
        {
            try
            {
                IEnumerable<Track> tracks = await _dbTrack.GetTrackByGenreAsync(id);
                if (tracks == null)
                {
                    return NotFound();
                }
                _response.Result = _mapper.Map<List<TrackDto>>(tracks);
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

        [HttpGet("mediaType/id")]
        public async Task<ActionResult<APIResponse>> GetByMediaType(int id)
        {
            try
            {
                IEnumerable<Track> tracks = await _dbTrack.GetTrackByMediaTypeAsync(id);
                if (tracks == null)
                {
                    return NotFound();
                }
                _response.Result = _mapper.Map<List<TrackDto>>(tracks);
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
        public async Task<ActionResult<APIResponse>> CreateTrack([FromBody] TrackDto CreateTrackDto)
        {
            try
            {
                if (await _dbTrack.GetAsync(u => u.Name.ToLower() == CreateTrackDto.Name.ToLower()) != null)
                {
                    ModelState.AddModelError("Error Message", " This Track Already Exist");
                    return BadRequest(ModelState);
                }
                if (CreateTrackDto == null)
                {
                    return BadRequest(CreateTrackDto);
                }
                if (CreateTrackDto.TrackId > 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
                Track track = _mapper.Map<Track>(CreateTrackDto);
                //Update to Database (Entity)
                await _dbTrack.CreateAsync(track);
                //Response to API (Dto)
                _response.Result = _mapper.Map<TrackDto>(track);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetTrack", new { id = track.TrackId }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorsMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("{id:int}", Name = "DeleteTrack")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeleteGenre(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var track = await _dbTrack.GetAsync(u => u.TrackId == id);
                if (id == null)
                {
                    return NotFound();
                }
                await _dbTrack.RemoveAsync(track);
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

        [HttpPut("{id:int}", Name = "UpdateTrack")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateTrack(int id, [FromBody] TrackDto updateTrackDto)
        {
            try
            {
                if (updateTrackDto == null || id != updateTrackDto.TrackId)
                {
                    return BadRequest();
                }
                Track track = _mapper.Map<Track>(updateTrackDto);
                await _dbTrack.UpdateAsync(track);
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
        public async Task<ActionResult<APIResponse>> UpdatePartialTrack(int id, JsonPatchDocument<TrackDto> patchTrackDTO)
        {
            try
            {
                if (patchTrackDTO == null || id == 0)
                {
                    return BadRequest();
                }
                var track = await _dbTrack.GetAsync(u => u.TrackId == id, tracked: false);

                TrackDto trackDto = _mapper.Map<TrackDto>(track);

                if (track == null)
                {
                    return BadRequest();
                }
                patchTrackDTO.ApplyTo(trackDto, ModelState);

                Track model = _mapper.Map<Track>(trackDto);

                await _dbTrack.UpdateAsync(model);
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
