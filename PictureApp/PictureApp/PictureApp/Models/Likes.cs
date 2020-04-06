﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace PictureApp.Models
{
   public class Likes
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
    }
}
