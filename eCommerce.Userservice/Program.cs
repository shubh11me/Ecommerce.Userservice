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

//Add api explorer
builder.Services.AddEndpointsApiExplorer();

//Add swagger generation
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});
var app = builder.Build();
app.UseExceptionHandlingMiddleware();


app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => "Hello World!");

app.Run();
