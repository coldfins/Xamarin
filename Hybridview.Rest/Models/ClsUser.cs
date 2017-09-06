using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Hybridview.Rest.Models
{
    public class ClsUser
    {
        public int id { get; set; }
        public string name { get; set; }
        public string lastname { get; set; }
        public string username { get; set; }
        public string email { get; set; }
        private string password { get; set; }
        public DateTime date_created { get; set; }
        public DateTime date_modified { get; set; }

        public static explicit operator ClsUser(DataContext.usersRow v)
        {
            throw new NotImplementedException();
        }
    }

    public class login
    {
        public string username;
        public string password;
    }


    public class loginResponse{
        public int errorCode { get; set; }
        public string message { get; set; }
        public ClsUser data { get; set; }
    }
}