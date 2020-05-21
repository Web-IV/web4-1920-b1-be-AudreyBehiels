using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authentication.JwtBearer;
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
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class FilmsController : ControllerBase
    {
        private readonly IFilmRepository _filmRepository;

        public FilmsController(IFilmRepository context)
        {
            _filmRepository = context;
        }

        // GET: api/Films
        /// <summary>
        /// Geeft alle films 
        /// </summary>
        /// <returns>array van films</returns>
        [HttpGet("")]
        [AllowAnonymous]
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
        [HttpGet("GetGenres")]
        [AllowAnonymous]
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
        [HttpGet("GetFilmByTitle/{titel}")]
        [AllowAnonymous]
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

        //GET: api/Films/GetFilmByTitleStartsWith/Ti
        /// <summary>
        /// geeft de films die starten met de gegeven letters
        /// </summary>
        /// <param name="titel">Titel van de film</param>
        /// <returns>array van films</returns>
        [HttpGet("GetFilmsByTitleStartsWith/{titel}")]
        [AllowAnonymous]
        public IEnumerable<FilmDTO> GetFilmsByTitleStartsWith(string titel)
        {
            IEnumerable<FilmDTO> films = _filmRepository.GetFilmsByTitelStartsWith(titel)
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

        //GET: api/Films/GetFilmByJaar/1984
        /// <summary>
        /// Geeft alle films met het juiste jaar
        /// </summary>
        /// <param name="jaar">jaar van de film</param>
        /// <returns>array van films</returns>
        [HttpGet("GetFilmsByJaar/{jaar}")]
        [AllowAnonymous]
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
        [HttpGet("GetFilmsByGenre/{genre}")]
        [AllowAnonymous]
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
        
    }
}