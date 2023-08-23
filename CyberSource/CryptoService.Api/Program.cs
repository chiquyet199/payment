using CryptoService.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();
builder.Services
    .AddGraphQLServer()
    .AddQueryType<Query>();

var app = builder.Build();

app.UseCors(app => app.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
app.MapGraphQL();

app.Run();

