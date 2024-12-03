using Solution.Finance.Application.UseCases;
using Solution.Finance.Persistence;
using Solution.Finance.Service.Endpoints;

var builder = WebApplication.CreateBuilder(args);

#region inicio del area de servicios
builder.Services.AddPersistence(builder.Configuration);
builder.Services.AddApplicationServices();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#endregion

var app = builder.Build();

#region inicio del area de middlewares

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/", () => "Hello World!");
app.MapGroup("/usuarios").MapUsuarios();

#endregion

app.Run();
