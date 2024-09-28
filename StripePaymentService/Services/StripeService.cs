using Stripe.Checkout;
using StripePaymentService.Requests;

namespace StripePaymentService.Services
{
    public class StripeService : IStripeService
    {
        public async Task<string> CreateCheckoutSessionAsync(PaymentRequest request, CancellationToken token)
        {
            var stripeSession = new SessionService();

            var stripeCheckoutSession = await stripeSession
                .CreateAsync(new SessionCreateOptions
                {
                    Mode = "payment",
                    ClientReferenceId = Guid.NewGuid().ToString(),
                    SuccessUrl = request.SuccessUrl,// "https://localhost:7074/swagger/index.html",
                    CancelUrl = request.CancelUrl, //"https://localhost:7074/swagger/index.html",
                    CustomerEmail = request.CusttomerEmail,
                    LineItems = new()
                    {
                        new()
                        {
                            PriceData = new()
                            {
                                Currency = request.Currency, //"USD",
                                ProductData = new()
                                {
                                    Name = request.OrderName,
                                },
                                UnitAmount = request.UnitAmount
                            },
                            Quantity = request.Quantity
                        }
                    }
                }, cancellationToken: token);

            return stripeCheckoutSession.Url;
        }
    }
}