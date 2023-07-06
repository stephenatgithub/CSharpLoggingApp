var builder = WebApplication.CreateBuilder(args);


// The following code overrides the default set of logging providers added by WebApplication.CreateBuilder

//builder.Logging.ClearProviders();
//builder.Logging.AddConsole();

builder.Logging
    .ClearProviders()
    .AddConfiguration(builder.Configuration.GetSection("Logging"))
    .AddDebug()
    .AddConsole();


// Add services to the container.
builder.Services.AddRazorPages();

var app = builder.Build();


// use logger in main program
//var logger = app.Services.GetRequiredService<ILogger<Program>>();
//logger.LogCritical("This application is started");




// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
