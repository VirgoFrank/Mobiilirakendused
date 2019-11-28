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
using StarwarsApp.People;
using static Android.Widget.AdapterView;

namespace StarwarsApp
{
    [Activity(Label = "People Activity", Theme = "@style/AppTheme.NoActionBar")]
    public class PeopleActivity : Activity
    {
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Search);

            var searchfield = FindViewById<EditText>(Resource.Id.searchEditText);
            var searchButton = FindViewById<Button>(Resource.Id.searchButton);
            var peopleListView = FindViewById<ListView>(Resource.Id.peopleListView);
            var queryString = "https://swapi.co/api/people/?search=";
            var People = await DataService.GetStarWarsPeople(queryString);
            peopleListView.Adapter = new StarWarsPeopleAdapter(this, People.Results);
            await InitailSearchAsync();


            async System.Threading.Tasks.Task InitailSearchAsync() 
            {
                var data = await DataService.GetStarWarsPeople(queryString);
                peopleListView.Adapter = new StarWarsPeopleAdapter(this, data.Results);
            }

            peopleListView.ItemClick += (object sender, ItemClickEventArgs e) =>
            {
                var Person = People.Results[e.Position];
                var intent = new Intent(this, typeof(PeopleDetailsActivity));
                intent.PutExtra("Details", JsonConvert.SerializeObject(Person));
                StartActivity(intent);
            };

            searchButton.Click += async delegate
            {
                var searchText = searchfield.Text;
                queryString = "https://swapi.co/api/people/?search=" + searchText;
                var data = await DataService.GetStarWarsPeople(queryString);
                peopleListView.Adapter = new StarWarsPeopleAdapter(this, data.Results);

            };
        }
    }
}