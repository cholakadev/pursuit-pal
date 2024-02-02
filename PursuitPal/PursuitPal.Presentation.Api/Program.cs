using PursuitPal.Presentation.Api.Extensions;
using PursuitPal.Presentation.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCustomSwagger();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddPursuitPalApIVersioning();
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddRepositoriesConfiguration();
builder.Services.AddServicesConfiguration();
builder.Services.AddValidatorsConfiguration();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
