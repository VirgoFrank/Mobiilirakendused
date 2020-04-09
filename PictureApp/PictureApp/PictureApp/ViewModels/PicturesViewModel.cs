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


    public class PicturesViewModel : INotifyPropertyChanged, IPageAppearingEvent
    {
        public PicturesViewModel()
        {
            Users = new List<Account>();
            pictures = new ObservableCollection<Picture>();
            // GetImages();
        }


        public void OnAppearing()
        {
            GetImages();
        }

        public async void Like(Picture LikedImage)
        {
            var user = App.Database.GetAccountAsync((int)Application.Current.Properties["user_id"]).Result;
            var Post = LikedImage;
            GetImages();
            var Likeslist = App.Database.GetLikesAsync().Result;
            foreach (var like in Likeslist)
            {
                if (user.Id == like.UserId && like.PostId == LikedImage.Id)
                {
                    await App.Database.DeleteLikeAsync(like);
                    foreach (var pic in pictures)
                    {
                        if (pic.Id == LikedImage.Id)
                        {
                            pic.Likes--;
                            await App.Database.SavePictureAsync(pic);
                            GetImages();
                        }
                    }
                    return;
                }
            }
            var NewLike = new Likes() { PostId = Post.Id, UserId = user.Id };
            await App.Database.SaveLikesAsync(NewLike);
            foreach (var pic in pictures)
            {
                if (pic.Id == LikedImage.Id)
                {
                    pic.Likes++;
                    await App.Database.SavePictureAsync(pic);
                    GetImages();
                }

            }
        }

        private void GetImages()
        {
            pictures = App.Database.GetPicturesAsync();

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

            await Application.Current.MainPage.Navigation.PushAsync(new CommentPage());
        }

        private List<Account> _Users;
        public List<Account> Users
        {
            get { return _Users; }
            set
            {
                if (_Users != value)
                {
                    _Users = value;
                    OnPropertyChanged(nameof(Users));
                }
            }
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
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }


    }
}
