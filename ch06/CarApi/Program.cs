using CarApi.Data;
using CarApi.Repositories;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Runtime;



var builder = WebApplication.CreateBuilder(args);



// Add services to the container. 

builder.Services.AddControllers();



// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle 

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ToDo API",
        Description = "An ASP.NET Core Web API for managing ToDo items",
        TermsOfService = new Uri("https://example.com/terms"),
        Contact = new OpenApiContact
        {
            Name = "Example Contact",
            Url = new Uri("https://example.com/contact")
        },
        License = new OpenApiLicense
        {
            Name = "Example License",
            Url = new Uri("https://example.com/license")
        }
    });

    var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
});



// Load DB configuration and register the connection factory for injection 

var configuration = builder.Configuration;

builder.Services.Configure<DbSettings>(configuration.GetSection("ConnectionStrings"));

//builder.Services.AddTransient<DatabaseConnectionFactory>();

builder.Services.AddTransient<CarRepository>();

//builder.Services.RegisterDataAccessDependencies();



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



app.Run();