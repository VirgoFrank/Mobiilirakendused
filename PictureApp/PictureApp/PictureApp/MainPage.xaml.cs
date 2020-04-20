using PictureApp.Models;
using PictureApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;


namespace PictureApp
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage, INotifyPropertyChanged
    {
        public MainPage()
        {
            Users = new List<Account>();
            pictures = new ObservableCollection<Picture>();
            LikePost = new Command<Picture>(Like);
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            GetImages();
            GetComments();
        }

      
        void DoubleTapped(object sender, EventArgs args)
        {
            var SelectedImage = sender as Image;

            var selectedItem = SelectedImage.BindingContext as Picture;

            Like(selectedItem);
        }

      
       
        public ICommand LikePost { get; set; }

        public async void Like(Picture LikedImage)
        {
            var user = App.Database.GetAccountAsync((int)Application.Current.Properties["user_id"]).Result;
            var Post = LikedImage;
            var Likeslist = App.Database.GetLikesAsync().Result;
            foreach (var like in Likeslist)
            {
                if (user.Id == like.UserId && like.PostId == LikedImage.Id)
                {
                    await App.Database.DeleteLikeAsync(like);
                    LikedImage.Likes--;
                    await App.Database.SavePictureAsync(LikedImage);
                   
                    GetImages();
                    return;
                }
            }
            var NewLike = new Likes() { PostId = Post.Id, UserId = user.Id };
            await App.Database.SaveLikesAsync(NewLike);
            LikedImage.Likes++;
            await App.Database.SavePictureAsync(LikedImage);
            GetImages();
           
        }
        private void GetComments()
        {
            var Comments = App.Database.GetCommentsAsync().Result;

            for (int i = 0; i < Comments.Count; i++)
            {
                for (int j = 0; j < pictures.Count; j++)
                {
                   
                    if (Comments[i].PictureId == pictures[j].Id)
                    {
                        pictures[j].Comments++;
                       
                    }

                }
            }


        }

        private void GetImages()
        {

            pictures = App.Database.GetPicturesAsync();
            Users = App.Database.GetAccountsAsync().Result;
            for (int i = 0; i < pictures.Count; i++)
            {
                Users.Add(App.Database.GetAccountAsync(pictures[i].UserId).Result);
                pictures[i].Username = Users[i].Username;
                pictures[i].ProfilePicPath = Users[i].ProfilePicPath;

            }
            pictureList.ItemsSource = pictures;

        }


        public async void GoToComment(object sender, EventArgs args)
        {
            var SelectedImage = sender as Image;

            var selectedItem = SelectedImage.BindingContext as Picture;

            Application.Current.Properties["PictureId"] = selectedItem.Id;

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
       

    }
}
