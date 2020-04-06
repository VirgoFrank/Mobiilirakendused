using PictureApp.Models;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PictureApp.ViewModels
{
    public interface IPageAppearingEvent
    {
        void OnAppearing();
    }

    class ProfileViewModel : INotifyPropertyChanged , IPageAppearingEvent
    {

        public ProfileViewModel()
        {
            TakePictureCommand = new Command(OnTakePictureCommandAsync);
            GetPictureCommand = new Command(OnGetPictureCommandAsync);
            SaveUserChanges = new Command(SaveUser);
            Pic = new Picture();
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
        public Picture Pic { get; set; }

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
            source = file.Path;
        }

        public ICommand SaveUserChanges { get; set; }
        public ICommand TakePictureCommand { get; private set; }
        public ICommand GetPictureCommand { get; private set; }

        public void OnAppearing()
        {
            var currentuserID = Application.Current.Properties["user_id"];
            var account = App.Database.GetAccountAsync(int.Parse(currentuserID.ToString()));
            Password = account.Result.Password;
            Username = account.Result.Username;
            if(account.Result.ProfilePicPath != null)
                source = account.Result.ProfilePicPath;

        }
        public async void SaveUser()
        {
            var currentuserID = Application.Current.Properties["user_id"];
            var account = App.Database.GetAccountAsync(int.Parse(currentuserID.ToString()));
            account.Result.Password = Password;
            account.Result.Username = Username;
            account.Result.ProfilePicPath = Pic.path;
           await App.Database.SaveAccountsAsync(account.Result);

        }

        private string _Password;
        public string Password
        {
            get { return _Password; }
            set
            {
                if (_Password != value)
                {
                    _Password = value;
                    OnPropertyChanged(nameof(Password));
                }
            }
        }
        private string _Username;
        public string Username
        {
            get { return _Username; }
            set
            {
                if (_Username != value)
                {
                    _Username = value;
                    OnPropertyChanged(nameof(Username));
                }
            }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
