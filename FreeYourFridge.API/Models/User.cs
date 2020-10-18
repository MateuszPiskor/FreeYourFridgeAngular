using System;
using System.Collections.Generic;

namespace FreeYourFridge.API.Models
{
    public class User
    {
        public int Id {get;set;}
        public string Username{get;set;}
        public string Email {get;set;}
        public byte[] PasswordHash{get;set;}
        public byte[] PasswordSalt {get;set;}
        public string Gender {get;set;}
        public int Age {get;set;}
        public decimal Weight{get;set;}
        public decimal Height {get;set;}
    }
}