using StripePaymentService.Services.Interfaces;
using StripePaymentService.Settings;
using Microsoft.Extensions.Options;
using Stripe;

namespace StripePaymentService.Services
{
    public class WebhookService : IWebhookService
    {
        private readonly string _webhookSecret;

        public WebhookService(IOptions<StripePaymentSettings> webhookSettings)
        {
            _webhookSecret = webhookSettings.Value.WebhookSigningKey;
        }

        public async Task HandleWebhookAsync(Stream body, Microsoft.Extensions.Primitives.StringValues headers, CancellationToken token)
        {
            // Parsing the body of the request received.
            var json = await new StreamReader(body).ReadToEndAsync(token); 

            // Verifies that the event was sent by Stripe by comparing the value of the Stripe-Signature with our unique webhook secret.
            var stripeEvent = EventUtility.ConstructEvent(json, headers, _webhookSecret);

            // Determines the event type and perform the appropriate action based on the event.
            await HandleStripeEventAsync(stripeEvent, token);
        }

        /// <summary>
        /// Determines the event type and perform the appropriate action based on the event.
        /// </summary>
        /// <param name="stripeEvent">The Stripe event to handle.</param>
        /// <param name="token">Cancellation token.</param>
        private Task HandleStripeEventAsync(Event stripeEvent, CancellationToken token)
        {
            switch (stripeEvent.Type)
            {
                case Events.CustomerSourceUpdated:
                    // Make sure payment info is valid
                    break;
                case Events.CustomerSourceExpiring:
                    // Send reminder email to update payment method
                    break;
                case Events.ChargeFailed:
                    // Handle charge failure
                    break;
            }

            return Task.CompletedTask; // Return a completed task
        }
    }
}