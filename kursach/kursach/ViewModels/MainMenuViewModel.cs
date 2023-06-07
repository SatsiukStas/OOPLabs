using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using kursach.Models;
using kursach.Services;
using kursach.Views;

namespace kursach.ViewModels
{
    public partial class MainMenuViewModel : BaseViewModel
    {
        public ObservableCollection<Vacancy> Vacancies { get; } = new();

        [ObservableProperty]
        private Vacancy selectedVacancy;

        [ObservableProperty] public bool editBtnIsVisible = false;

        private DatabaseService vacancyService;


        public MainMenuViewModel(DatabaseService vacancyService)
        {
            this.vacancyService = vacancyService;
            
            if (App.User.Email.Equals("admin@admin.com"))
            {
                EditBtnIsVisible = true;
            }
            else
            {
                EditBtnIsVisible = false;
            }
        }

        public async Task GetVacanciesAsync()
        {
            try
            {
                if (IsBusy)
                    return;

                IsBusy = true;

                if (App.User.Email.Equals("admin@admin.com"))
                {
                    EditBtnIsVisible = true;
                }
                else
                    EditBtnIsVisible = false;

                var vacancies = await vacancyService.GetVacanciesAsync();

                if (Vacancies.Count != 0)
                    Vacancies.Clear();

                if(vacancies == null)
                    return;

                foreach (var vacancy in vacancies)
                    Vacancies.Add(vacancy);
            }
            catch (Exception ex)
            {
                await App.Current.MainPage.DisplayAlert("Alert", ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        [RelayCommand]  
        private async void EditVacanciesClicked()
        {
            await Shell.Current.GoToAsync(nameof(EditToursView), true);
        }

    }
}
