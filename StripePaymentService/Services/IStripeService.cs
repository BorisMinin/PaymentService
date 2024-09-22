using StripePaymentService.Models;

namespace StripePaymentService.Services
{
    public interface IStripeService
    {
        /// <summary>
        /// Create checkout session for payment of the product
        /// </summary>
        public Task<string> CreateCheckoutSessionAsync();
    }
}