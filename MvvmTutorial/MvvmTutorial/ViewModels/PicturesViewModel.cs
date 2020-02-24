using MvvmTutorial.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace MvvmTutorial.ViewModels
{
    class PicturesViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        }
        public PicturesViewModel()
        {
            _pictures = new List<Picture> { new Picture { Name = "download.jpg" }, new Picture {Name= "europe_1939aug_800x720.jpg" } };
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
