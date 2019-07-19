using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FindManga.Domain.Abstract;
using FindManga.Domain.Entities;
using FindManga.WebUI.Models;

namespace FindManga.WebUI.Controllers
{
    public class MangaController : Controller
    {
        private IMangaRepository repository;
        public int pageSize = 4;
        public MangaController(IMangaRepository repo)
        {
            repository = repo;
        }

        public ViewResult List(int page = 1)
        {
            MangaListViewModel model = new MangaListViewModel
            {
                Mangas = repository.Mangas
                .OrderBy(Manga => Manga.MangaId)
                .Skip((page - 1) * pageSize)
                .Take(pageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = pageSize,
                    TotalItems = repository.Mangas.Count()
                }
            };
            return View(model);
        }        
    }
}