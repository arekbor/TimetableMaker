using TimetableMakerApi;
using TimetableMakerApi.Apis;
using TimetableMakerDataAccess.Contracts;
using TimetableMakerDataAccess.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IModeRepository, ModeRepository>();
builder.Services.AddSingleton<ILocationRepository, LocationRepository>();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseModesApi();
app.UseLocationsApi();

app.Run();
