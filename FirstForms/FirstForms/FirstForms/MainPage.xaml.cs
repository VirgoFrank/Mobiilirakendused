using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace FirstForms
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        async void Login(object sender, EventArgs e)
        {
            var accounts = await App.Database.GetAccountsAsync();

            foreach (var account in accounts)
            {
                if(account.Password == Password.Text && account.Email == email.Text)
                    await Navigation.PushAsync(new NotesPage());
            }

        }

        async void Register(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RegisterPage());
        }
    }
}
