using System.Collections.Generic;
using Android.App;
using Android.Views;
using Android.Widget;
using StarwarsApp;
using StarwarsApp.Core;

namespace StarwarsApp
{
    public class Film_Adapter : BaseAdapter<FilmDetails>
    {
        List<FilmDetails> _items;
        Activity _context;


        public Film_Adapter(Activity context, List<FilmDetails> items) : base()
        {
            this._context = context;
            this._items = items;
        }



        public override FilmDetails this[int position]
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
                view = _context.LayoutInflater.Inflate(Resource.Layout.FilmLayout, null);
            view.FindViewById<TextView>(Resource.Id.textViewFilm).Text = item.Title;
           view.FindViewById<TextView>(Resource.Id.textViewAasta).Text = item.release_date.Year.ToString();
            view.FindViewById<TextView>(Resource.Id.textViewKirjeldus).Text = item.opening_crawl.ToString();

            return view;
        }
    }
}