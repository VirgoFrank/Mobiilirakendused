using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PictureApp.Models
{
    public class Comment
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Username { get; set; }
        public string CommentText { get; set; }
        public int UserId { get; set; }
        public int PictureId { get; set; }


    }
}
