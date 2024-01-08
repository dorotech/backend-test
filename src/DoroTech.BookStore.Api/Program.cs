var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

builder.Host.UseSerilog((hostContext, services, configuration) =>
{
    configuration.WriteTo.Console();
});

builder
    .Services
    .AddPresentation()
    .AddApplication()
    .AddInfrastructure(configuration);

var app = builder.Build();

if (!app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI(config => config.SwaggerEndpoint("/swagger/v1/swagger.json", "DoroTech.BookStore Api"));
}

try
{
    await using var serviceScope = app.Services.CreateAsyncScope();
    await using var dbContext = serviceScope.ServiceProvider.GetRequiredService<BookStoreContext>();
    await dbContext.Database.EnsureDeletedAsync();
    await dbContext.Database.MigrateAsync();

    await using var seedService = serviceScope.ServiceProvider.GetRequiredService<SeedGenerationService>();
    await seedService.InsertInitialData();
}
catch (Exception ex)
{
    Log.Error(ex.Message);
}

app.UseMiddleware<LoggingPipelineMiddleware>();

app.UseAuthentication();
app.UseAuthorization();
app.UseHttpsRedirection();
app.MapControllers();

app.Run();