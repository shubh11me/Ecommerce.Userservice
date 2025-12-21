using eCommerce.Core;
using eCommerce.Core.Mappers;
using eCommerce.Infrastructure;
using Ecommerce.Userservice.Middlewares;
using System.Text.Json.Serialization;
using FluentValidation;
using eCommerce.Core.Validators;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure();
builder.Services.AddCore();
builder.Services.AddControllers().AddJsonOptions(opt => opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));
builder.Services.AddAutoMapper(typeof(ApplicationUserMappingProfile).Assembly);
builder.Services.AddValidatorsFromAssemblyContaining<LoginRequestValidators>();
var app = builder.Build();
app.UseExceptionHandlingMiddleware();


app.UseRouting();
app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => "Hello World!");

app.Run();
