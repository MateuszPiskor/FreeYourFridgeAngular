using System;
using System.Collections.Generic;

namespace FreeYourFridge.API.Models
{
    public class User
    {
        public int Id {get;set;}
        public string Username{get;set;}
        public byte[] PasswordHash{get;set;}
        public byte[] PasswordSalt {get;set;}
        public string Gender {get;set;}
        public DateTime DateOfBirth {get;set;}
        public decimal Weight{get;set;}
        public decimal Height {get;set;}
        public ICollection<Photo> Photo {get;set;}
    }
}