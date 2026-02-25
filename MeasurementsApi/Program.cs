using CopilotApi.Logic;
using OfficeOpenXml;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi

// Create an instance of EPPlusLicense to call the non-static method
// var license = new EPPlusLicense();
// license.SetNonCommercialPersonal("Piotr Augustyniak");


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowClient",
         policy => policy
             .WithOrigins("http://localhost:5173") // Vite default
             .AllowAnyHeader()
             .AllowAnyMethod());
});

//builder.Services.AddCors(options =>
//{
//    options.AddPolicy("AllowAll", builder => builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
//});

builder.Services.AddScoped<MeasurementExcelReader>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddControllers()
    .AddJsonOptions(o =>
    {
        o.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseCors("AllowClient");
//app.UseCors("AllowAll");

app.MapControllers();

app.UseHttpsRedirection();

app.Run();
