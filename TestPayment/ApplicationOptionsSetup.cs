using Microsoft.Extensions.Options;
using StripePaymentService.Settings;

namespace TestPayment
{
    public class ApplicationOptionsSetup : IConfigureOptions<StripePaymentSettings>
    {
        private readonly IConfiguration _configuration;

        public ApplicationOptionsSetup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(StripePaymentSettings options)
        {
            _configuration.GetSection(nameof(StripePaymentSettings))
                .Bind(options);
        }
    }
}