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
    public class GenreController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IMapper _mapper;
        private readonly ILogging _logger;
        private readonly IGenreRepository genreService;

        public GenreController(IMapper mappingConfig,
                               ILogging logging,
                               IGenreRepository dbContext)
        {
            this._response = new();
            _mapper = mappingConfig;
            _logger = logging;
            genreService = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetGenres(CancellationToken cancellationToken)
        {
            try
            {
                _logger.Log("Get All Genres", "");
                var genres = await genreService.GetAllGenresAsync(cancellationToken);
                _response.Result = _mapper.Map<List<GenreDto>>(genres);
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


