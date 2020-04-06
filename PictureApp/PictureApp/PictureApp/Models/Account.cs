using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PictureApp.Models
{
    public class Account
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ProfilePicPath { get; set; }
       // public List<int> LikedPosts { get; set; }
    }
}
