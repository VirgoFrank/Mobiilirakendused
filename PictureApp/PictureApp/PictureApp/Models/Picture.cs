using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PictureApp.Models
{
    public class Picture
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public string path { get; set; }
        public int Likes { get; set; }
        public int UserId { get; set; }
        public string Username { get; set; }
        public string ProfilePicPath { get; set; }
    }
}
