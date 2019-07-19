using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FindManga.Domain.Entities;

namespace FindManga.Domain.Abstract
{
    public interface IMangaRepository
    {
        IEnumerable<Manga> Mangas { get; } 
    }
}
