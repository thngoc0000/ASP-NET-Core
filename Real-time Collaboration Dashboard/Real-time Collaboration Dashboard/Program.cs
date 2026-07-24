using Microsoft.EntityFrameworkCore;
using Real_time_Collaboration_Dashboard.Data;
using Real_time_Collaboration_Dashboard.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSignalR(); // Đăng ký SignalR
builder.Services.AddDbContext<AppDbContext>(opt => opt.UseInMemoryDatabase("TaskBoardDb"));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();

app.MapHub<TaskHub>("/taskHub"); // Định tuyến endpoint cho SignalR Hub

app.Run();
