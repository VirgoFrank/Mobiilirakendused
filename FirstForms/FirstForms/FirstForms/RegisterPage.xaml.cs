using FirstForms.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FirstForms
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            BindingContext = new Account();
        }
        async void Register(object sender, EventArgs e)
        {
            //var Account = new Account
            //{
            //    Email = "VirgoEmail",
            //    Last_name="frank",
            //    First_Name="virgo",
            //    Password="1234"

            //};
            var account = (Account)BindingContext;
            if(String.IsNullOrWhiteSpace(account.Password)|| String.IsNullOrWhiteSpace(account.Email))
            {

            }
            else
            {
                await App.Database.SaveAccountsAsync(account);
                await Navigation.PushAsync(new AccountsPage());
            }
           
        }
    }
}