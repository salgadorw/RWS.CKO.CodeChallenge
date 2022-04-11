using Microsoft.AspNetCore.Mvc;
using PaymentGateway.Application.DTO;
using PaymentGateway.Application.Services.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PaymentGateway.Presentation.API.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class CardInfoController : ControllerBase
    {
        private readonly ICardInfoService cardInfoService;
        public CardInfoController(ICardInfoService cardInfoService)
        {
            this.cardInfoService = cardInfoService;
        }
        [HttpGet("{UserId}")]
        public async Task<IActionResult> Get(Guid userId, CancellationToken token = default)
        {
            var result = await cardInfoService.GetByUserId(userId, token);

            return Ok(result);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete(Guid id, CancellationToken token = default)
        {
            await cardInfoService.Delete(id, token);
            return Ok();
    }
        }
}
