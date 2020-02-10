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
        }
        async void Register(object sender, EventArgs e)
        {
            var Account = new Account
            {
                Email = "VirgoEmail",
                Last_name="frank",
                First_Name="virgo",
                Password="1234"
                
            };
            await App.Database.SaveAccountsAsync(Account);
            await Navigation.PushAsync(new AccountsPage());
        }
    }
}