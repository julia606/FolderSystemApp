using BusinessLogic.Repositories;
using DataAccess.EF;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
var connection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<FoldersContext>(options => options.UseSqlServer(connection));
builder.Services.AddScoped<FolderRepository>();

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
       name: "folderRoute",
       pattern: "{*folderPath}",
       defaults: new { controller = "Folder", action = "Index" });

    endpoints.MapControllerRoute(
       name: "default",
       pattern: "{controller=Home}/{action=Index}/{id?}");
});
app.Run();
