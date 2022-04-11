using Microsoft.AspNetCore.Mvc;
using PaymentGateway.Application.DTO;
using PaymentGateway.Application.Services.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaymentGateway.Presentation.API.Controllers
{
    [Route("api/{MerchantId}/[controller]/")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly IPaymentService paymentService;
        public PaymentController(IPaymentService paymentService)
        {
            this.paymentService = paymentService;
        }
      
        [HttpGet]
        public async Task<IActionResult> Get([FromRoute] Guid merchantId, [FromQuery] Guid? UserId=null, CancellationToken token = default)
        {
            var result = await paymentService.GetPayments(merchantId, UserId, token);
            return Ok(result);
        }

      
        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] Guid merchantId, [FromRoute] Guid id, CancellationToken token = default)
        {
            var result = await paymentService.GetPayment(id, token);
            return Ok(result);
        }

       
        [HttpPost]
        public async Task<IActionResult> Post([FromRoute] Guid merchantId, [FromBody] PaymentDto value, [FromQuery] bool saveCardInfo=false, CancellationToken token= default)
        {
            value.MerchantId = merchantId;
            try
            {
                var result = await paymentService.ProcessPayment(value, token, saveCardInfo);
                return Ok(result);
            }
            catch (Exception ex)
            { 
               return BadRequest(ex.Message);
            }
        }       

    }
}
