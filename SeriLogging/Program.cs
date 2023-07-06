using Microsoft.Extensions.Logging.Configuration;
using Serilog;

// config Serilog in appsettings.json
var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

// create logger
Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(config)
    .CreateLogger();

Log.Information("Serilog application is started");
Log.Error("This is error");





var builder = WebApplication.CreateBuilder(args);

// redirect all log events through your Serilog pipeline
builder.Host.UseSerilog();


// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();

// exclude noisy handlers from logging, such as UseStaticFiles(), by placing UseSerilogRequestLogging() after them
app.UseSerilogRequestLogging();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
