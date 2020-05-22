using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using WebappsIV_1920_be_AudreyB.DTOs;
using WebappsIV_1920_be_AudreyB.Models;

namespace WebappsIV_1920_be_AudreyB.Controllers
{

    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]

    public class GebruikerController : ControllerBase
    {
        private readonly IFilmRepository _filmRepository;
        private readonly IGebruikerRepository _gebruikerRepository;

        public GebruikerController(
           IFilmRepository filmContext, IGebruikerRepository gebruikerContext)
        {
            _filmRepository = filmContext;
            _gebruikerRepository = gebruikerContext;

        }


        // GET api/gebruiker/GetGebruiker
        /// <summary>
        /// geeft de details van de geathenticeerde gebruiker
        /// </summary>
        /// <returns>de gebruiker</returns>
        [HttpGet]
        public ActionResult<GebruikerDTO> GetGebruiker()
        {

            Gebruiker gebruiker = _gebruikerRepository.GetGebruikerByEmail(User.Identity.Name);
            return new GebruikerDTO(gebruiker);

        }


        // PUT api/VoegtDuimToe/Titanic
        /// <summary>
        /// Verhoogt aantal duimen met 1
        /// </summary>
        /// <param name="filmtitel">titel van de film</param>
        [HttpPut("VoegtDuimToe/{filmtitel}")]
        //  [Authorize(Policy = "Gebruiker")]
        // [Authorize(Roles = "gebruiker")]
        public IActionResult VoegDuimToe(string filmtitel)
        {

            Gebruiker gebruiker = _gebruikerRepository.GetGebruikerByEmail(User.Identity.Name);

            Film film = _filmRepository.GetFilmByTitel(filmtitel);
            if (film == null)
            {
                return NotFound();
            }
            _gebruikerRepository.VoegDuimToe(film, gebruiker);
            _gebruikerRepository.SaveChanges();
            _filmRepository.SaveChanges();


            return NoContent();
        }

        // PUT api/verwijderdDuim/Titanic
        /// <summary>
        /// Verlaagt aantal duimen met 1
        /// </summary>
        /// <param name="filmtitel">titel van de film</param>
        [HttpPut("VerwijderdDuim/{filmtitel}")]
        //  [Authorize(Policy = "Gebruiker")]
        // [Authorize(Roles = "gebruiker")]
        public IActionResult VerwijderDuim(string filmtitel)
        {

            Gebruiker gebruiker = _gebruikerRepository.GetGebruikerByEmail(User.Identity.Name);

            Film film = _filmRepository.GetFilmByTitel(filmtitel);
            if (film == null)
            {
                return NotFound();
            }
            else
            {
                _gebruikerRepository.VerwijderDuim(film, gebruiker);
                _gebruikerRepository.SaveChanges();
                _filmRepository.SaveChanges();
                return NoContent();
            }
        }

        /// <summary>
        /// verwijderd de film
        /// </summary>
        /// <param name="id">id van film die verwijder wordt</param>
        [HttpDelete("DeleteFilm/{id}")]
        [Authorize(Policy = "Admin")]
        //[Authorize(Roles  = "admin")]
        public IActionResult DeleteFilm(int id)
        {
            IActionResult ar;
            Gebruiker gebruiker = _gebruikerRepository.GetGebruikerByEmail(User.Identity.Name);

            if (gebruiker.IsAdmin)
            {
                Film film = _filmRepository.GetByID(id);
                if (film == null)
                {
                    // return NotFound();
                    ar = NotFound();
                }
                else
                {
                    _filmRepository.Delete(film);
                    _filmRepository.SaveChanges();
                    ar = NoContent();
                    //  return NoContent();
                }
            }
            else
            {
                ar = Unauthorized();
            }
            return ar;
        }

        /// <summary>
        /// Voegt film toe aan lijst van ingelogde gebruiker 
        /// </summary>
        /// <param name="id">id van film</param>
        /// <returns></returns>
        [HttpPut("VoegFilmAanLijst/{id}")]
        public IActionResult VoegFilmToeAanEigenLijst(int id)
        {
            Film film = _filmRepository.GetByID(id);
            Gebruiker gebruiker = _gebruikerRepository.GetGebruikerByEmail(User.Identity.Name);
            if (film == null)
            {
                return NotFound();

            }
            else
            {
                _gebruikerRepository.VoegFilmToeAanEigenLijst(film, gebruiker);
                _gebruikerRepository.SaveChanges();
                _filmRepository.SaveChanges();
                return NoContent();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// 
        [HttpGet("GetEigenLijstFilms")]
        public IEnumerable<FilmDTO> GetEigenLijstFilms()
        {
            Gebruiker gebruiker = _gebruikerRepository.GetGebruikerByEmail(User.Identity.Name);
            IEnumerable<FilmDTO> films = gebruiker.GebruikerFilmLijst.Select(
                film => new FilmDTO()
                {
                    FilmID = film.Film.FilmId,
                    Titel = film.Film.Titel,
                    Jaar = film.Film.Jaar,
                    Duur = film.Film.Duur,
                    Regisseur = film.Film.Regisseur,
                    FilmGenres = film.Film.FilmGenres,
                    FilmActeurs = film.Film.FilmActeurs,
                    FilmSchrijvers = film.Film.FilmSchrijvers,
                    KorteInhoud = film.Film.KorteInhoud,
                    Productiebedrijf = film.Film.Productiebedrijf
                });
            if (films == null)
            {
                //  return NoContent();
                throw new ArgumentNullException("Geen films");
            }
            else { return films; }

            /*  IEnumerable<FilmDTO> films = _gebruikerRepository.GetEigenLijstFilms()
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
          }*/
        }
    }
}