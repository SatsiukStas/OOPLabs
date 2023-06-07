using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using kursach.Services;
using kursach.Views;
using kursach.Models;
using kursach.Services;

namespace kursach.ViewModels
{
    public partial class CreateVacancyViewModel : BaseViewModel
    {
        [ObservableProperty]
        private string vacancyName;

        [ObservableProperty]
        private string vacancySalary;

        [ObservableProperty]
        private string vacancyDescription;

        private DatabaseService databaseService;

        public CreateVacancyViewModel(DatabaseService databaseService)
        {
            this.databaseService = databaseService;
        }

        [RelayCommand]
        private async  void CreateVacancy()
        {
            var newVacancy = new Vacancy(VacancyName, VacancyDescription, VacancySalary);
            App.User.AddVacancy(newVacancy);

            await App.firebase.AddVacancyAsync(newVacancy);
            await databaseService.UpdateUserAsync(App.User);
            await Shell.Current.GoToAsync($"//{nameof(BasketView)}", true);
            await App.Current.MainPage.DisplayAlert("Alert", "You have successfully created a vacancy", "OK");
        }

    }
}

