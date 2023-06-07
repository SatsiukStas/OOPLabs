using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using kursach.Models;
using kursach.Services;
using kursach.Views;

namespace kursach.ViewModels
{
    public partial class EditToursViewModel : BaseViewModel
    {
        [ObservableProperty] 
        public ObservableCollection<Vacancy> vacancies;

        [ObservableProperty]
        private Vacancy vacancy;

        private DatabaseService databaseService;

        public EditToursViewModel(DatabaseService databaseService)
        {
            this.databaseService = databaseService;
            Vacancies = new ObservableCollection<Vacancy>();
        }
        public async Task GetVacanciesAsync()
        {
            try
            {
                if (IsBusy)
                    return;

                IsBusy = true;

                var vacancies = await databaseService.GetVacanciesAsync();

                if (Vacancies.Count != 0)
                    Vacancies.Clear();

                if (vacancies == null)
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
        private async void DeleteVacancy(Vacancy vacancy)
        {
            IsBusy = true;
            Vacancies.Remove(vacancy);
            await databaseService.RemoveVacancyAsync(vacancy);
            if (App.User.ListOfVacancies.Contains(vacancy.Id))
            {
                App.User.ListOfVacancies.Remove(vacancy.Id);
                await databaseService.AddUserAsync(App.User);
            }

            IsBusy = false;
        }
        [RelayCommand]
        private async void EditVacancy(Vacancy vacancy)
        {
            await Shell.Current.GoToAsync(nameof(SettingTourView), true, new Dictionary<string, object>
            {
                { "Vacancy", vacancy }
            });
        }
        
    }
}
