using Microsoft.AspNetCore.Mvc;
using Stripe;
using Stripe.Checkout;
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
        public async Task<string> CreatePaymentUrl() => await _stripeService.CreateCheckoutSessionAsync();
    }
}