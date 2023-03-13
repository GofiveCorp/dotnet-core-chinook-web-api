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
    public class ArtistController : ControllerBase
    {
        protected APIResponse _response;
        private readonly ILogging _logger;
        private readonly IArtistRepository _dbArtist;
        private readonly IMapper _mapper;

        public ArtistController(ILogging logging
                                  , IArtistRepository dbContext
                                  , IMapper mappingConfig)
        {
            _dbArtist = dbContext;
            _mapper = mappingConfig;
            _logger = logging;
            this._response = new();
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetArtists()
        {
            try
            {
                _logger.Log("Get All Artists", "");
                IEnumerable<Artist> artists = await _dbArtist.GetAllAsync();
                _response.Result = _mapper.Map<List<ArtistDto>>(artists);
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

        [HttpGet("{id:int}", Name = "GetArtist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetArtist(int id)
        {
            try
            {
                if (id == 0)
                {
                    _logger.Log("Get a Artist", "");
                    return BadRequest();
                }
                var artist = await _dbArtist.GetAsync(u => u.ArtistId == id);

                if (artist == null)
                {
                    return NotFound();
                }
                _response.Result = _mapper.Map<ArtistDto>(artist);
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
        public async Task<ActionResult<APIResponse>> CreateArtist([FromBody] ArtistDto CreateArtistDto)
        {
            try
            {    
                if ( await _dbArtist.GetAsync(u => u.Name.ToLower() == CreateArtistDto.Name.ToLower()) != null)
                {
                    ModelState.AddModelError("Error Message"," This Name Already Exist");
                    return BadRequest(ModelState);
                }
                if (CreateArtistDto == null)
                {
                    return BadRequest(CreateArtistDto);
                }
                if (CreateArtistDto.ArtistId > 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
                Artist artist = _mapper.Map<Artist>(CreateArtistDto);
                await _dbArtist.CreateAsync(artist);

                _response.Result = _mapper.Map<ArtistDto>(artist);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetArtist", new { id = artist.ArtistId }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorsMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("{id:int}", Name = "DeleteArtist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeleteArtist(int id)
        {
            try
            {

                if (id == 0)
                {
                    return BadRequest();
                }
                var artist = await _dbArtist.GetAsync(u => u.ArtistId == id);
                if (id == null)
                {
                    return NotFound();
                }
                await _dbArtist.RemoveAsync(artist);
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

        [HttpPut("{id:int}", Name = "UpdateArtist")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateArtist(int id, [FromBody] ArtistDto updateArtistDto)
        {
            try
            {
                if (updateArtistDto == null || id != updateArtistDto.ArtistId)
                {
                    return BadRequest();
                }
                Artist artist = _mapper.Map<Artist>(updateArtistDto);
                await _dbArtist.UpdateAsync(artist);
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
        public async Task<ActionResult<APIResponse>> UpdatePartialArtist(int id, JsonPatchDocument<ArtistDto> patchArtistDTO)
        {
            try
            {
                if (patchArtistDTO == null || id == 0)
                {
                    return BadRequest();
                }
                var artist = await _dbArtist.GetAsync(u => u.ArtistId == id, tracked: false);

                ArtistDto artistDto = _mapper.Map<ArtistDto>(artist);

                if (artist == null)
                {
                    return BadRequest();
                }
                patchArtistDTO.ApplyTo(artistDto, ModelState);

                Artist model = _mapper.Map<Artist>(artistDto);

                await _dbArtist.UpdateAsync(model);
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
