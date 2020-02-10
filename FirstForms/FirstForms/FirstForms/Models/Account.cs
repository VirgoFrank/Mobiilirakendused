using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace FirstForms.Models
{
  public  class Account
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string First_Name { get; set; }
        public string Last_name { get; set; }
        


    }
}
