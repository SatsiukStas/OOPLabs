using kursach.Models;
using kursach.ViewModels;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace kursach.Views;

public partial class MainMenu : ContentPage
{
    private MainMenuViewModel viewModel;
	public MainMenu(MainMenuViewModel viewModel)
	{
		InitializeComponent();
        this.viewModel = viewModel;
        BindingContext = viewModel;
        

    }

    protected override async void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);
        await Task.Delay(250);
        await viewModel.GetVacanciesAsync();

    }

    private async void TapGestureRecognizer_OnTapped(object sender, EventArgs e)
    {
        //var vacancy = ((VisualElement)sender).BindingContext as Vacancy;
        //if (vacancy != null)
        //{
        //    await Shell.Current.GoToAsync(nameof(DetailTourView), true, new Dictionary<string, object>
        //    {
        //        { "vacancy", vacancy }
        //    });
        //}
    }
}