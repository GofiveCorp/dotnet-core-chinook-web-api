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
    public class MediaTypeController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IMapper _mapper;
        private readonly ILogging _logger;
        private readonly IMediaTypeRepository mediaTypeService;

        public MediaTypeController(IMapper mappingConfig,
                                   ILogging logging,
                                   IMediaTypeRepository dbContext)
        {
            this._response = new();
            _mapper = mappingConfig;
            _logger = logging;
            mediaTypeService = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetMediaTypes(CancellationToken cancellationToken)
        {
            try
            {
                _logger.Log("Get All MediaTypes", "");
                var mediaTypes = await mediaTypeService.GetAllMediaTypesAsync(cancellationToken);
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
    }
}
