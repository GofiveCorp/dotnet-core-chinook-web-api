using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using MyChinook.Customizes.Logging;
using MyChinook.Models;
using MyChinook.Models.Dtos;
using MyChinook.Models.Responses;
using MyChinook.Repositories.IRepositories;
using System.Net;
using System.Threading;

namespace MyChinook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IMapper _mapper;
        private readonly ILogging _logger;
        private readonly ICustomerRepository customerService;

        public CustomerController(IMapper mappingConfig,
                                  ILogging logging,
                                  ICustomerRepository dbContext)
        {
            this._response = new();
            _mapper = mappingConfig;
            _logger = logging;
            customerService = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetCustomers(CancellationToken cancellationToken)
        {
            try
            {            
                var customers = await customerService.GetAllCustomersAsync(cancellationToken);
                _response.Result = _mapper.Map<List<CustomerDto>>(customers);
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
