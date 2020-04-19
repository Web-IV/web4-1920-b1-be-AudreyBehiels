using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebappsIV_1920_be_AudreyB.Models;

namespace WebappsIV_1920_be_AudreyB.Data.Repository
{
    public class GebruikerRepository : IGebruikerRepository
    {
        #region Properties
        private readonly FilmContext _filmContext;
        private readonly DbSet<Film> _films;
        private readonly DbSet<Gebruiker> _gebruikers;

        #region Constructor
        public GebruikerRepository(FilmContext dbFilmContext)
        {
            _filmContext = dbFilmContext;
            _films = dbFilmContext.Films;
            _gebruikers = dbFilmContext.Gebruikers;
        }
        #endregion

        #endregion
        public void VoegDuimToe(Film film)
        {
            film.VoegDuimToe();
           
         
        }
        public void VerwijderDuim(Film film)
        { 
            film.VerwijderDuim();
        }

        public void ToevoegenGebruiker(Gebruiker gerbuiker)
        {
            _filmContext.Gebruikers.Add(gerbuiker);
           // _gebruikers.Add(gerbuiker);
        }
        public void SaveChanges()
        {
            _filmContext.SaveChanges();

        }


        public Gebruiker GetGebruikerByEmail(string mailadres)
        {
            return _filmContext.Gebruikers.SingleOrDefault(g => g.Mailadres.Equals(mailadres));
        }

        /*  public void AddFilmToOwnList(string titel)
 {

 }*/
    }
}
