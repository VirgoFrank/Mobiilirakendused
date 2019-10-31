using System;
using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Widget;
using Android.Content;
using StarwarsApp;
using StarwarsApp.Core;

namespace StarwarsApp
{
    [Activity(Label = "string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

           

           
            
            var searchfield = FindViewById<EditText>(Resource.Id.searchEditText);
            var searchButton = FindViewById<Button>(Resource.Id.searchButton);
            var peopleListView = FindViewById<ListView>(Resource.Id.peopleListView);
           
            searchButton.Click += async delegate
            {
                var searchText = searchfield.Text;
                var queryString = "https://swapi.co/api/people/?search=" + searchText;
                var data = await DataService.GetStarWarsPeople(queryString);
                peopleListView.Adapter = new StarWarsPeopleAdapter(this, data.Results);
               
            };
             
        }



      
      

       

       
    }
}

