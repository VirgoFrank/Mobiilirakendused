﻿using System;
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
using StarwarsApp.Planets;
using static Android.Widget.AdapterView;

namespace StarwarsApp
{
    [Activity(Label = "Planets Activity", Theme = "@style/AppTheme.NoActionBar")]
    public class PlanetsActivity : Activity
    {
        protected override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Search);
            var searchfield = FindViewById<EditText>(Resource.Id.searchEditText);
            var searchButton = FindViewById<Button>(Resource.Id.searchButton);
            var peopleListView = FindViewById<ListView>(Resource.Id.peopleListView);
            var queryString = "https://swapi.co/api/planets/?search=";
            var Planets = await DataService.GetStarWarsPlanets(queryString);
            peopleListView.Adapter = new PlanetAdapter(this, Planets.Results);
            await InitailSearchAsync();


            async System.Threading.Tasks.Task InitailSearchAsync()
            {
                var data = await DataService.GetStarWarsPlanets(queryString);
                peopleListView.Adapter = new PlanetAdapter(this, data.Results);
            }

            peopleListView.ItemClick += (object sender, ItemClickEventArgs e) =>
            {
                var Planet = Planets.Results[e.Position];
                var intent = new Intent(this, typeof(PlanetsDetailsActivity));
                intent.PutExtra("Details", JsonConvert.SerializeObject(Planet));
                StartActivity(intent);
            };

            searchButton.Click += async delegate
            {
                var searchText = searchfield.Text;
                queryString = "https://swapi.co/api/planets/?search=" + searchText;
                var data = await DataService.GetStarWarsPlanets(queryString);
                peopleListView.Adapter = new PlanetAdapter(this, data.Results);

            };
        }
    }
}