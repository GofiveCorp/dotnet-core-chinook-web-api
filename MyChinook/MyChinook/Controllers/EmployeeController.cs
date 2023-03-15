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
    public class EmployeeController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IMapper _mapper;
        private readonly ILogging _logger;
        private readonly IEmployeeRepository _dbEmployee;

        public EmployeeController(IMapper mappingConfig,
                                  ILogging logging,
                                  IEmployeeRepository dbContext)
        {
            this._response = new();
            _mapper = mappingConfig;
            _logger = logging;
            _dbEmployee = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetEmployees()
        {
            try
            {
                _logger.Log("Get All Employees", "");
                IEnumerable<Employee> employee = await _dbEmployee.GetAllAsync();
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

        [HttpGet("{id:int}", Name = "GetEmployee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetEmployee(int id)
        {
            try
            {
                if (id == 0)
                {
                    _logger.Log("Get An Employee", "");
                    return BadRequest();
                }
                var employee = await _dbEmployee.GetAsync(u => u.EmployeeId == id);

                if (employee == null)
                {
                    return NotFound();
                }
                _response.Result = _mapper.Map<EmployeeDto>(employee);
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
        public async Task<ActionResult<APIResponse>> CreateEmployee([FromBody] EmployeeDto CreateEmployeeDto)
        {
            try
            {
                if (await _dbEmployee.GetAsync(u => u.FirstName.ToLower() == CreateEmployeeDto.FirstName.ToLower()) != null
                    && await _dbEmployee.GetAsync(u => u.LastName.ToLower() == CreateEmployeeDto.LastName.ToLower()) != null)
                {
                    ModelState.AddModelError("Error message", "This Name Already Exist");
                    return BadRequest(ModelState);
                }
                if (CreateEmployeeDto == null)
                {
                    return BadRequest(CreateEmployeeDto);
                }
                if (CreateEmployeeDto.EmployeeId > 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
                Employee employee = _mapper.Map<Employee>(CreateEmployeeDto);
                await _dbEmployee.CreateAsync(employee);
                _response.Result = _mapper.Map<EmployeeDto>(employee);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetEmployee", new { id = employee.EmployeeId }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorsMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("{id:int}", Name = "DeleteEmployee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeleteEmployee(int? id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var employee = await _dbEmployee.GetAsync(u => u.EmployeeId == id);
                if (id == null)
                {
                    return NotFound();
                }
                await _dbEmployee.RemoveAsync(employee);
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

        [HttpPut("{id:int}", Name = "UpdateEmployee")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateEmployee(int id, [FromBody] EmployeeDto updateEmployeeDto)
        {
            try
            {
                if (updateEmployeeDto == null || id != updateEmployeeDto.EmployeeId)
                {
                    return BadRequest();
                }
                Employee employee = _mapper.Map<Employee>(updateEmployeeDto);
                await _dbEmployee.UpdateAsync(employee);
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
        public async Task<ActionResult<APIResponse>> UpdatePartialEmployee(int id, JsonPatchDocument<EmployeeDto> patchEmployeeDTO)
        {
            try
            {
                if (patchEmployeeDTO == null || id == 0)
                {
                    return BadRequest();
                }
                var employee = await _dbEmployee.GetAsync(u => u.EmployeeId == id, tracked: false);

                EmployeeDto employeeDto = _mapper.Map<EmployeeDto>(employee);

                if (employee == null)
                {
                    return BadRequest();
                }
                patchEmployeeDTO.ApplyTo(employeeDto, ModelState);

                Employee model = _mapper.Map<Employee>(employeeDto);

                await _dbEmployee.UpdateAsync(model);
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
