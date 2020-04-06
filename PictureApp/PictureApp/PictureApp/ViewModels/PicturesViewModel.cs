using PictureApp.Models;
using Plugin.Media;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PictureApp.ViewModels
{
   

    public class PicturesViewModel:INotifyPropertyChanged, IPageAppearingEvent
    {
        public PicturesViewModel()
        {
            Users = new List<Account>();
            LikeCommand = new Command(LikePicture);
            pictures = new List<Picture>();
            GetImages();
        }

        public ICommand LikeCommand { get;private set; }
        public int Likes { get; set; }

        public void OnAppearing()
        {
            GetImages();
        }

        public void LikePicture()
        {
            SelectedPicture.Likes++;
            App.Database.SavePictureAsync(SelectedPicture);
        }

        private async void GetImages()
        {
            pictures = await App.Database.GetPicturesAsync();
            for (int i = 0; i < pictures.Count; i++)
            {
                Users.Add(App.Database.GetAccountAsync(pictures[i].UserId).Result);
                pictures[i].Username = Users[i].Username;
                pictures[i].ProfilePicPath = Users[i].ProfilePicPath;

            }
        }
      

        private Picture _SelectedPicture { get; set; }
        public Picture SelectedPicture
        {
            get { return _SelectedPicture; }
            set
            {
                if (_SelectedPicture != value)
                {
                    _SelectedPicture = value;
                    GoToComment(_SelectedPicture.Id);
                }
            }
        }

        public async void GoToComment(int PictureId)
        {
            Application.Current.Properties["PictureId"] = PictureId;

            await Application.Current.MainPage.Navigation.PushAsync(new CommentPage ());
        }

        private List<Account> _Users;
        public List<Account> Users
        {
            get {return _Users;}
            set
            {
                if (_Users != value)
                {
                    _Users = value;
                    OnPropertyChanged(nameof(Users));
                }
            }
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
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        
    }
}
