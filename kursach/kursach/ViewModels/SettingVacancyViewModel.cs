using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.Input;
using kursach.Models;
using kursach.Services;

namespace kursach.ViewModels
{
    [QueryProperty(nameof(Vacancy), "Vacancy")]
    public partial class SettingTourViewModel : BaseViewModel
    {
        [ObservableProperty] private Vacancy vacancy;

        [ObservableProperty] private string name;

        [ObservableProperty] private string description;

        [ObservableProperty] private string salary;

        [ObservableProperty] private string picture;

        private DatabaseService databaseService;

        public SettingTourViewModel(DatabaseService databaseService)
        {
            this.databaseService = databaseService;
        }

        [RelayCommand]
        private async void Confirm()
        {
            IsBusy = true;
            try
            {
                if (Name != string.Empty || Salary != string.Empty || Description != string.Empty)
                {
                    if (Vacancy != null)
                    {
                        await ChangeVacancy(Vacancy, Name, Description, Salary);
                    }
                    else
                    {
                        await AddVacancy(new Models.Vacancy(Name, Salary, Description));
                    }
                }
            }
            catch (Exception e)
            {

                await App.Current.MainPage.DisplayAlert("Alert", e.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task AddVacancy(Vacancy vacancyForAdding)
        {
            await databaseService.AddVacancyAsync(vacancyForAdding);
        }

        private async Task ChangeVacancy(Vacancy vacancyForChanging, string name, string description, string salary)
        {
            vacancyForChanging.Name = name;
            vacancyForChanging.Description = description;
            vacancyForChanging.Salary = salary;
            await databaseService.RemoveVacancyAsync(vacancyForChanging);
            await databaseService.AddVacancyAsync(vacancyForChanging);
        }
    }
}
