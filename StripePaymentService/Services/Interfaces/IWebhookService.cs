namespace StripePaymentService.Services.Interfaces
{
    public interface IWebhookService
    {
        /// <summary>
        /// Handles the incoming webhook request from Stripe.
        /// </summary>
        /// <param name="body">The stream containing the request body.</param>
        /// <param name="headers">The headers from the incoming request.</param>
        /// <param name="token">Cancellation token.</param>
        /// <returns></returns>
        Task HandleWebhookAsync(Stream body, Microsoft.Extensions.Primitives.StringValues headers, CancellationToken token);
    }
}