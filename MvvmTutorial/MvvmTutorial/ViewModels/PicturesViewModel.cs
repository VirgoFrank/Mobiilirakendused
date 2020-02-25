using Android;
using MvvmTutorial.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;


namespace MvvmTutorial.ViewModels
{
    class PicturesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        }
        //private static Regex r = new Regex(":");

        //public string GetDateTakenFromImage(string path)
        //{
        //    using (FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read))
        //    using (Image myImage = Image.FromStream(fs, false, false))
        //    {
        //        PropertyItem propItem = myImage.GetPropertyItem(36867);
        //        string dateTaken = r.Replace(Encoding.UTF8.GetString(propItem.Value), "-", 2);
        //        return DateTime.Parse(dateTaken).ToString();
        //    }
        //}

      
       
        public PicturesViewModel()
        {
          
            

            _pictures = new List<Picture> { 
            new Picture { Name = "download.jpg", Date=DateTime.Now },
            new Picture {Name= "europe_1939aug_800x720.jpg",Date=DateTime.Now },
            new Picture {Name= "europeMap.png",Date=DateTime.Now },
            new Picture {Name= "europe_map_editable.jpg",Date=DateTime.Now}};
        }

       


        private List<Picture> _pictures;
        public List<Picture> pictures
        {
            get { return _pictures; }
            set
            {
                if (_pictures != value)
                {
                    _pictures = value;
                    OnPropertyChanged(nameof(pictures));
                }
            }
        }
    }
}
