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
    public class InvoiceLineController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IMapper _mapper;
        private readonly ILogging _logger;
        private readonly IInvoiceLineRepository _dbInvoiceLine;

        public InvoiceLineController(IMapper mappingConfig,
                                     ILogging logging,
                                     IInvoiceLineRepository dbContext)
        {
            this._response = new();
            _mapper = mappingConfig;
            _logger = logging;
            _dbInvoiceLine = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetInvoiceLines()
        {
            try
            {
                _logger.Log("Get All InvoiceLines", "");
                IEnumerable<InvoiceLine> invoiceLines = await _dbInvoiceLine.GetAllAsync();
                _response.Result = _mapper.Map<List<InvoiceLineDto>>(invoiceLines);
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

        [HttpGet("{id:int}", Name = "GetInvoiceLine")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> GetInvoiceLine(int id)
        {
            try
            {
                if (id == 0)
                {
                    _logger.Log("Get a InvoiceLine", "");
                    return BadRequest();
                }
                var invoiceLine = await _dbInvoiceLine.GetAsync(u => u.InvoiceLineId == id);

                if (invoiceLine == null)
                {
                    return NotFound();
                }
                _response.Result = _mapper.Map<InvoiceLineDto>(invoiceLine);
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

        [HttpGet("invoice/{id}")]       
        public async Task<ActionResult<APIResponse>> GetByInvoice(int id)
        {
            try
            {
                IEnumerable<InvoiceLine> invoiceLines = await _dbInvoiceLine.GetInvoiceLineByInvoiceAsync(id);
                if (invoiceLines == null)
                {
                    return NotFound();
                }
                _response.Result = _mapper.Map<List<InvoiceLineDto>>(invoiceLines);
                _response.StatusCode = HttpStatusCode.OK;
                return Ok(_response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorsMessages = new List<string> { ex.ToString()};
            }
            return _response;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<ActionResult<APIResponse>> CreateInvoiceLine([FromBody] InvoiceLineDto CreateInvoiceLineDto)
        {
            try
            {
                if (CreateInvoiceLineDto == null)
                {
                    return BadRequest(CreateInvoiceLineDto);
                }
                if (CreateInvoiceLineDto.InvoiceLineId > 0)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError);
                }
                InvoiceLine invoiceLine = _mapper.Map<InvoiceLine>(CreateInvoiceLineDto);
                await _dbInvoiceLine.CreateAsync(invoiceLine);

                _response.Result = _mapper.Map<InvoiceLineDto>(invoiceLine);
                _response.StatusCode = HttpStatusCode.Created;
                return CreatedAtRoute("GetInvoiceLine", new { id = invoiceLine.InvoiceLineId }, _response);
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorsMessages = new List<string>() { ex.ToString() };
            }
            return _response;
        }

        [HttpDelete("{id:int}", Name = "DeleteInvoiceLine")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<ActionResult<APIResponse>> DeleteInvoiceLine(int id)
        {
            try
            {
                if (id == 0)
                {
                    return BadRequest();
                }
                var invoiceLine = await _dbInvoiceLine.GetAsync(u => u.InvoiceLineId == id);
                if (id == null)
                {
                    return NotFound();
                }
                await _dbInvoiceLine.RemoveAsync(invoiceLine);
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

        [HttpPut("{id:int}", Name = "UpdateInvoiceLine")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<APIResponse>> UpdateInvoiceLine(int id, [FromBody] InvoiceLineDto updateInvoiceLineDto)
        {
            try
            {
                if (updateInvoiceLineDto == null || id != updateInvoiceLineDto.InvoiceLineId)
                {
                    return BadRequest();
                }
                InvoiceLine invoiceLine = _mapper.Map<InvoiceLine>(updateInvoiceLineDto);
                await _dbInvoiceLine.UpdateAsync(invoiceLine);
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
        public async Task<ActionResult<APIResponse>> UpdatePartialInvoiceLine(int id, JsonPatchDocument<InvoiceLineDto> patchInvoiceLineDTO)
        {
            try
            {
                if (patchInvoiceLineDTO == null || id == 0)
                {
                    return BadRequest();
                }
                var invoiceLine = await _dbInvoiceLine.GetAsync(u => u.InvoiceLineId == id, tracked: false);

                InvoiceLineDto invoiceLineDto = _mapper.Map<InvoiceLineDto>(invoiceLine);

                if (invoiceLine == null)
                {
                    return BadRequest();
                }
                patchInvoiceLineDTO.ApplyTo(invoiceLineDto, ModelState);

                InvoiceLine model = _mapper.Map<InvoiceLine>(invoiceLineDto);

                await _dbInvoiceLine.UpdateAsync(model);
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
