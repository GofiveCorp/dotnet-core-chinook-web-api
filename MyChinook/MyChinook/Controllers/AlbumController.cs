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
    public class AlbumController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IMapper _mapper;
        private readonly ILogging _logger;
        private readonly IAlbumRepository _dbAlbum;

        public AlbumController(IMapper mappingConfig,
                               ILogging logging,
                               IAlbumRepository dbContext)
        {
            this._response = new();
            _mapper = mappingConfig;
            _logger = logging;
            _dbAlbum = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetAlbums()
        {
            try
            {
                _logger.Log("Get All Albums", "");
                IEnumerable<Album> albums = await _dbAlbum.GetAllAsync();
                _response.Result = _mapper.Map<List<AlbumDto>>(albums);
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

        [HttpGet("{id:int}", Name = "GetAlbum")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetAlbum(int id)
        {
            try
            {
                if (id == 0)
                {
                    _logger.Log("Get a Album", "");
                    return BadRequest();
                }
                var album = await _dbAlbum.GetAsync(u => u.AlbumId == id);

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

        [HttpGet("artist/{id}")]
        public async Task<ActionResult<APIResponse>> GetByArtist(int id)
        {
            try
            {
                IEnumerable<Album> albums = await _dbAlbum.GetAlbumByArtistAsync(id);
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

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateAlbum([FromBody] AlbumDto CreateAlbumDto)
        {
            try
            {
                if (await _dbAlbum.GetAsync(u => u.Title.ToLower() == CreateAlbumDto.Title.ToLower()) != null)
                {
                    ModelState.AddModelError("Error Message", " This Title Already Exist");
                    return BadRequest(ModelState);
                }
                if (CreateAlbumDto == null)
                {
                    return BadRequest(CreateAlbumDto);
                }
                if (CreateAlbumDto.AlbumId > 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
                Album album = _mapper.Map<Album>(CreateAlbumDto);
                await _dbAlbum.CreateAsync(album);

                _response.Result = _mapper.Map<AlbumDto>(album);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetAlbum", new { id = album.AlbumId }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorsMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("{id:int}", Name = "DeleteAlbum")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeleteAlbum(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var album = await _dbAlbum.GetAsync(u => u.AlbumId == id);
                if (id == null)
                {
                    return NotFound();
                }
                await _dbAlbum.RemoveAsync(album);
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

        [HttpPut("{id:int}", Name = "UpdateAlbum")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateAlbum(int id, [FromBody] AlbumDto updateAlbumDto)
        {
            try
            {
                if (updateAlbumDto == null || id != updateAlbumDto.AlbumId)
                {
                    return BadRequest();
                }
                Album album = _mapper.Map<Album>(updateAlbumDto);
                await _dbAlbum.UpdateAsync(album);
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
        public async Task<ActionResult<APIResponse>> UpdatePartialAlbum(int id, JsonPatchDocument<AlbumDto> patchAlbumDTO)
        {
            try
            {
                if (patchAlbumDTO == null || id == 0)
                {
                    return BadRequest();
                }
                var album = await _dbAlbum.GetAsync(u => u.AlbumId == id, tracked: false);

                AlbumDto albumDto = _mapper.Map<AlbumDto>(album);

                if (album == null)
                {
                    return BadRequest();
                }
                patchAlbumDTO.ApplyTo(albumDto, ModelState);
                Album model = _mapper.Map<Album>(albumDto);
                await _dbAlbum.UpdateAsync(model);
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
