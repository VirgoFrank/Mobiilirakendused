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
using Newtonsoft.Json;
using StarwarsApp.Core;
using StarwarsApp.Starships;
using static Android.Widget.AdapterView;

namespace StarwarsApp
{
    [Activity(Label = "Starships Activity", Theme = "@style/AppTheme.NoActionBar")]
    public class StarshipsActivity : Activity
    {
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Search);
            var searchfield = FindViewById<EditText>(Resource.Id.searchEditText);
            var searchButton = FindViewById<Button>(Resource.Id.searchButton);
            var peopleListView = FindViewById<ListView>(Resource.Id.peopleListView);
            var queryString = "https://swapi.co/api/starships/?search=";
            var Starships = await DataService.GetStarWarsStarships(queryString);
            peopleListView.Adapter = new StarshipAdapter(this, Starships.Results);
            await InitailSearchAsync();

            async System.Threading.Tasks.Task InitailSearchAsync()
            {
                var data = await DataService.GetStarWarsStarships(queryString);
                peopleListView.Adapter = new StarshipAdapter(this, data.Results);
            }
            peopleListView.ItemClick += (object sender, ItemClickEventArgs e) =>
            {
                var Starship = Starships.Results[e.Position];
                var intent = new Intent(this, typeof(StarshipsDetailsActivity));
                intent.PutExtra("Details", JsonConvert.SerializeObject(Starship));
                StartActivity(intent);
            };


            searchButton.Click += async delegate
            {
                var searchText = searchfield.Text;
                queryString = "https://swapi.co/api/starships/?search=" + searchText;
                var data = await DataService.GetStarWarsStarships(queryString);
                peopleListView.Adapter = new StarshipAdapter(this, data.Results);

            };
        }
    }
}