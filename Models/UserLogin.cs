﻿namespace WebApplicationJWT.Models
{
    public class UserLogin
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Role { get;set; }
        public string toString()
        {
            return this.UserName + " " + this.Password + " " + this.Role;
        }
    }
}
