using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace HookahSearchServer.Models
{
    public class AuthOptions
    {
        public const string ISSUER = "HattoryGroup";
        public const string AUDIENCE = "http://localhost:53870/";
        const string KEY = "mysupersecret_secretkey!123";
        public const int LIFETIME = 1; //in minutes
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}
