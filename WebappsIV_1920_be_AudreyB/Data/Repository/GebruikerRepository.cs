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

        #region Constructor
        public GebruikerRepository(FilmContext dbFilmContext)
        {
            _filmContext = dbFilmContext;
            _films = dbFilmContext.Films;
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

        public void SaveChanges()
        {
            _filmContext.SaveChanges();

        }
      /*  public void AddFilmToOwnList(string titel)
        {

        }*/
    }
}
