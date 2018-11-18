using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyApp.WebAPI.Models.Security
{
    public class GlobalUser
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public Guid ID { get; set; }
        public Guid? Token { get; set; }
        public string Name { get; set; }

        public static GlobalUser Marshall(MyApp.API.Security.EF.GlobalUser input)
        {
            return new GlobalUser() { ID = input.ID, Password = input.Password, Username = input.Username, Token = input.Token, Name = input.Name };
        }
    }
}