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
    public class TrackController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IMapper _mapper;
        private readonly ILogging _logger;
        private readonly ITrackRepository trackService;

        public TrackController(IMapper mappingConfig,
                                ILogging logging,
                                ITrackRepository dbContext)
        {
            this._response = new();
            _mapper = mappingConfig;
            _logger = logging;
            trackService = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetTracks(CancellationToken cancellationToken)
        {
            try
            {
                _logger.Log("Get All Tracks", "");
                var tracks = await trackService.GetAllTracksAsync(cancellationToken);
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

        [HttpGet("album/id")]
        public async Task<ActionResult<APIResponse>> GetByAlbum(int id)
        {
            try
            {
                var tracks = await trackService.GetTrackByAlbumAsync(id);
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
                var tracks = await trackService.GetTrackByGenreAsync(id);
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
                var tracks = await trackService.GetTrackByMediaTypeAsync(id);
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
    }
}