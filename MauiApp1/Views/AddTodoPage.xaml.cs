using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class AddTodoPage : ContentPage
{
	public AddTodoPage(AddEditTodoViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}