﻿using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using kursach.Services;
using kursach.Views;

namespace kursach.ViewModels
{
    public partial class LoginViewModel : BaseViewModel
    {
        DatabaseService databaseService;
        [RelayCommand]
        private async void Register(object obj)
        {
            await Shell.Current.GoToAsync($"//{nameof(RegisterPageView)}", true);
        }

        [RelayCommand]
        private async void Login(object obj)
        {
            try
            {
                IsBusy = true;
                var auth = await App.authProvider.SignInWithEmailAndPasswordAsync(UserEmail, UserPassword);
                App.Token = auth.FirebaseToken;
                App.User = await this.databaseService.GetUserAsync(auth.User.LocalId);
                await Shell.Current.GoToAsync($"//{nameof(MainMenu)}", true);
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

        [ObservableProperty]
        public string userEmail;

        [ObservableProperty]
        public string userPassword;
        public LoginViewModel(DatabaseService databaseService)
        {
            this.databaseService = databaseService;
            UserEmail = "admin@admin.com";
            UserPassword = "123456";
        }
    }
}