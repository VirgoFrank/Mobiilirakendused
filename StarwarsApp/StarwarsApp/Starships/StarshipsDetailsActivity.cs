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

namespace StarwarsApp.Starships
{
    [Activity(Label = "StashipsDetailsActivity")]
    public class StarshipsDetailsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Details);

            var Name = FindViewById<TextView>(Resource.Id.TextViewName);
            var Modle = FindViewById<TextView>(Resource.Id.TextViewInfo1);
            var cost = FindViewById<TextView>(Resource.Id.TextViewInfo2);
            var crew = FindViewById<TextView>(Resource.Id.TextViewInfo3);

            var StarshipDetails = JsonConvert.DeserializeObject<StarshipDetails>(Intent.GetStringExtra("Details"));
            Name.Text = StarshipDetails.Name;
            Modle.Text = "Modle: " + Convert.ToString(StarshipDetails.model);
            cost.Text = "cost: " + Convert.ToString(StarshipDetails.cost_in_credits);
            crew.Text = StarshipDetails.crew;
        }
    }
}