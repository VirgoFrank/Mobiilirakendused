using PictureApp.Models;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using PictureApp.Data;

namespace PictureApp.ViewModels
{
    class AddPictureViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public AddPictureViewModel()
        {
           
            TakePictureCommand = new Command(OnTakePictureCommandAsync);
            GetPictureCommand = new Command(OnGetPictureCommandAsync);
            SavePictureCommand = new Command(SavePicture);
            Pic = new Picture();
        }

     

        public ICommand TakePictureCommand { get; private set; }
        public ICommand GetPictureCommand { get; private set; }
        public ICommand SavePictureCommand { get; private set; }
        public Picture Pic { get; set; }

        private string _Name;
        public string Name
        {
            get { return _Name; }
            set
            {
                if (_Name != value)
                    _Name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        private ImageSource _source;
        public ImageSource source
        {
            get { return _source; }
            set
            {
                if (_source != value)
                    _source = value;
                OnPropertyChanged(nameof(source));
            }
        }
        private async void SavePicture()
        {
            var currentuserID = Application.Current.Properties["user_id"];
            var image = new Picture() {path = Pic.path, Name = Name , UserId =(int)currentuserID};
            await App.Database.SavePictureAsync(image);
        }

        private async void OnGetPictureCommandAsync()
        {
            await CrossMedia.Current.Initialize();
            var file = await CrossMedia.Current.PickPhotoAsync();
            Pic.path = file.Path;
            source = file.Path;
        }

        private async void OnTakePictureCommandAsync()
        {
            await CrossMedia.Current.Initialize();

            //if(!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsPickPhotoSupported)
            //{
            //    await si
            //}

            var file = await CrossMedia.Current.TakePhotoAsync(
                new Plugin.Media.Abstractions.StoreCameraMediaOptions
                {
                   // SaveToAlbum = true
                }
            );
            Pic.path = file.Path;
            source = file.Path;
        }

       
    }
}
