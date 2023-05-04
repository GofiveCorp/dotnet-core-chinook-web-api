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
    public class InvoiceController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IMapper _mapper;
        private readonly ILogging _logger;
        private readonly IInvoiceRepository invoiceService;

        public InvoiceController(IMapper mappingConfig,
                                 ILogging logging,
                                 IInvoiceRepository dbContext)
        {
            this._response = new();
            _mapper = mappingConfig;
            _logger = logging;
            invoiceService = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetInvoices(CancellationToken cancellationToken)
        {
            try
            {
                _logger.Log("Get All Invoices", "");
                var invoices = await invoiceService.GetAllInvoicesAsync(cancellationToken);
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

        [HttpGet("customer/{id}")]
        public async Task<ActionResult<APIResponse>> GetByCustomer(int id)
        {
            try
            {
                var invoices = await invoiceService.GetInvoiceByCustomerAsync(id);
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
    }
}

