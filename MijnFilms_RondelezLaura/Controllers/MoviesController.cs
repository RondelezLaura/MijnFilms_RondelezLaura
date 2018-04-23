using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MijnFilms_RondelezLaura.Entities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MijnFilms_RondelezLaura.Controllers
{
    [Route("")]
    [Route("[controller]")]
    public class MoviesController : Controller
    {

        private MovieContext db;
        public MoviesController(MovieContext context)
        {
            db = context;
        }

        [Route("")]
        [Route("[controller]/Lijst")]
        public ViewResult List()
        {
            return View(db.Movie
                    .Select(m => m)
                    .ToList());
        }

        [Route("[controller]/Sorteer/{sorting?:regex(title|year|stars)}")]
        [Route("/Sorteer/{sorting?:regex(title|year|stars)}")]
        public ViewResult Sort(string sorting)
        {
            var toView = db.Movie
                .Select(m => m);
            switch (sorting)
            {
                case "":
                case "title":
                    break;
                case "year":
                    toView.OrderByDescending(m => m.Year);
                    break;
                case "stars":
                    toView.OrderByDescending(m => m.Stars);
                    break;
            }
            return View("List", toView.OrderBy(m => m.Title).ToList());
        }

        [Route("[controller]/[action]")]
        public ViewResult Details(int movieID)
        {
            return View(
                db.Movie
                .Where(m => m.MovieID == movieID)
                .Join(Genre,
                    m => m.GenreID,
                    g => g.GenreID,
                    (m, g) => new
                    {
                        MovieID = m.MovieID,
                        Titel = m.Title,
                        Jaar = m.Year,
                        Waardering = m.Stars,
                        Beschrijving = m.Description,
                        Genre = g.Description
                    }).Join(MovieActor,
                        m => m.MovieID,
                        a => a.MovieID,
                        (m, a) => new
                        {
                            Titel = m.Titel,
                            Jaar = m.Jaar,
                            Waardering = m.Waardering,
                            Beschrijving = m.Beschrijving,
                            Genre = m.Genre,
                            ActeurID = a.ActorID
                        }).Join(Person,
                        m => m.ActorID,
                        p => p.PersonID,
                        (m, a) => new
                        {
                            Titel = m.Titel,
                            Jaar = m.Jaar,
                            Waardering = m.Waardering,
                            Beschrijving = m.Beschrijving,
                            Genre = m.Genre,
                            Acteurs = p.FirstName + " " + p.Lastname
                        }).Join(Person,
                        m => m.DirectorID,
                        p => p.PersonID,
                        (m, a) => new
                        {
                            Titel = m.Titel,
                            Jaar = m.Jaar,
                            Waardering = m.Waardering,
                            Beschrijving = m.Beschrijving,
                            Regisseur = m.FirstName + " " + m.Lastname,
                            Genre = m.Genre,
                            Acteurs = m.Acteurs
                        })
                    .ToList());
        }

        [Route("[controller]/Zoek/{zoekterm?:string}/{*param}")]
        [Route("/Zoek/{zoekterm?:string}/{*param}")]
        public ViewResult Find(string zoekterm)
        {
            return View("List",
                  db.Movie
                  .Where(m => m.Title.Contains(zoekterm))
                  .Select(m => m)
                  .ToList());
        }
    }
}
