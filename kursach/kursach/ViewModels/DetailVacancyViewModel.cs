using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using kursach.Models;
using kursach.Services;

namespace kursach.ViewModels
{
    [QueryProperty(nameof(Vacancy), "Vacancy")]
    public partial class DetailTourViewModel : BaseViewModel
    {
        [ObservableProperty]
        private Vacancy vacancy;

        private DatabaseService databaseService;

        public DetailTourViewModel(DatabaseService databaseService)
        {
            this.databaseService = databaseService;
            
        }

        [RelayCommand]
        private void VacancyToBasket()
        {
            foreach (var vacancy in App.User.ListOfVacancies)
            {
                if (vacancy == this.Vacancy.Id)
                {
                    
                    return;
                }
            }
            //App.User.ListOfVacancies.Add(this.Vacancy.Id);
            //this.databaseService.AddUserAsync(App.User);
            //await App.Current.MainPage.DisplayAlert("Success!", "Vacancy added to your basket.", "OK");
        }
    }
}
