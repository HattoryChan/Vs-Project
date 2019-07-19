using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;


namespace HookahSearchServer.Models
{
    public class DbTables : DbContext
    {
        // usr - table name, User - db table structure
        public DbSet<User> usr { get; set; }
        public DbTables(DbContextOptions<DbTables> options)
            : base (options)
        { }
        
    }
}
