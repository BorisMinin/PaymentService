using StripePaymentService.Requests;

namespace StripePaymentService.Services
{
    public interface IStripeService
    {
        /// <summary>
        /// Create checkout session for payment of the product.
        /// <paramref name="token">Cancellation token.</paramref>
        /// </summary>
        public Task<string> CreateCheckoutSessionAsync(PaymentRequest request, CancellationToken token);
    }
}