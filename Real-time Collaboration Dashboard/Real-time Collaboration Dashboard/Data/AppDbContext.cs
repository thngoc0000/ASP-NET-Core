using Microsoft.EntityFrameworkCore;
using Real_time_Collaboration_Dashboard.Models;

namespace Real_time_Collaboration_Dashboard.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Thêm kiểu <TaskItem> vào DbSet và Set()
        public DbSet<TaskItem> Tasks => Set<TaskItem>();
    }
}