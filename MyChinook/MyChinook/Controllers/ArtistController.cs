using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MyChinook.Customizes.Logging;
using MyChinook.Models;
using MyChinook.Models.Dtos;
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
        private readonly IMapper _mapper;
        private readonly ILogging _logger;
        private readonly IArtistRepository artistService;

        public ArtistController(IMapper mappingConfig,
                                ILogging logging,
                                IArtistRepository dbContext)
        {
            this._response = new();
            _mapper = mappingConfig;
            _logger = logging;
            artistService = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetArtists(CancellationToken cancellationToken)
        {
            try
            {
                var artists = await artistService.GetAllArtistsAsync(cancellationToken);
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

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetArtist([FromRoute] int id, CancellationToken cancellationToken)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var artist = await artistService.GetAnArtistAsync(id, cancellationToken);
                if (artist == null)
                {
                    return NotFound();
                }
                _response.Result = _mapper.Map<ArtistDetailDto>(artist);
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

        [HttpPost("create")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateArtist([FromBody] ArtiArtistCreateDto CreateArtistDto, CancellationToken cancellationToken)
        {
            try
            {
                if (CreateArtistDto == null)
                {
                    return BadRequest(CreateArtistDto);
                }
                var newArtist = await artistService.CreateArtistAsync(CreateArtistDto, cancellationToken);

                _response.Result = newArtist;
                _response.StatusCode = HttpStatusCode.Created;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorsMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("delete")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeleteArtist([FromQuery]int id,CancellationToken cancellationToken)
        {
            try
            {
                var artist = await artistService.GetAnArtistAsync(id, cancellationToken);
                if (artist == null)
                {
                    return NotFound();
                }
                var deletedArtist = await artistService.DeleteArtistAsync(id, cancellationToken);
                _response.Result = deletedArtist;
                _response.StatusCode = HttpStatusCode.OK;
                _response.IsSuccess = true;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorsMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpPut("update/{artistId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateAlbum([FromRoute] int artistId, [FromBody] ArtistUpdateDto artistUpdateDto, CancellationToken cancellationToken)
        {
            try
            {
                var artistDetailDto = await artistService.UpdateAlbumAsync(artistId, artistUpdateDto, cancellationToken);
                _response.Result = artistDetailDto;
                _response.IsSuccess = true;
                _response.StatusCode = HttpStatusCode.OK;
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

