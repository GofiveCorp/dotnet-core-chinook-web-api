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
    public class GenreController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IMapper _mapper;
        private readonly ILogging _logger;
        private readonly IGenreRepository _dbGenre;

        public GenreController(IMapper mappingConfig,
                               ILogging logging,
                               IGenreRepository dbContext)
        {
            this._response = new();
            _mapper = mappingConfig;
            _logger = logging;
            _dbGenre = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetGenres()
        {
            try
            {
                _logger.Log("Get All Genres", "");
                IEnumerable<Genre> genres = await _dbGenre.GetAllAsync();
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

        [HttpGet("{id:int}", Name = "GetGenre")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetGenre(int id)
        {
            try
            {
                if (id == 0)
                {
                    _logger.Log("Get a Genre", "");
                    return BadRequest();
                }
                var genre = await _dbGenre.GetAsync(u => u.GenreId == id);

                if (genre == null)
                {
                    return NotFound();
                }
                _response.Result = _mapper.Map<GenreDto>(genre);
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
        public async Task<ActionResult<APIResponse>> CreateGenre([FromBody] GenreDto CreateGenreDto)
        {
            try
            {
                if (await _dbGenre.GetAsync(u => u.Name.ToLower() == CreateGenreDto.Name.ToLower()) != null)
                {
                    ModelState.AddModelError("Error Message", " This Genre Already Exist");
                    return BadRequest(ModelState);
                }
                if (CreateGenreDto == null)
                {
                    return BadRequest(CreateGenreDto);
                }
                if (CreateGenreDto.GenreId > 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
                Genre genre = _mapper.Map<Genre>(CreateGenreDto);
                //Update to Database (Entity)
                await _dbGenre.CreateAsync(genre);
                //Response to API (Dto)
                _response.Result = _mapper.Map<GenreDto>(genre);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetGenre", new { id = genre.GenreId }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorsMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("{id:int}", Name = "DeleteGenre")]
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
                var genre = await _dbGenre.GetAsync(u => u.GenreId == id);
                if (id == null)
                {
                    return NotFound();
                }
                await _dbGenre.RemoveAsync(genre);
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

        [HttpPut("{id:int}", Name = "UpdateGenre")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateGenre(int id, [FromBody] GenreDto updateGenreDto)
        {
            try
            {
                if (updateGenreDto == null || id != updateGenreDto.GenreId)
                {
                    return BadRequest();
                }
                Genre genre = _mapper.Map<Genre>(updateGenreDto);
                await _dbGenre.UpdateAsync(genre);
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
        public async Task<ActionResult<APIResponse>> UpdatePartialGenre(int id, JsonPatchDocument<GenreDto> patchGenreDTO)
        {
            try
            {
                if (patchGenreDTO == null || id == 0)
                {
                    return BadRequest();
                }
                var genre = await _dbGenre.GetAsync(u => u.GenreId == id, tracked: false);

                GenreDto genreDto = _mapper.Map<GenreDto>(genre);

                if (genre == null)
                {
                    return BadRequest();
                }
                patchGenreDTO.ApplyTo(genreDto, ModelState);

                Genre model = _mapper.Map<Genre>(genreDto);

                await _dbGenre.UpdateAsync(model);
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
