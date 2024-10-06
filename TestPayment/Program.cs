using Stripe;
using StripePaymentService.Services;
using StripePaymentService.Services.Interfaces;
using StripePaymentService.Settings;

namespace TestPayment
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

            builder.Services.ConfigureOptions<ApplicationOptionsSetup>();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Todo: change implementation to IOptions (use StripePaymentSettings).
            builder.Services.Configure<StripePaymentSettings>(builder.Configuration.GetSection("Stripe"));
            builder.Services.AddScoped<IStripeService, StripeService>();
            builder.Services.AddScoped<StripeService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            StripeConfiguration.ApiKey = builder.Configuration.GetSection("Stripe")["SecretKey"];

            app.Run();
        }
    }
}