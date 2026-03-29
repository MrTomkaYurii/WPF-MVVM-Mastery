using FluentAssertions;
using TaskMaster.Studio.Models;
using TaskMaster.Studio.Services;
using TaskMaster.Studio.ViewModels;
using Xunit;

namespace TaskMaster.Studio.Tests;

public class MainViewModelTests
{
    [Fact]
    public void CreateTaskCommand_WhenTitleIsValid_ShouldAddTaskToService()
    {
        // Arrange
        var service = new InMemoryTaskService();
        var initialCount = service.GetAllTasks().Count;
        var vm = new MainViewModel(service)
        {
            NewTaskTitle = "Write Unit Tests for WPF",
            NewTaskPriority = "Urgent"
        };

        // Act
        vm.CreateTaskCommand.Execute(null);

        // Assert
        service.GetAllTasks().Count.Should().Be(initialCount + 1);
        vm.NewTaskTitle.Should().BeEmpty();
    }

    [Fact]
    public void DeleteTaskCommand_WhenTargetProvided_ShouldRemoveTask()
    {
        // Arrange
        var service = new InMemoryTaskService();
        var vm = new MainViewModel(service);
        var target = vm.Tasks.First();
        var initialCount = vm.Tasks.Count;

        // Act
        vm.DeleteTaskCommand.Execute(target);

        // Assert
        vm.Tasks.Count.Should().Be(initialCount - 1);
        vm.Tasks.Should().NotContain(target);
    }
}
