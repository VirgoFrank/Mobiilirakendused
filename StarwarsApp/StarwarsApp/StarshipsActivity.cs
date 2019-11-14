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
    [Activity(Label = "Starships Activity")]
    public class StarshipsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Search);
            var searchfield = FindViewById<EditText>(Resource.Id.searchEditText);
            var searchButton = FindViewById<Button>(Resource.Id.searchButton);
            var peopleListView = FindViewById<ListView>(Resource.Id.peopleListView);
            InitailSearchAsync();
            async System.Threading.Tasks.Task InitailSearchAsync()
            {
                var queryString = "https://swapi.co/api/starships/?search=";
                var data = await DataService.GetStarWarsStarships(queryString);
                peopleListView.Adapter = new StarshipAdapter(this, data.Results);
            }

            searchButton.Click += async delegate
            {
                var searchText = searchfield.Text;
                var queryString = "https://swapi.co/api/starships/?search=" + searchText;
                var data = await DataService.GetStarWarsStarships(queryString);
                peopleListView.Adapter = new StarshipAdapter(this, data.Results);

            };
        }
    }
}