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
    public class CustomerController : ControllerBase
    {
        protected APIResponse _response;
        private readonly ILogging _logger;
        private readonly ICustomerRepository _dbCustomer;
        private readonly IMapper _mapper;

        public CustomerController(ILogging logging
                                  , ICustomerRepository dbContext
                                  , IMapper mappingConfig)
        {
            _dbCustomer = dbContext;
            _mapper = mappingConfig;
            _logger = logging;
            this._response = new();
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetCustomers()
        {
            try
            {
                _logger.Log("Get All Customers", "");
                IEnumerable<Customer> customers = await _dbCustomer.GetAllAsync();
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

        [HttpGet("{id:int}", Name = "GetCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetCustomer(int id)
        {
            try
            {
                if (id == 0)
                {
                    _logger.Log("Get a Customer", "");
                    return BadRequest();
                }
                var customer = await _dbCustomer.GetAsync(u => u.CustomerId == id);

                if (customer == null)
                {
                    return NotFound();
                }
                _response.Result = _mapper.Map<CustomerDto>(customer);
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
        public async Task<ActionResult<APIResponse>> CreateCustomer([FromBody] CustomerDto CreateCustomerDto)
        {
            try
            {
                if (await _dbCustomer.GetAsync(u => u.FirstName.ToLower() == CreateCustomerDto.FirstName.ToLower()) != null
                    && await _dbCustomer.GetAsync(u => u.LastName.ToLower() == CreateCustomerDto.LastName.ToLower()) != null)
                {
                    ModelState.AddModelError("Error message", "This Name Already Exist");
                    return BadRequest(ModelState);
                }
                if (CreateCustomerDto == null)
                {
                    return BadRequest(CreateCustomerDto);
                }
                if (CreateCustomerDto.CustomerId > 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
                Customer customer = _mapper.Map<Customer>(CreateCustomerDto);
                await _dbCustomer.CreateAsync(customer);
                _response.Result = _mapper.Map<CustomerDto>(customer);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetCustomer", new { id = customer.CustomerId }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorsMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("{id:int}", Name = "DeleteCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeleteCustomer(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var customer = await _dbCustomer.GetAsync(u => u.CustomerId == id);
                if (id == null)
                {
                    return NotFound();
                }
                await _dbCustomer.RemoveAsync(customer);
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

        [HttpPut("{id:int}", Name = "UpdateCustomer")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateCustomer(int id, [FromBody] CustomerDto updateCustomerDto)
        {
            try
            {
                if (updateCustomerDto == null || id != updateCustomerDto.CustomerId)
                {
                    return BadRequest();
                }
                Customer customer = _mapper.Map<Customer>(updateCustomerDto);
                await _dbCustomer.UpdateAsync(customer);
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
        public async Task<ActionResult<APIResponse>> UpdatePartialCustomer(int id, JsonPatchDocument<CustomerDto> patchCustomerDTO)
        {
            try
            {
                if (patchCustomerDTO == null || id == 0)
                {
                    return BadRequest();
                }
                var customer = await _dbCustomer.GetAsync(u => u.CustomerId == id, tracked: false);

                CustomerDto customerDto = _mapper.Map<CustomerDto>(customer);

                if (customer == null)
                {
                    return BadRequest();
                }
                patchCustomerDTO.ApplyTo(customerDto, ModelState);

                Customer model = _mapper.Map<Customer>(customerDto);

                await _dbCustomer.UpdateAsync(model);
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
