namespace Real_time_Collaboration_Dashboard.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Status { get; set; } = "Todo"; // Todo, InProgress, Done
    }
}
