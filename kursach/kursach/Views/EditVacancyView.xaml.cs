using kursach.Models;
using kursach.ViewModels;

namespace kursach.Views;

public partial class EditToursView : ContentPage
{
    private EditToursViewModel viewModel;
    public EditToursView(EditToursViewModel editToursViewModel)
    {
        InitializeComponent();
        this.viewModel = editToursViewModel;
        BindingContext = viewModel;
    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        await viewModel.GetVacanciesAsync();

    }
}
