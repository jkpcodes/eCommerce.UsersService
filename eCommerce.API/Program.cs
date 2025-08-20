using eCommerce.Infrastructure;
using eCommerce.Core;
using eCommerce.API.Middlewares;
using System.Text.Json.Serialization;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add Infrastructure and Core services to the container
builder.Services.AddInfrastructure();
builder.Services.AddCore();

// Add controllers to the service collection
builder.Services.AddControllers()
    .AddJsonOptions(options => {
        // Enable JSON serialization of enums as strings
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

// Add auto FluentValidation
builder.Services.AddFluentValidationAutoValidation();

// Build the web application
var app = builder.Build();

// Add exception handling middleware
app.UseExceptionHandlingMiddleware();

// Enable routing
app.UseRouting();

// Enable authentication and authorization
app.UseAuthentication();
app.UseAuthorization();

// Controller routes
app.MapControllers();

app.Run();
