using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebappsIV_1920_be_AudreyB.DTOs;
using WebappsIV_1920_be_AudreyB.Models;

namespace WebappsIV_1920_be_AudreyB.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FilmsController : ControllerBase
    {
        private readonly IFilmRepository _filmRepository;

        /// <summary>
        /// FilmController
        /// </summary>
        /// <param name="context">Object FilmRepository interface</param>
        public FilmsController(IFilmRepository context)
        {
            _filmRepository = context;
        }

        // GET: api/Films
        /// <summary>
        /// Geeft alle films 
        /// </summary>
        /// <returns>array van films</returns>
        [AllowAnonymous]
        [HttpGet("")]
        public IEnumerable<FilmDTO> GetFilms()
        {
            IEnumerable<FilmDTO> films = _filmRepository.GetAllFilms()
                .Select(film => new FilmDTO()
                {
                    FilmID = film.FilmId,
                    Titel = film.Titel,
                    Jaar = film.Jaar,
                    Duur = film.Duur,
                    Regisseur = film.Regisseur,
                    FilmGenres = film.FilmGenres,
                    FilmActeurs = film.FilmActeurs,
                    FilmSchrijvers = film.FilmSchrijvers,
                    KorteInhoud = film.KorteInhoud,
                    Productiebedrijf = film.Productiebedrijf
                });
            if (films == null)
            {
                throw new ArgumentNullException("Geen films");
            }
            return films;
        }

        //GET: api/Films/GetGenres
        /// <summary>
        /// Geeft alle genres
        /// </summary>
        /// <returns>array van genres</returns>
        [AllowAnonymous]
        [HttpGet("GetGenres")]
        public IEnumerable<GenreDTO> GetGenres()
        {
            IEnumerable<GenreDTO> genres = _filmRepository.GetAllGenres()
               .Select(genre => new GenreDTO()
               {
                   Genrenaam = genre.Naam
               });
              return genres;

        } 

        //GET: api/Films/GetFilmByTitle/Titanic
        /// <summary>
        /// Geeft de film met de gegeven titel
        /// </summary>
        /// <param name="titel">Titel van de film</param>
        /// <returns>De film</returns>
        [AllowAnonymous]
        [HttpGet("GetFilmByTitle/{titel}")]
        public ActionResult<FilmDTO> GetFilmByTitle(string titel)
        {
            Film film = _filmRepository.GetFilmByTitel(titel);
            if (film == null)
            {
                return NotFound();
            }
            else
            {
                return new FilmDTO(film);
            }
        }

        //GET: api/Films/GetFilmByJaar/1984
        /// <summary>
        /// Geeft alle films met het juiste jaar
        /// </summary>
        /// <param name="jaar">jaar van de film</param>
        /// <returns>array van films</returns>
        [AllowAnonymous]
        [HttpGet("GetFilmsByJaar/{jaar}")]
        public IEnumerable<FilmDTO> GetFilmsByJaar(int jaar)
        {
            IEnumerable<FilmDTO> films = _filmRepository.GetFilmsByYear(jaar)
                .Select(film => new FilmDTO()
            {
                FilmID = film.FilmId,
                Titel = film.Titel,
                Jaar = film.Jaar,
                Duur = film.Duur,
                Regisseur = film.Regisseur,
                FilmGenres = film.FilmGenres,
                FilmActeurs = film.FilmActeurs,
                FilmSchrijvers = film.FilmSchrijvers,
                KorteInhoud = film.KorteInhoud,
                Productiebedrijf = film.Productiebedrijf
            }); ;
            if (films == null)
            {
                throw new ArgumentNullException("Geen films");
            }
            return films;
        }

        /// <summary>
        /// Geeft de films met het juiste genre
        /// </summary>
        /// <param name="genre">genre naam</param>
        /// <returns>array van films</returns>
        [AllowAnonymous]
        [HttpGet("GetFilmsByGenre/{genre}")]
        public IEnumerable<FilmDTO> GetFilmsByGenre(string genre)
        {
            IEnumerable<FilmDTO> films = _filmRepository.GetFilmsByGenre(genre)
                .Select(film => new FilmDTO()
                {
                    FilmID = film.FilmId,
                    Titel = film.Titel,
                    Jaar = film.Jaar,
                    Duur = film.Duur,
                    Regisseur = film.Regisseur,
                    FilmGenres = film.FilmGenres,
                    FilmActeurs = film.FilmActeurs,
                    FilmSchrijvers = film.FilmSchrijvers,
                    KorteInhoud = film.KorteInhoud,
                    Productiebedrijf = film.Productiebedrijf
                });
            if (films == null)
            {
                throw new ArgumentNullException("Geen films");
            }
            return films;
        }

        /// <summary>
        /// Geeft alle films met de juiste titel
        /// </summary>
        /// <param name="titel">Titel van de film</param>
        /// <returns>array van films</returns>
        //[HttpGet("GetFilmsByTitle/{titel}")]
        //public IEnumerable<Film> GetFilmsByTitle(string titel)
        //{
        //    IEnumerable<Film> films = _filmRepository.GetFilmsByTitel(titel);
        //    if (string.IsNullOrEmpty(titel))
        //    {
        //        return _filmRepository.GetAllFilms();
        //    }
        //    else
        //    {
        //        return films;
        //    }
        //}
    }
}