using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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

        public FilmsController(IFilmRepository context)
        {
            _filmRepository = context;
        }

        // GET: api/Films
        /// <summary>
        /// geeft alle films 
        /// </summary>
        /// <returns>array van films</returns>
        [HttpGet("GetFilms")]
        public IEnumerable<Film> GetFilms()
        {
            return _filmRepository.GetAllFilms();
        }

        //GET: api/Films/GetFilmByTitle/Titanic
        /// <summary>
        /// geeft de film met de gegeven titel
        /// </summary>
        /// <param name="titel">Titel van de film</param>
        /// <returns>De film</returns>
        [HttpGet("GetFilmByTitle/{titel}")]
        public ActionResult<Film> GetFilmByTitle(string titel)
        {
            Film film = _filmRepository.GetFilmByTitel(titel);
            if (film == null)
            {
                return NotFound();
            }
            else
            {
                return film;
            }
        }

        /// <summary>
        /// Geeft alle films met het juiste jaar
        /// </summary>
        /// <param name="jaar">jaar van de film</param>
        /// <returns>array van films</returns>
        [HttpGet("GetFilmsByJaar/{jaar}")]
        public IEnumerable<Film> GetFilmsByJaar(int jaar)
        {
          return _filmRepository.GetFilmsByYear(jaar);
            
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