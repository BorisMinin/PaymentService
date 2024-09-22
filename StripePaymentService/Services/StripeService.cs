using Stripe.Checkout;

namespace StripePaymentService.Services
{
    public class StripeService : IStripeService
    {
        public async Task<string> CreateCheckoutSessionAsync()
        {
            var stripeSession = new SessionService();

            var stripeCheckoutSession = await stripeSession
                .CreateAsync(new SessionCreateOptions
                {
                    Mode = "payment",
                    ClientReferenceId = Guid.NewGuid().ToString(),
                    SuccessUrl = "https://localhost:7074/swagger/index.html",
                    CancelUrl = "https://localhost:7074/swagger/index.html",
                    CustomerEmail = "boris.minin@outlook.com",
                    LineItems = new()
                    {
                        new()
                        {
                            PriceData = new()
                            {
                                Currency = "USD",
                                ProductData = new()
                                {
                                    Name = "TestProductName"
                                },
                                UnitAmount = 100 * 100
                            },
                            Quantity = 1
                        }
                    }
                });

            return stripeCheckoutSession.Url;
        }
    }
}