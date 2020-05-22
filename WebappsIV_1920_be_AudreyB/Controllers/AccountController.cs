using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using WebappsIV_1920_be_AudreyB.DTOs;
using WebappsIV_1920_be_AudreyB.Models;

namespace WebappsIV_1920_be_AudreyB.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    public class AccountController : ControllerBase
    {

        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IConfiguration _config;

        //private readonly IFilmRepository _filmRepository;
        private readonly IGebruikerRepository _gebruikerRepository;
      
        public AccountController(
           SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IConfiguration config,
           /*IFilmRepository filmContext,*/ IGebruikerRepository gebruikerContext)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _config = config;
           // _filmRepository = filmContext;
            _gebruikerRepository = gebruikerContext;

        }

        /// <summary>
        /// inloggen van gebruiker
        /// </summary>
        /// <param name="model">de login details</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<string>> Login(LoginDTO model) // inloggen //AanmakenToken
        {
            var gebruiker = await _userManager.FindByNameAsync(model.Mailadres);
            if (gebruiker != null)
            {
               
                var result = await _signInManager.CheckPasswordSignInAsync(gebruiker, model.Wachtwoord, false);
                if (result.Succeeded)
                {
                    string token = GetToken(gebruiker);
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
            var token = new JwtSecurityToken(null, null, claims, expires: DateTime.Now.AddMinutes(60), signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        /// <summary>
        /// registreer een gebruiker
        /// </summary>
        /// <param name="model">de gebruiker details</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("registreer")]
        public async Task<ActionResult<string>> Registreer(RegistreerDTO model)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = model.Mailadres,
                Email = model.Mailadres
            };
            Gebruiker gebruiker = new Gebruiker { Mailadres = model.Mailadres, Voornaam = model.Voornaam, Familienaam = model.Familienaam };
            var result = await _userManager.CreateAsync(user, model.Wachtwoord);
            if (result.Succeeded)
            {
               var resultaat = await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "gebruiker"));
                if (resultaat.Succeeded) { 
                _gebruikerRepository.ToevoegenGebruiker(gebruiker);

                _gebruikerRepository.SaveChanges();
                string token = GetToken(user);
                return Created("", token);
             }
            }
            return BadRequest();
        }
        /// <summary>
        /// Kijkt na of het emailadres van de gebruiker al bestaat 
        /// </summary>
        /// <returns>true als het emailadres nog niet geregistreerd is</returns>
        /// <param name="email">mailadres</param>/
        [AllowAnonymous]
        [HttpGet("checkusername")]
        public async Task<ActionResult<Boolean>> CheckAvailableUserName(string email)
        {
            var user = await _userManager.FindByNameAsync(email);
            return user == null;
        }

    }
}