using Microsoft.EntityFrameworkCore;
using Business.Interfaces;
using Business.Services;
using Data.Contexts;
using Data.Interfaces;
using Data.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("EventSqlDatabase")));

builder.Services.AddScoped<IEventService, EventService>();
builder.Services.AddScoped<IEventRepository, EventRepository>();
builder.Services.AddScoped<IPackageRepository, PackageRepository>();

var app = builder.Build();

app.MapOpenApi();

app.UseSwagger();
app.UseSwaggerUI(x =>
{
    x.RoutePrefix = string.Empty;
    x.SwaggerEndpoint("/swagger/v1/swagger.json", "Event Service Api");
});

app.UseHttpsRedirection();
app.UseCors(x => x.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());

app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
