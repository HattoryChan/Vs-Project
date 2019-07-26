using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace HookahSearchServer.Models
{
    public class User_Identity : IdentityUser
    {
        public int Year { get; set; }
    }
}
