

using MauiApp1.Model;
using System.Collections.ObjectModel;

namespace MauiApp1.Service;

public interface ITodoService
{
    ObservableCollection<TodoItem> GetTodos();
    void SaveTodo(TodoItem item);

}
