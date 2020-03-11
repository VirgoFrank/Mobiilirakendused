using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PictureApp.Models
{
    class Picture
    {
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public ImageSource Source { get; set; }
    }
}
