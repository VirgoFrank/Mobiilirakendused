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
            var peopleSearch = FindViewById<Button>(Resource.Id.People_search_btn);

        }

        private void ToCarButton_Click(object sender, EventArgs e)
        {
            var intent = new Intent(this, typeof(searc));
            StartActivity(intent);
        }






    }
}

