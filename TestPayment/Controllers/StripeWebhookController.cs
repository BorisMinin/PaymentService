using Microsoft.AspNetCore.Mvc;
using Stripe;
using StripePaymentService.Services.Interfaces;

namespace TestPayment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StripeWebhookController : ControllerBase
    {
        private readonly IWebhookService _webhookService;

        public StripeWebhookController(IWebhookService webhookService)
        {
            _webhookService = webhookService;
        }

        [HttpPost("webhook")]
        public async Task<IActionResult> Index(CancellationToken token)
        {
            try
            {
                var requestBody = HttpContext.Request.Body;
                var requestHeaders = Request.Headers["Stripe-Signature"];

                await _webhookService.HandleWebhookAsync(requestBody, requestHeaders, token);

                return Ok();
            }
            catch (StripeException)
            {
                return BadRequest();
            }
        }
    }
}