namespace StripePaymentService.Settings
{
    /// <summary>
    /// Represents the configuration settings required for Stripe payment processing.
    /// You can get values for SecretKey and PublishableKey on https://dashboard.stripe.com/ -> Developers -> Api keys.
    /// </summary>
    public class StripePaymentSettings
    {
        // The secret key used to authenticate API requests to Stripe.
        public string SecretKey { get; set; }
        // The publishable key used to identify your Stripe account in client-side requests.
        public string PublishableKey { get; set; }
    }
}