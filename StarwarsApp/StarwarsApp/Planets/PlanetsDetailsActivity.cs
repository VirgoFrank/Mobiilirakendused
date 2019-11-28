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

namespace StarwarsApp.Planets
{
    [Activity(Label = "PlanetsDetailsActivity")]
    public class PlanetsDetailsActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Details);

            var Name = FindViewById<TextView>(Resource.Id.TextViewName);
            var diameter = FindViewById<TextView>(Resource.Id.TextViewInfo1);
            var gravity = FindViewById<TextView>(Resource.Id.TextViewInfo2);
            var terrain = FindViewById<TextView>(Resource.Id.TextViewInfo3);

            var PlanetDetails = JsonConvert.DeserializeObject<PlanetDetails>(Intent.GetStringExtra("Details"));
            Name.Text = PlanetDetails.Name;
            diameter.Text = "diameter: " + Convert.ToString(PlanetDetails.diameter);
            gravity.Text = "gravity: " + Convert.ToString(PlanetDetails.gravity);
            terrain.Text = PlanetDetails.terrain;
        }
    }
}