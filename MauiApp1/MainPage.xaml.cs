using MauiApp1.ViewModels;

namespace MauiApp1
{
    public partial class MainPage : ContentPage
    {
        MainPageViewModel vm;
        public MainPage(MainPageViewModel viewModel)
        {
            InitializeComponent();
            vm = viewModel;
            BindingContext = viewModel;
        }
        protected override void OnAppearing()
        {
            vm.GetTodosCommand.Execute(null);
        }


    }

}
