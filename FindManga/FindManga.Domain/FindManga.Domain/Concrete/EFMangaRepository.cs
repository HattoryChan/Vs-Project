using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindManga.Domain.Entities;
using FindManga.Domain.Abstract;

namespace FindManga.Domain.Concrete
{
    public class EFMangaRepository : IMangaRepository
    {
        EFDbContext context = new EFDbContext();

        public IEnumerable<Manga> Mangas
        {
            get { return context.Mangas; }
        }
    }
}
