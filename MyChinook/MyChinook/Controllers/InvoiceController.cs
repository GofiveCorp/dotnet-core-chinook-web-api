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
    public class InvoiceController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IMapper _mapper;
        private readonly ILogging _logger;
        private readonly IInvoiceRepository _dbInvoice;

        public InvoiceController(IMapper mappingConfig,
                                 ILogging logging,
                                 IInvoiceRepository dbContext)
        {
            this._response = new();
            _mapper = mappingConfig;
            _logger = logging;
            _dbInvoice = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetInvoices()
        {
            try
            {
                _logger.Log("Get All Invoices", "");
                IEnumerable<Invoice> invoices = await _dbInvoice.GetAllAsync();
                _response.Result = _mapper.Map<List<InvoiceDto>>(invoices);
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

        [HttpGet("{id:int}", Name = "GetInvoice")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetInvoice(int id)
        {
            try
            {
                if (id == 0)
                {
                    _logger.Log("Get a Invoice", "");
                    return BadRequest();
                }
                var invoice = await _dbInvoice.GetAsync(u => u.InvoiceId == id);

                if (invoice == null)
                {
                    return NotFound();
                }
                _response.Result = _mapper.Map<InvoiceDto>(invoice);
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

        [HttpGet("customer/{id}")]
        public async Task<ActionResult<APIResponse>> GetByCustomer(int id)
        {
            try
            {
                IEnumerable<Invoice> invoices = await _dbInvoice.GetInvoiceByCustomerAsync(id);
                if (invoices == null)
                {
                    return NotFound(id);
                }
                _response.Result = _mapper.Map<List<InvoiceDto>>(invoices);
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
        public async Task<ActionResult<APIResponse>> CreateInvoice([FromBody] InvoiceDto CreateInvoiceDto)
        {
            try
            {
                if (CreateInvoiceDto == null)
                {
                    return BadRequest(CreateInvoiceDto);
                }
                if (CreateInvoiceDto.InvoiceId > 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
                Invoice invoice = _mapper.Map<Invoice>(CreateInvoiceDto);
                await _dbInvoice.CreateAsync(invoice);

                _response.Result = _mapper.Map<InvoiceDto>(invoice);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetInvoice", new { id = invoice.InvoiceId }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorsMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("{id:int}", Name = "DeleteInvoice")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeleteInvoice(int? id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var invoice = await _dbInvoice.GetAsync(u => u.InvoiceId == id);
                if (invoice == null)
                {
                    return NotFound();
                }
                await _dbInvoice.RemoveAsync(invoice);
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

        [HttpPut("{id:int}", Name = "UpdateInvoice")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateInvoice(int id, [FromBody] InvoiceDto updateInvoiceDto)
        {
            try
            {
                if (updateInvoiceDto == null || id != updateInvoiceDto.InvoiceId)
                {
                    return BadRequest();
                }
                Invoice invoice = _mapper.Map<Invoice>(updateInvoiceDto);
                await _dbInvoice.UpdateAsync(invoice);
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
        public async Task<ActionResult<APIResponse>> UpdatePartialInvoice(int id, JsonPatchDocument<InvoiceDto> patchInvoiceDTO)
        {
            try
            {
                if (patchInvoiceDTO == null || id == 0)
                {
                    return BadRequest();
                }
                var invoice = await _dbInvoice.GetAsync(u => u.InvoiceId == id, tracked: false);

                InvoiceDto invoiceDto = _mapper.Map<InvoiceDto>(invoice);

                if (invoice == null)
                {
                    return BadRequest();
                }
                patchInvoiceDTO.ApplyTo(invoiceDto, ModelState);

                Invoice model = _mapper.Map<Invoice>(invoiceDto);

                await _dbInvoice.UpdateAsync(model);
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
