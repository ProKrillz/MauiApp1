using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Model;
using MauiApp1.Service;

namespace MauiApp1.ViewModels;

[QueryProperty(nameof(Mode), "mode")]
[QueryProperty(nameof(Todo), "myTodo")]
public partial class AddEditTodoViewModel : BaseView
{
    readonly ITodoService _todoService;

    public AddEditTodoViewModel(ITodoService service)
    {
        _todoService = service;
    }
    public string Mode { get; set; }

    private TodoItem _todo;
    public TodoItem Todo { 
        get => _todo; 
        set { 
            SetProperty(ref _todo, value);
            Title = Mode == "newTodo" ? "Add Todo" : "Edit Todo";
        }
    }

    [ObservableProperty]
    private PriorityLevel selectedPriority;

    public List<string> PriorityNames { get => Enum.GetNames(typeof(PriorityLevel)).ToList(); }

    [RelayCommand]
    public async Task SaveTodo()
    {
        if (IsValid()) 
        {
            _todoService.SaveTodo(Todo);
            await Shell.Current.GoToAsync("//MainPage");
        }
        
    }

    private bool IsValid()
    {
        if (Todo is null || String.IsNullOrEmpty(Todo.Description)) 
            return false;
        
        return true;
    }
    [RelayCommand]
    public async Task CancelSave()
    {
        await Shell.Current.GoToAsync("..");
    }


}
