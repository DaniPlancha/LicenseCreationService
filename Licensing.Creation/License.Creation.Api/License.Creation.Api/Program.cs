using License.Creation.Api.Data;
using License.Creation.Api.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();

var databaseConnection = builder.Configuration.GetConnectionString("Default"); 

builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseMySql(databaseConnection, new MySqlServerVersion(new Version(8, 0, 22)));
});
builder.Services.AddTransient<ContractTypesService>();
builder.Services.AddTransient<LicenseProductsService>();
builder.Services.AddTransient<InstallationTypesService>();
builder.Services.AddTransient<LicenseCreationService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

