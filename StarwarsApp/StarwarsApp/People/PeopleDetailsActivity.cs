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

namespace StarwarsApp.People
{
    [Activity(Label = "PeopleDetailsActivity")]
    public class PeopleDetailsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Details);

            var PersonName = FindViewById<TextView>(Resource.Id.TextViewName);
            var PersonHeight = FindViewById<TextView>(Resource.Id.TextViewInfo1);
            var Mass = FindViewById<TextView>(Resource.Id.TextViewInfo2);
            var gender = FindViewById<TextView>(Resource.Id.TextViewInfo3);

            var peopleDetails = JsonConvert.DeserializeObject<PeopleDetails>(Intent.GetStringExtra("Details"));
            PersonName.Text = peopleDetails.Name;
            PersonHeight.Text ="Height: " +Convert.ToString(peopleDetails.Height);
            Mass.Text = "Mass: "+Convert.ToString(peopleDetails.Mass);
            gender.Text = peopleDetails.Gender;
        }
    }
}