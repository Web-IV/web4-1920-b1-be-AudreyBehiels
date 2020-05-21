using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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
        private readonly UserManager<IdentityUser> _userManager;

        public GebruikerController(
           IFilmRepository filmContext, IGebruikerRepository gebruikerContext )
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
        [AllowAnonymous]
        /*[Authorize(Policy = "Gebruiker")]
        [Authorize(Policy = "Admin")]*/
        public IActionResult VoegDuimToe(string filmtitel/*, LoginDTO login*/)
        {
           var var =  _userManager.Options.User;

          
            // Gebruiker g = _gebruikerRepository.GetGebruikerByEmail(login.Mailadres);
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
      [AllowAnonymous]
       /* [Authorize(Policy = "Gebruiker")]
        [Authorize(Policy = "Admin")]*/
        public IActionResult VerwijderDuim(string filmtitel/*, LoginDTO login*/)
        {

            //Gebruiker g = _gebruikerRepository.GetGebruikerByEmail(login.Mailadres);
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
         [AllowAnonymous]
        /*[Authorize(Policy = "Admin")]*/
        //[Authorize(Roles  = "Admin, Gebruiker")]
        public IActionResult DeleteFilm(int id/*, LoginDTO login*/)
        {
            
            // User user = _UserManager.GetUserAsync(HttpContext.User);
            IActionResult ar= null;
            //Gebruiker gebruiker = _gebruikerRepository.GetGebruikerByEmail(login.Mailadres);
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
            return ar;
        }

    }
}