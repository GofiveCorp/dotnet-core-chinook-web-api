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
    public class InvoiceLineController : ControllerBase
    {
        protected APIResponse _response;
        private readonly IMapper _mapper;
        private readonly ILogging _logger;
        private readonly IInvoiceLineRepository invoicLineService;

        public InvoiceLineController(IMapper mappingConfig,
                                     ILogging logging,
                                     IInvoiceLineRepository dbContext)
        {
            this._response = new();
            _mapper = mappingConfig;
            _logger = logging;
            invoicLineService = dbContext;
        }

        [HttpGet]
        public async Task<ActionResult<APIResponse>> GetInvoiceLines(CancellationToken cancellationToken)
        {
            try
            {
                _logger.Log("Get All InvoiceLines", "");
                var invoiceLines = await invoicLineService.GetAllInvoiceLinesAsync(cancellationToken);
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

        [HttpGet("invoice/{id}")]
        public async Task<ActionResult<APIResponse>> GetByInvoice(int id)
        {
            try
            {
                var invoiceLines = await invoicLineService.GetInvoiceLineByInvoiceAsync(id);
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
                _response.ErrorsMessages = new List<string> { ex.ToString() };
            }
            return _response;
        }

    }
}