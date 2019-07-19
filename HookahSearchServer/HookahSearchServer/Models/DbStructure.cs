using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HookahSearchServer.Models
{
    //definition for usr table rows
    public class User
    {
        public int id { get; set; }
        public string login { get; set; }
        public string pass_hash { get; set; }
    }
}
