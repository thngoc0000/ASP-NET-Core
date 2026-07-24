using Microsoft.AspNetCore.SignalR;
using Real_time_Collaboration_Dashboard.Models;

namespace Real_time_Collaboration_Dashboard.Hubs
{
    public class TaskHub : Hub
    {
        // Hàm này sẽ được gọi khi có task mới được tạo hoặc cập nhật
        public async Task BroadcastTaskChange(string action, TaskItem task)
        {
            await Clients.All.SendAsync("ReceiveTaskUpdate", action, task);
        }
    }
}
