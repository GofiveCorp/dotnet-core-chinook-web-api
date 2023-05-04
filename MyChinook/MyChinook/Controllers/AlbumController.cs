using AutoMapper;
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
    public class AlbumController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IMapper _mapper;
        private readonly ILogging _logger;
        private readonly IAlbumRepository albumService;

        public AlbumController(IMapper mappingConfig,
                               ILogging logging,
                               IAlbumRepository dbContext)
        {
            this._response = new();
            _mapper = mappingConfig;
            _logger = logging;
            albumService = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetAllAlbums(CancellationToken cancellationToken)
        {
            try
            {               
                var albums = await albumService.GetAllAlbumsAsync(cancellationToken);
                _response.Result = _mapper.Map<List<AlbumDetailDto>>(albums);
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

        [HttpGet("{albumId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetAnAlbum([FromRoute] int albumId, CancellationToken cancellationToken)
        {
            try
            {
                if (albumId == 0)
                {
                    return BadRequest();
                }
                var album = await albumService.GetAnAlbumAsync(albumId, cancellationToken);
                if (album == null)
                {
                    return NotFound();
                }
                _response.Result = _mapper.Map<AlbumDto>(album);
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

        [HttpGet("artist/{artistId}")]
        public async Task<ActionResult<APIResponse>> GetAlbumsByArtist(int artistId, CancellationToken cancellationToken)
        {
            try
            {
                var albums = await albumService.GetAlbumsByArtistAsync(artistId, cancellationToken);
                if (albums == null)
                {
                    return NotFound();
                }
                _response.Result = _mapper.Map<List<AlbumDto>>(albums);
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

        [HttpPost("create/{artistId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateAlbum([FromRoute] int artistId, [FromBody] AlbumCreateDto CreateAlbumDto, CancellationToken cancellationToken)
        {
            try
            {
                var albumDto = await albumService.CreateAlbumAsync(artistId, CreateAlbumDto, cancellationToken);

                _response.Result = albumDto;
                _response.StatusCode = HttpStatusCode.Created;
                return _response;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorsMessages = new List<string>() { ex.ToString() };
            }
            return Ok(_response);
        }

        [HttpDelete("delete/{albumId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeleteAlbum([FromRoute] int albumId, CancellationToken cancellationToken)
        {
            try
            {
                if (albumId == 0)
                {
                    return BadRequest();
                }
                var album = await albumService.GetAnAlbumAsync(albumId, cancellationToken);
                if (album == null)
                {
                    return NotFound();
                }
                var albumDeleteDto = await albumService.DeleteAlbumAsync(albumId, cancellationToken);
                _response.Result = albumDeleteDto;
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

        [HttpPut("update/{albumId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateAlbum([FromRoute]int albumId, [FromBody] AlbumUpdateDto albumUpdateDto, CancellationToken cancellationToken)
        {
            try
            {              
                var albumDetailDto = await albumService.UpdateAlbumAsync(albumId, albumUpdateDto, cancellationToken);
                _response.Result = albumDetailDto;
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


