using Stripe.Checkout;
using StripePaymentService.Requests;
using StripePaymentService.Services.Interfaces;

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
                    SuccessUrl = request.SuccessUrl,
                    CancelUrl = request.CancelUrl,
                    CustomerEmail = request.CusttomerEmail,
                    LineItems = new()
                    {
                        new()
                        {
                            PriceData = new()
                            {
                                Currency = request.Currency,
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