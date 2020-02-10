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
    public partial class AccountsPage : ContentPage
    {
        public AccountsPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            AccountsListView.ItemsSource = await App.Database.GetAccountsAsync();
        }
    }
}