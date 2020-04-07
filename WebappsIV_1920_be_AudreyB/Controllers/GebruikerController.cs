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
    public class GebruikerController : ControllerBase
    {

        private readonly IFilmRepository _filmRepository;
        private readonly IGebruikerRepository _gebruikerRepository;

        public GebruikerController(IFilmRepository filmContext, IGebruikerRepository gebruikerContext)
        {
            _filmRepository = filmContext;
            _gebruikerRepository = gebruikerContext;

        }

        // PUT api/VoegtDuimToe/Titanic
        /// <summary>
        /// Verhoogt aantal duimen met 1
        /// </summary>
        /// <param name="filmtitel">titel van de film</param>
        [HttpPut("VoegtDuimToe/{filmtitel}")]
        public IActionResult VoegDuimToe(string filmtitel)
        {
            Film film = _filmRepository.GetFilmByTitel(filmtitel);
            if (film == null)
            {
                return NotFound();
            }

            _gebruikerRepository.VoegDuimToe(film);
            _gebruikerRepository.SaveChanges();
            return NoContent();

        }

        // PUT api/verwijderdDuim/Titanic
        /// <summary>
        /// Verlaagt aantal duimen met 1
        /// </summary>
        /// <param name="filmtitel">titel van de film</param>
        [HttpPut("VerwijderdDuim/{filmtitel}")]
        public IActionResult VerwijderDuim(string filmtitel)
        {

            Film film = _filmRepository.GetFilmByTitel(filmtitel);
            if (film == null)
            {
                return NotFound();
            }
            _gebruikerRepository.VerwijderDuim(film);
            _gebruikerRepository.SaveChanges();
            return NoContent();
        }
    }
}