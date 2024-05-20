using ETLProjectAPI.Infrastructure.Database;
using ETLProjectAPI.Services.Interfaces;
using ETLProjectAPI.Services.Realisation;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;


builder.Services.AddControllers();
builder.Services.AddSingleton<DataContext>(sp => new DataContext(builder.Configuration.GetValue<string>("ProcessingConnectionString")));
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "ETL Project API", Version = "v1" });
});
builder.Services.AddScoped<IImportService, ImportService>();
builder.Services.AddScoped<IQueryService, QueryService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "ETL Project API v1");
    });
}

app.UseRouting();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
