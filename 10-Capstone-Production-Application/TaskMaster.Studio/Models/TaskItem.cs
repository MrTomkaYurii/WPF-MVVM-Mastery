namespace TaskMaster.Studio.Models;

public class TaskItem
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Title { get; set; } = string.Empty;
    public string Priority { get; set; } = "Normal";
    public string Status { get; set; } = "To-Do";
    public DateTime DueDate { get; set; } = DateTime.Today.AddDays(3);
}
