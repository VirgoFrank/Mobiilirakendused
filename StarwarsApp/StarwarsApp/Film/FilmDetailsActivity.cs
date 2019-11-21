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

namespace StarwarsApp
{
    [Activity(Label = "FilmDetailsActivity")]
    public class FilmDetailsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Film_details_layout);

            var filmNameTextView = FindViewById<TextView>(Resource.Id.filmTitleTextView);
            var filmDesc = FindViewById<TextView>(Resource.Id.textViewKirjeldus);
            var filmYear = FindViewById<TextView>(Resource.Id.textViewAasta);

            var filmDetails = JsonConvert.DeserializeObject<FilmDetails>(Intent.GetStringExtra("filmDetails"));
            filmNameTextView.Text = filmDetails.Title;
            filmDesc.Text = filmDetails.opening_crawl;
            filmYear.Text = Convert.ToString(filmDetails.release_date.Year);
           
        }
    }
}