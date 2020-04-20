using PictureApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PictureApp.ViewModels
{
    public class CommentViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public CommentViewModel()
        {
            PostCommand = new Command(Post);
            Comments = new ObservableCollection<Comment>();
            LikeCommand = new Command(Like);
            Likes = App.Database.GetPictureAsync((int)Application.Current.Properties["PictureId"]).Result.Likes;
            GetComments();
        }

        public string CommentText { get; set; }
        public int PictureId { get; set;  }

        public int _likes;
        public int Likes 
        {
            get { return _likes; }
            set
            {
                if (_likes != value)
                    _likes = value;
                OnPropertyChanged(nameof(Likes));
            }
        }

        private ObservableCollection<Comment> _comments;
        public ObservableCollection<Comment> Comments
        {
            get { return _comments; }
            set
            {
                if (_comments != value)
                {
                    _comments= value;
                    OnPropertyChanged(nameof(Comments));
                }
            }
        }

        public ICommand PostCommand { get; private set; }
        public ICommand LikeCommand { get; set; }

        public void GetComments()
        {
            Comments = new ObservableCollection<Comment>();
            var commenstlist = App.Database.GetCommentsAsync().Result;
            PictureId = (int)Application.Current.Properties["PictureId"];
            for (int i = 0; i < commenstlist.Count; i++)
            {
                if (commenstlist[i].PictureId == PictureId)
                    Comments.Add(commenstlist[i]);
            }


        }

        public async void Like()
        {
            var user = App.Database.GetAccountAsync((int)Application.Current.Properties["user_id"]).Result;
            var Post = App.Database.GetPictureAsync((int)Application.Current.Properties["PictureId"]).Result;
            var Likeslist = App.Database.GetLikesAsync().Result;
            foreach(var like in Likeslist)
            {
                if (user.Id == like.UserId && like.PostId == (int)Application.Current.Properties["PictureId"])
                {
                    await App.Database.DeleteLikeAsync(like);
                    Post.Likes--;
                    Likes--;
                    await App.Database.SavePictureAsync(Post);
                    return;

                }
            }
            var NewLike = new Likes() { PostId = Post.Id, UserId = user.Id };
            await App.Database.SaveLikesAsync(NewLike);
            Post.Likes++;
            await App.Database.SavePictureAsync(Post);
            Likes++;
        }
      
        public async void Post()
        {
            string Username = App.Database.GetAccountAsync((int)Application.Current.Properties["user_id"]).Result.Username;
            var comment = new Comment() { CommentText = CommentText, UserId = (int)Application.Current.Properties["user_id"], Username = Username,
            PictureId= (int)Application.Current.Properties["PictureId"]};
            await  App.Database.SaveCommentsAsync(comment);
           
            GetComments();
        }
    }
}
