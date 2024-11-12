

using MauiApp1.Model;
using System.Collections.ObjectModel;

namespace MauiApp1.Service;

public class TodoService : ITodoService
{
    public TodoService()
    {
        LoadTodo();
    }
    private ObservableCollection<TodoItem> _todos;

    public ObservableCollection<TodoItem> GetTodos() => _todos;
    
    public void SaveTodo(TodoItem item) 
    { 
        TodoItem? existingItem = _todos.FirstOrDefault(x => x.Id == item.Id);
        
        if (existingItem is null) 
            _todos.Add(item);

        else    
            _todos[_todos.IndexOf(existingItem)] = item;
        
    }
    private void LoadTodo()
    {
        _todos = new ObservableCollection<TodoItem>() { new TodoItem { Id = Guid.NewGuid(), Description = "test", Priority = PriorityLevel.Low } };
    }
}