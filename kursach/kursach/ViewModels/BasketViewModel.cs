using System.Collections.ObjectModel;
using System.Diagnostics.Metrics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using kursach.Models;
using kursach.Services;
using kursach.Views;

namespace kursach.ViewModels
{
    public partial class BasketViewModel : BaseViewModel
    {
        public ObservableCollection<Vacancy> Vacancies { get; } = new();

        //[ObservableProperty]
        //public ObservableCollection<string> vacancies;

        //[ObservableProperty] 
        //public string cost;

        [ObservableProperty]
        public string balance;

        private DatabaseService databaseService;

        public BasketViewModel(DatabaseService databaseService)
        {
            this.databaseService = databaseService;
            //Cost = "0$";
            //Balance = "0$";
            //Vacancies = new ObservableCollection<string>();

            //foreach (var item in App.User.ListOfVacancies)
            //{
            //    vacancies.Add(item);
            //}
        }

        public async Task GetVacanciesAsync()
        {
            
            try
            {
                if (IsBusy)
                    return;

                IsBusy = true;

                if (Vacancies.Count != 0)
                    Vacancies.Clear();

                
                foreach (var vacancy in App.User.ListOfVacancies)
                {
                    
                    Vacancies.Add(await this.databaseService.GetVacancyAsync(vacancy));
                }
                

                if (Vacancies == null)
                    return;

                Balance = App.User.Balance.ToString() + '$';

                double _cost = 0;

                //foreach (var tour in Vacancies)
                //{
                //    _cost += Convert.ToDouble(tour.Price.Remove(tour.Price.Length - 1, 1));
                //}
                //Cost = _cost.ToString() + '$';
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
        private async void DeleteVacancy(Vacancy obj)
        {
            IsBusy = true;
            Vacancies.Remove(obj);
            App.User.ListOfVacancies.Remove(obj.Id);
            await databaseService.RemoveVacancyAsync(obj);
            await databaseService.AddUserAsync(App.User);
            IsBusy = false;
        }

        [RelayCommand]
        private async void Buy()
        {
            

            await Shell.Current.GoToAsync($"//{nameof(CreateVacancyView)}", true);
        }
    }
}
