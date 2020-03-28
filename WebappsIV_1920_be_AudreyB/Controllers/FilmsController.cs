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
        /// <returns>array of films</returns>
        [HttpGet]
        public IEnumerable<Film> GetFilms()
        {

            return _filmRepository.GetAllFilms();
        }

        /// <summary>
        /// Geeft alle films met de juiste titel
        /// </summary>
        /// <param name="titel">Titel van de film</param>
        /// <returns>array van films met juist titel</returns>
        [HttpGet("titel")]
        public IEnumerable<Film> GetFilmsByTitle(string titel)
        {
            IEnumerable<Film> films = _filmRepository.GetFilmsByTitel(titel);
            if(string.IsNullOrEmpty(titel))
            {
                return _filmRepository.GetAllFilms();
            } else
            {
                return films;
            }

        }
    }
}