using Kiosk.Core;
using Kiosk.DAL;
using Kiosk.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Logging.AddConsole();

//Get configuration
var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

ConfigureServices(builder.Services, config);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiddleware<ExceptionMiddleware>();

app.MapControllers();

app.Run();

void ConfigureServices(IServiceCollection services, IConfigurationRoot configuration)
{
    services.AddDbContext<KioskDbContext>(taskOpt =>
       taskOpt.UseSqlServer(configuration.GetConnectionString("DefaultConnection"), b => b.MigrationsAssembly("Kiosk.DAL").EnableRetryOnFailure(5)));

    services.AddScoped<IConcertService, ConcertService>();
    services.AddScoped<IPaymentHandler, CashPaymentHandler>();
    services.AddScoped<CashPaymentHandler>();

    services.AddScoped<IReservationService, ReservationService>();
    services.AddScoped<IReservationRespository, ReservationRepository>();

    services.AddScoped<Func<PaymentType, IPaymentHandler>>(provider => (t) =>
    {

        switch (t)
        {

            case PaymentType.Cash:

                return provider.GetService<CashPaymentHandler>();

            default: throw new InvalidOperationException($"Payment type {t} not implemented");
        }
    });
}