using System;
using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Android.Content;

using StarwarsApp;
using StarwarsApp.Core;

namespace StarwarsApp
{
    [Activity(Icon = "@drawable/icon", Label = "Star wars app", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {

        protected override void OnCreate(Bundle savedInstanceState)
        {

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_main);
            var peopleSearch = FindViewById<Button>(Resource.Id.People_search_btn);
            var planestSearch = FindViewById<Button>(Resource.Id.Planet_search_btn);
            var starshipSearch = FindViewById<Button>(Resource.Id.Starship_search_btn);
            var filmSearch = FindViewById<Button>(Resource.Id.Film_Seach_Button);
            filmSearch.Click += Film_Search;
            starshipSearch.Click += Starship_search;
            planestSearch.Click += Planets_Search;
            peopleSearch.Click += People_Search;
          //  var image = FindViewById<ImageView>(Resource.Id.imageview)
          //  var drawable = (int)typeof(Resource.Drawable).GetField("ic_launcer").GetValue(null);
            //image.SetImageResource(drawable);

        }

        private void People_Search(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(PeopleActivity));
            StartActivity(intent);
          
        }
        private void Planets_Search(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(Planets_Activity));
            StartActivity(intent);
        }
        private void Starship_search(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(StarshipsActivity));
            StartActivity(intent);
        }
        private void Film_Search(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(FilmActivity));
            StartActivity(intent);
        }



    }
}

