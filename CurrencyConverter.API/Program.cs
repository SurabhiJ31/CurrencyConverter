using CurrencyConverter.API.Frankfurter;
using CurrencyConverter.API.Middleware;
using Microsoft.AspNetCore.Mvc.Versioning;
using System.Threading.RateLimiting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//versioning
builder.Services.AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
    options.ApiVersionReader = new UrlSegmentApiVersionReader();
});


var httpClientBuilder = builder.Services.AddHttpClient<IBaseApiClient, FrankfurterApiClient>(client =>
{
    client.BaseAddress = new Uri(builder.Configuration.GetConnectionString("FrankfurterApi"));
});

var rateLimiter = new FixedWindowRateLimiter(
    new FixedWindowRateLimiterOptions
    {
        PermitLimit = 50,
        Window = TimeSpan.FromSeconds(1),
        QueueLimit = 0,
    }
);

//by default there will be 3 retries with exponential backoff
httpClientBuilder.AddStandardResilienceHandler(options =>
{
    options.RateLimiter = new Microsoft.Extensions.Http.Resilience.HttpRateLimiterStrategyOptions
    {
        RateLimiter = args => rateLimiter.AcquireAsync(cancellationToken: args.Context.CancellationToken)

    };
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlerMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

