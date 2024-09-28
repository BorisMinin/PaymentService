using Microsoft.AspNetCore.Mvc;
using StripePaymentService.Services;

namespace TestPayment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StripePaymentController : ControllerBase
    {
        private readonly StripeService _stripeService;

        public StripePaymentController(StripeService stripeService) => _stripeService = stripeService;

        [HttpPost("create-payment-url")]
        public async Task<string> CreatePaymentUrl(CancellationToken token) =>  await _stripeService.CreateCheckoutSessionAsync(token);
    }
}