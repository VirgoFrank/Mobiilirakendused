using PictureApp.Models;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PictureApp.ViewModels
{
    class PicturesViewModel
    {
        public PicturesViewModel()
        {
            pictures = new ObservableCollection<Picture>();
            TakePictureCommand = new Command(OnTakePictureCommand);
            GetPictureCommand = new Command(OnGetPictureCommand);

            Picture pic1 = new Picture { Name = "download.jpg", Date = DateTime.Now, Source = "download.jpg" };
            Picture pic2 = new Picture { Name = "europe_1939aug_800x720.jpg", Date = DateTime.Now, Source = "europe_1939aug_800x720.jpg" };
            Picture pic3 = new Picture { Name = "europeMap.png", Date = DateTime.Now, Source = "europeMap.png" };
            Picture pic4 = new Picture { Name = "europe_map_editable.jpg", Date = DateTime.Now, Source = "europe_map_editable.jpg" };

            pictures.Add(pic1);
            pictures.Add(pic2);
            pictures.Add(pic3);
            pictures.Add(pic4);

            //_pictures = new ObservableCollection<Picture> { 
            //new Picture { Name = "download.jpg", Date=DateTime.Now },
            //new Picture {Name= "europe_1939aug_800x720.jpg",Date=DateTime.Now },
            //new Picture {Name= "europeMap.png",Date=DateTime.Now },
            //new Picture {Name= "europe_map_editable.jpg",Date=DateTime.Now}};
        }




        private ObservableCollection<Picture> _pictures;
        public ObservableCollection<Picture> pictures
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

        public ICommand TakePictureCommand { get; private set; }
        public ICommand GetPictureCommand { get; private set; }

        private async void OnTakePictureCommand()
        {
            await CrossMedia.Current.Initialize();

            //if(!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsPickPhotoSupported)
            //{
            //    await si
            //}

            var file = await CrossMedia.Current.TakePhotoAsync(
                new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                    SaveToAlbum = true
                }
            );

            // PathLabel.text = file.AlbumPath;

            var image = new Picture();
            image.Name = "New picture";
            //image.Url = ImageSource.FromStream(file.Path);


            image.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });

            pictures.Add(image);

        }

        private async void OnGetPictureCommand()
        {
            await CrossMedia.Current.Initialize();

            var image = new Picture();
            image.Name = "New picture";
            //image.Url = ImageSource.FromStream(file.Path);
            var file = await CrossMedia.Current.PickPhotoAsync();

            image.Source = ImageSource.FromStream(() =>
            {
                var stream = file.GetStream();
                return stream;
            });

            pictures.Add(image);


        }

        public void RefreshList()
        {
            var test = "asd";
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
