using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using TaskMaster.Studio.Models;
using TaskMaster.Studio.Services;

namespace TaskMaster.Studio.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly ITaskService _taskService;

    public ObservableCollection<TaskItem> Tasks { get; }

    [ObservableProperty]
    private string _newTaskTitle = string.Empty;

    [ObservableProperty]
    private string _newTaskPriority = "Normal";

    [ObservableProperty]
    private TaskItem? _selectedTask;

    public MainViewModel(ITaskService taskService)
    {
        _taskService = taskService;
        Tasks = _taskService.GetAllTasks();
    }

    [RelayCommand]
    private void CreateTask()
    {
        if (string.IsNullOrWhiteSpace(NewTaskTitle)) return;

        var task = new TaskItem
        {
            Title = NewTaskTitle,
            Priority = NewTaskPriority,
            Status = "To-Do"
        };

        _taskService.AddTask(task);
        NewTaskTitle = string.Empty;
    }

    [RelayCommand]
    private void DeleteTask(TaskItem? task)
    {
        var target = task ?? SelectedTask;
        if (target != null)
        {
            _taskService.RemoveTask(target.Id);
        }
    }
}
