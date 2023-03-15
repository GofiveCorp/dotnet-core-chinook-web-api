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
    public class MediaTypeController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IMapper _mapper;
        private readonly ILogging _logger;
        private readonly IMediaTypeRepository _dbMediaType;

        public MediaTypeController(IMapper mappingConfig,
                                   ILogging logging,
                                   IMediaTypeRepository dbContext)
        {
            this._response = new();
            _mapper = mappingConfig;
            _logger = logging;
            _dbMediaType = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetMediaTypes()
        {
            try
            {
                _logger.Log("Get All MediaTypes", "");
                IEnumerable<MediaType> mediaTypes = await _dbMediaType.GetAllAsync();
                _response.Result = _mapper.Map<List<MediaTypeDto>>(mediaTypes);
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

        [HttpGet("{id:int}", Name = "GetMediaType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetMediaType(int id)
        {
            try
            {
                if (id == 0)
                {
                    _logger.Log("Get a MediaType", "");
                    return BadRequest();
                }
                var mediaType = await _dbMediaType.GetAsync(u => u.MediaTypeId == id);

                if (mediaType == null)
                {
                    return NotFound();
                }
                _response.Result = _mapper.Map<MediaTypeDto>(mediaType);
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
        public async Task<ActionResult<APIResponse>> CreateMediaType([FromBody] MediaTypeDto CreateMediaTypeDto)
        {
            try
            {
                if (await _dbMediaType.GetAsync(u => u.Name.ToLower() == CreateMediaTypeDto.Name.ToLower()) != null)
                {
                    ModelState.AddModelError("Error Message", " This Media Already Exist");
                    return BadRequest(ModelState);
                }
                if (CreateMediaTypeDto == null)
                {
                    return BadRequest(CreateMediaTypeDto);
                }
                if (CreateMediaTypeDto.MediaTypeId > 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
                MediaType mediaType = _mapper.Map<MediaType>(CreateMediaTypeDto);
                //Update to Database
                await _dbMediaType.CreateAsync(mediaType);
                //Response to API
                _response.Result = _mapper.Map<MediaTypeDto>(mediaType);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetMediaType", new { id = mediaType.MediaTypeId }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorsMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("{id:int}", Name = "DeleteMediaType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeleteMediaType(int? id)
        {
            try
            {

                if (id < 1)
                {
                    string ms = "ID number can not be less than 1 ";
                    return BadRequest(ms);
                }
                var mediaType = await _dbMediaType.GetAsync(u => u.MediaTypeId == id);
                if (id == null)
                {
                    return NotFound();
                }
                await _dbMediaType.RemoveAsync(mediaType);
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

        [HttpPut("{id:int}", Name = "UpdateMediaType")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateMediaType(int id, [FromBody] MediaTypeDto updateMediaTypeDto)
        {
            try
            {
                if (updateMediaTypeDto == null || id != updateMediaTypeDto.MediaTypeId)
                {
                    return BadRequest();
                }
                MediaType mediaType = _mapper.Map<MediaType>(updateMediaTypeDto);
                await _dbMediaType.UpdateAsync(mediaType);
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
        public async Task<ActionResult<APIResponse>> UpdatePartialMediaType(int id, JsonPatchDocument<MediaTypeDto> patchMediaTypeDTO)
        {
            try
            {
                if (patchMediaTypeDTO == null || id == 0)
                {
                    return BadRequest();
                }
                var mediaType = await _dbMediaType.GetAsync(u => u.MediaTypeId == id, tracked: false);

                MediaTypeDto mediaTypeDto = _mapper.Map<MediaTypeDto>(mediaType);

                if (mediaType == null)
                {
                    return BadRequest();
                }
                patchMediaTypeDTO.ApplyTo(mediaTypeDto, ModelState);

                MediaType model = _mapper.Map<MediaType>(mediaTypeDto);

                await _dbMediaType.UpdateAsync(model);
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
