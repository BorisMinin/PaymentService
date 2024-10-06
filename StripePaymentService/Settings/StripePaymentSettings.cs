namespace StripePaymentService.Settings
{
    /// <summary>
    /// Represents the configuration settings required for Stripe payment processing.
    /// You can get values for SecretKey and PublishableKey on https://dashboard.stripe.com/ -> Developers -> Api keys.
    /// </summary>
    public class StripePaymentSettings
    {
        /// <summary>
        /// The secret key used to authenticate API requests to Stripe.
        /// </summary>
        public string SecretKey { get; set; }
        /// <summary>
        /// The publishable key used to identify your Stripe account in client-side requests.
        /// </summary>
        public string PublishableKey { get; set; }
        /// <summary>
        /// The webhook signing key used to authenticate webhook requests from Stripe.
        /// </summary>
        public string WebhookSigningKey { get; set; }
    }
}