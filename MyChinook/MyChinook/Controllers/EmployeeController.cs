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
    public class EmployeeController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IMapper _mapper;
        private readonly ILogging _logger;
        private readonly IEmployeeRepository employeeService;

        public EmployeeController(IMapper mappingConfig,
                                  ILogging logging,
                                  IEmployeeRepository dbContext)
        {
            this._response = new();
            _mapper = mappingConfig;
            _logger = logging;
            employeeService = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetEmployees(CancellationToken cancellationToken)
        {
            try
            {
               
                var employee = await employeeService.GetAllEmployeesAsync(cancellationToken);
                _response.Result = _mapper.Map<List<EmployeeDto>>(employee);
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

