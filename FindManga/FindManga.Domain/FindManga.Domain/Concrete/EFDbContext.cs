using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindManga.Domain.Entities;
using System.Data.Entity;

namespace FindManga.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Manga> Mangas { get; set; }
    }
}
