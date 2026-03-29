using System.Collections.ObjectModel;
using TaskMaster.Studio.Models;

namespace TaskMaster.Studio.Services;

public interface ITaskService
{
    ObservableCollection<TaskItem> GetAllTasks();
    void AddTask(TaskItem task);
    void RemoveTask(Guid id);
}

public class InMemoryTaskService : ITaskService
{
    private readonly ObservableCollection<TaskItem> _tasks = new()
    {
        new() { Title = "Implement JWT Refresh Tokens in Web API", Priority = "High", Status = "In Progress" },
        new() { Title = "Configure RabbitMQ Topic Exchanges in MassTransit", Priority = "Urgent", Status = "To-Do" },
        new() { Title = "Design Material Design Styles in WPF", Priority = "Normal", Status = "Done" }
    };

    public ObservableCollection<TaskItem> GetAllTasks() => _tasks;
    public void AddTask(TaskItem task) => _tasks.Add(task);
    public void RemoveTask(Guid id)
    {
        var item = _tasks.FirstOrDefault(t => t.Id == id);
        if (item != null) _tasks.Remove(item);
    }
}
