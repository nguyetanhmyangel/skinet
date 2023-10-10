using Api.Extensions;
using Api.Middleware;
using Infrastructure.Contexts;
using Infrastructure.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddApplicationServices(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
app.UseMiddleware<ExceptionMiddleware>();
// UseStatusCodePagesWithRedirects middleware component intercepts the status code and as the name implies, 
// issues a redirect to the provided error path
app.UseStatusCodePagesWithReExecute("/errors/{0}");

app.UseSwagger();
app.UseSwaggerUI();

// Thêm StaticFileMiddleware - nếu Request là yêu cầu truy cập file tĩnh,
// Nó trả ngay về Response nội dung file và là điểm cuối pipeline, nếu  khác
// nó gọi  Middleware phía sau trong Pipeline
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
        Path.Combine(Directory.GetCurrentDirectory(), "Content")),
    RequestPath = "/Content"
});

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

// seed Db
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var context = services.GetRequiredService<StoreDbContext>();
// var identityContext = services.GetRequiredService<AppIdentityDbContext>();
// var userManager = services.GetRequiredService<UserManager<AppUser>>();
var logger = services.GetRequiredService<ILogger<Program>>();
try
{
    await context.Database.MigrateAsync();
    // await identityContext.Database.MigrateAsync();
    await SeedData.SeedAsync(context);
    // await AppIdentityDbContextSeed.SeedUsersAsync(userManager);
}
catch (Exception ex)
{
    logger.LogError(ex, "An error occured during migration");
}


app.Run();
