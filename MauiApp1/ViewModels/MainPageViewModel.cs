using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Model;
using MauiApp1.Service;
using MauiApp1.Views;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace MauiApp1.ViewModels;

public partial class MainPageViewModel : BaseView
{
    private readonly ITodoService _todoService;

    public MainPageViewModel(ITodoService service)
    {
        _todoService = service;
    }
    public ObservableCollection<TodoItem> Todos { get; set; } = new();

    [RelayCommand]
    public async Task GoToAddTodoPage()
    {
        await Shell.Current.GoToAsync($"{nameof(AddTodoPage)}?mode=newTodo", true, new Dictionary<string, object>
        {
            { "myTodo", new TodoItem() { Id = Guid.NewGuid(), Completed = false, CreatedTime = DateTime.Now } }
        });
    }
    [RelayCommand]
    public async Task GoToEditTodoPage() // lave imorgen
    {
        await Shell.Current.GoToAsync($"{nameof(AddTodoPage)}", true, new Dictionary<string, object>
        {
            { "myTodo", new TodoItem() { Id = Guid.NewGuid(), Completed = false, CreatedTime = DateTime.Now } }
        });
    }
    [RelayCommand]
    public async Task GetTodos()
    {
        if (IsBusy)
            return;
        try
        {
            IsBusy = true;
            ObservableCollection<TodoItem> list = _todoService.GetTodos();
            Todos.Clear();

            foreach (TodoItem item in list)  
                Todos.Add(item);
           
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get monkeys: {ex.Message}");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally 
        { 
            IsBusy = false; 
        }

    }

}
