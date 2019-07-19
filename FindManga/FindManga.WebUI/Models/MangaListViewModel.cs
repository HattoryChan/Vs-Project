using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FindManga.Domain.Entities;

namespace FindManga.WebUI.Models
{
    public class MangaListViewModel
    {
        public IEnumerable<Manga> Mangas { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}