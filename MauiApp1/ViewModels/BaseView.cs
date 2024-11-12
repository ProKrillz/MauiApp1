using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiApp1.ViewModels;

public partial class BaseView : ObservableObject
{
    [ObservableProperty]
    string? title;

    [ObservableProperty]
    bool isBusy = false;

    [ObservableProperty]
    bool isRefreashing = false;
}
