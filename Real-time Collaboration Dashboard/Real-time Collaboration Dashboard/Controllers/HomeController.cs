using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Real_time_Collaboration_Dashboard.Data;
using Real_time_Collaboration_Dashboard.Hubs;
using Real_time_Collaboration_Dashboard.Models;
using System.Diagnostics;

namespace Real_time_Collaboration_Dashboard.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        private readonly AppDbContext _context;

        // ❌ LỖI CŨ: private readonly IHubContext _hubContext;
        // 🟢 SỬA THÀNH:
        private readonly IHubContext<TaskHub> _hubContext;

        // ❌ LỖI CŨ: public HomeController(AppDbContext context, IHubContext hubContext)
        // 🟢 SỬA THÀNH:
        public HomeController(AppDbContext context, IHubContext<TaskHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        public async Task<ViewResult> Index()
        {
            var tasks = await _context.Tasks.ToListAsync();
            return View(tasks);
        }

        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] TaskItem task)
        {
            _context.Tasks.Add(task);
            await _context.SaveChangesAsync();

            // Phát sự kiện real-time cho tất cả các client
            await _hubContext.Clients.All.SendAsync("ReceiveTaskUpdate", "created", task);
            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateStatus([FromBody] TaskItem task)
        {
            var existingTask = await _context.Tasks.FindAsync(task.Id);
            if (existingTask == null) return NotFound();

            existingTask.Status = task.Status;
            await _context.SaveChangesAsync();

            // Phát sự kiện real-time cho tất cả các client
            await _hubContext.Clients.All.SendAsync("ReceiveTaskUpdate", "updated", existingTask);
            return Ok(existingTask);
        }
    }
}
