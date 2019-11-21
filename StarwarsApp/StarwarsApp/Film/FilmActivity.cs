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
using static Android.Widget.AdapterView;

namespace StarwarsApp
{
    [Activity(Label = "Films Activity", Theme = "@style/AppTheme.NoActionBar")]
    public class FilmActivity : Activity
    {
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Search);

            var searchfield = FindViewById<EditText>(Resource.Id.searchEditText);
            var searchButton = FindViewById<Button>(Resource.Id.searchButton);
            var peopleListView = FindViewById<ListView>(Resource.Id.peopleListView);
           
            var queryString = "https://swapi.co/api/films/?search=";
           // var data = await DataService.GetStarWarsFilms(queryString);
            var films = await DataService.GetStarWarsFilms(queryString);
            peopleListView.Adapter = new Film_Adapter(this, films.Results);
            await InitailSearchAsync();

            async System.Threading.Tasks.Task InitailSearchAsync()
            {
                var data = await DataService.GetStarWarsFilms(queryString);
                peopleListView.Adapter = new Film_Adapter(this, data.Results);
            }
            peopleListView.ItemClick += (object sender, ItemClickEventArgs e) =>
            {
              //  var clickPositionText = peopleListView.GetItemAtPosition(e.Position);
               // var clickPositionID = Convert.ToString(e.Position);

                var film = films.Results[e.Position];
                var intent = new Intent(this, typeof(FilmDetailsActivity));
                intent.PutExtra("filmDetails", JsonConvert.SerializeObject(film));
                StartActivity(intent);
            };

            searchButton.Click += async delegate
            {
                var searchText = searchfield.Text;
                 queryString = "https://swapi.co/api/films/?search=" + searchText;
                var data = await DataService.GetStarWarsFilms(queryString);
                peopleListView.Adapter = new Film_Adapter(this, data.Results);

            };
        }
    }
}