using PictureApp.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PictureApp.ViewModels
{
   public class LoginViewModel
    {
      public  LoginViewModel()
        {
            RegisterCommand = new Command(Register);
            LoginCommand = new Command(Login);
            GoToRegister = new Command(GoRegister);
            Password = "test";
            Username = "test";
        }

        public ICommand RegisterCommand { get; set; }
        public ICommand LoginCommand { get; set; }
        public ICommand GoToRegister { get; set; }
        public string Password { get; set; }
        public string Username { get; set; }

        public async void Register()
        {
            if (String.IsNullOrWhiteSpace(Password) || String.IsNullOrWhiteSpace(Username))
            {
                await Application.Current.MainPage.DisplayAlert("Invalid input", "Password or usernamer is empty","ok");
              
            }
            else
            {
                var account = new Account() { Password = Password, Username = Username };
                await App.Database.SaveAccountsAsync(account);
                await Application.Current.MainPage.Navigation.PopModalAsync();
            }

        }
        public async void Login()
        {
            var accounts = await App.Database.GetAccountsAsync();

            foreach (var account in accounts)
            {
                if (account.Password == Password && account.Username == Username)
                {
                    Application.Current.Properties["user_id"] = account.Id;
                    await Application.Current.SavePropertiesAsync();
                    await Application.Current.MainPage.Navigation.PushAsync(new FirstTabbedPage());
                    return;
                }

            }
            await Application.Current.MainPage.DisplayAlert("Invalid input", "No such account", "ok");

        }
        public async void GoRegister()
        {
            await Application.Current.MainPage.Navigation.PushModalAsync(new RegisterPage());
        }

    }
}
