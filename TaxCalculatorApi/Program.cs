using Microsoft.EntityFrameworkCore;
using TaxCalculatorApi.Config;
using TaxCalculatorApi.DAL;
using TaxCalculatorApi.DAL.Interfaces;
using TaxCalculatorApi.Domain;
using TaxCalculatorApi.ExceptionHandlers;
using TaxCalculatorApi.Repository;
using TaxCalculatorApi.Repository.Interfaces;
using TaxCalculatorApi.Services;
using TaxCalculatorApi.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<TaxDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("TaxDbConnection")));

builder.Services.AddMemoryCache();

builder.Services.AddScoped<ITaxDbContext, TaxDbContext>();
builder.Services.AddScoped<ITaxBandRepository, TaxBandRepository>();
builder.Services.AddScoped<ICacheProvider, CacheProvider>();

builder.Services.Configure<TaxBandCacheSettings>(
    builder.Configuration.GetSection(nameof(TaxBandCacheSettings)));

builder.Services.AddScoped<ITaxBandCacheRepository, TaxBandCacheRepository>();
builder.Services.AddTransient<ITaxCalculator, TaxCalculator>();
builder.Services.AddTransient<ITaxService, TaxService>();
builder.Services.AddTransient<IPayrollService, PayrollService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddExceptionHandler<InvalidAnnualSalaryExceptionHandler>();
builder.Services.AddExceptionHandler<AppExceptionHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionHandler( _ => { });

app.UseAuthorization();

app.MapControllers();

app.Run();
