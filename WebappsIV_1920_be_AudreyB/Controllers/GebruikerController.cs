using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebappsIV_1920_be_AudreyB.DTOs;
using WebappsIV_1920_be_AudreyB.Models;

namespace WebappsIV_1920_be_AudreyB.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class GebruikerController : ControllerBase
    {

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
       // private readonly ICustomerRepository _customerRepository;
        private readonly IConfiguration _config;

        private readonly IFilmRepository _filmRepository;
        private readonly IGebruikerRepository _gebruikerRepository;

        public GebruikerController(
           SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager,/* ICustomerRepository customerRepository,*/ IConfiguration config,
           IFilmRepository filmContext, IGebruikerRepository gebruikerContext)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        //    _customerRepository = customerRepository;
            _config = config;
            _filmRepository = filmContext;
            _gebruikerRepository = gebruikerContext;

        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<String>> CreateToken(LoginDTO model)
        {
            var user = await _userManager.FindByNameAsync(model.Email);
            if (user != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);
                if (result.Succeeded)
                {
                    string token = GetToken(user);
                    return Created("", token); //returns only the token                
                }
            }
            return BadRequest();
        }

        private String GetToken(IdentityUser user)
        {      // Create the token
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
            };
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(null, null, claims, expires: DateTime.Now.AddMinutes(30), signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
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