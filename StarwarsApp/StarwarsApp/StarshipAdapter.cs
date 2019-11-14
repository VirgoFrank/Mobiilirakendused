using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using StarwarsApp;
using StarwarsApp.Core;

namespace StarwarsApp
{
    public class StarshipAdapter : BaseAdapter<StarshipDetails>
    {
        List<StarshipDetails> _items;
        Activity _context;
       

        public StarshipAdapter(Activity context, List<StarshipDetails> items) : base()
        {
            this._context = context;
            this._items = items;
        }



        public override StarshipDetails this[int position]
        {
            get { return _items[position]; }
        }

        public override int Count
        {
            get { return _items.Count; }
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = _items[position];

            View view = convertView;
            if (view == null)
                view = _context.LayoutInflater.Inflate(Resource.Layout.Second_Layout, null);
            view.FindViewById<TextView>(Resource.Id.textView1).Text = item.Name;
            view.FindViewById<TextView>(Resource.Id.textView2).Text = item.model.ToString();
            view.FindViewById<TextView>(Resource.Id.textView3).Text = item.cost_in_credits.ToString();
            view.FindViewById<TextView>(Resource.Id.textView4).Text = item.crew.ToString();

            return view;
        }
    }
}