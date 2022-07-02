using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;

namespace DevelopmentInfo.WebApi
{
    public class UserServices : IUserServices
    {
        public int Authenticate(string userName, string password)
        {
            string user = ConfigurationManager.AppSettings["User"];
            string pwd  = ConfigurationManager.AppSettings["Password"];

            if (!user.Equals(userName) || !pwd.Equals(password))
            {
                return -1;
            }

            return 0;
        }
    }
}