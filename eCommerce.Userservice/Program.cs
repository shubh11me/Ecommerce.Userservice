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
builder.Services.ConfigureHttpJsonOptions(op=>op.SerializerOptions.PropertyNameCaseInsensitive=true);

//Add api explorer
builder.Services.AddEndpointsApiExplorer();

//Add swagger generation
builder.Services.AddSwaggerGen();
//Add cors services
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder => {
        builder.WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader();
    });
});
var app = builder.Build();
app.UseExceptionHandlingMiddleware();


app.UseRouting();
app.UseSwagger();
app.UseSwaggerUI();
app.UseCors();
app.UseHttpsRedirection();
app.MapControllers();
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => "Hello World!");

app.Run();
