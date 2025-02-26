using Alterdata.TesteFullStackBackend.Api.Configurations;
using Alterdata.TesteFullStackBackend.Data.Context;
using Asp.Versioning.ApiExplorer;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApiConfig();
builder.Services.AddSwaggerGen();
builder.Services.ResolveDependencies();
builder.Services.AddDbContext<DbMemoryContext>(options =>
    options.UseInMemoryDatabase("MemoryDB"));

var app = builder.Build();

var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();

app.UseApiConfig(
    app.Environment,
    apiVersionDescriptionProvider);

app.MapControllers();

var scope = app.Services.CreateScope();
var context = scope.ServiceProvider.GetRequiredService<DbMemoryContext>();
DatabaseSeeder.Seed(context);


app.Run();
