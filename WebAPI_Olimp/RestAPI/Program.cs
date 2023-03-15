using Application;
using Application.Mappings;
using Application.Interfaces;
using Database;
using Database.DbContextes;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplication();
builder.Services.AddControllers();
builder.Services.AddDatabase(builder.Configuration);
builder.Services.AddAutoMapper(config =>
{
    config.AddProfile(new AssemblyMappingProfile(typeof(Program).Assembly));
    config.AddProfile(new AssemblyMappingProfile(typeof(IMainDbContext).Assembly));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyHeader();
        policy.AllowAnyMethod();
        policy.AllowAnyOrigin();
    });
});



var app = builder.Build();
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

using (var scope = builder.Services.BuildServiceProvider().CreateScope())
{
    try
    {
        var context = scope.ServiceProvider.GetRequiredService<MainDbContext>();
        DbInitializer.Initialize(context);
    }
    catch (Exception)
    {

    }
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.UseCors("AllowAll");
app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();
