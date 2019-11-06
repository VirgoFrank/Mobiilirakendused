using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using StarwarsApp.Core;

namespace StarwarsApp
{
    [Activity(Label = "StarshipsActivity")]
    public class StarshipsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            var searchfield = FindViewById<EditText>(Resource.Id.searchEditText);
            var searchButton = FindViewById<Button>(Resource.Id.searchButton);
            var peopleListView = FindViewById<ListView>(Resource.Id.peopleListView);

            searchButton.Click += async delegate
            {
                var searchText = searchfield.Text;
                var queryString = "https://swapi.co/api/starships/?search=" + searchText;
                var data = await DataService.GetStarWarsStarships(queryString);
                peopleListView.Adapter = new Starship_Adapter(this, data.Results);

            };
        }
    }
}