using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using WebappsIV_1920_be_AudreyB.Models;

namespace WebappsIV_1920_be_AudreyB.Data.Repository
{
    public class GebruikerRepository : IGebruikerRepository
    {
        #region Properties
        private readonly FilmContext _filmContext;
        //private readonly DbSet<Film> _films;
        private readonly DbSet<Gebruiker> _gebruikers;

        #region Constructor
        public GebruikerRepository(FilmContext dbFilmContext)
        {
            _filmContext = dbFilmContext;
            //_films = dbFilmContext.Films;
            _gebruikers = dbFilmContext.Gebruikers;
        }
        #endregion

        #endregion
        public void VoegDuimToe(Film film, Gebruiker g)
        {
            
            film.VoegDuimToe(g);
           
         
        }
        public void VerwijderDuim(Film film, Gebruiker g)
        { 
            film.VerwijderDuim(g);
        }

        public void ToevoegenGebruiker(Gebruiker gebruiker)
        {
            //_filmContext.Gebruikers.Add(gebruiker);
           _gebruikers.Add(gebruiker);
        }
        public void SaveChanges()
        {
            _filmContext.SaveChanges();

        }


        public Gebruiker GetGebruikerByEmail(string mailadres)
        {
              return _gebruikers.Include(g => g.FilmGebruikers).ThenInclude(g => g.Gebruiker)
                .Include(g => g.GebruikerFilmLijst).ThenInclude(g => g.Gebruiker)
                .Include(f => f.GebruikerFilmLijst).ThenInclude(f => f.Film)
                .Include(f => f.GebruikerFilmLijst).ThenInclude(f => f.Film.FilmGenres)
                .Include(f => f.GebruikerFilmLijst).ThenInclude(f => f.Film.FilmActeurs)
                .Include(f => f.GebruikerFilmLijst).ThenInclude(f => f.Film.FilmSchrijvers)
                .Include(f => f.GebruikerFilmLijst).ThenInclude(f => f.Film.GebruikerFilmLijst)
                .SingleOrDefault(g => g.Mailadres == mailadres);
        }

        public void VoegFilmToeAanEigenLijst(Film film, Gebruiker gebruiker)
        {
            
            gebruiker.VoegFilmToe(film);

        }

       /* public IEnumerable<Film> GetEigenLijstFilms(string mailadres)
        {
           return _gebruikers.Include(g=> g.FilmGebruikers).ThenInclude(g => g.Gerbuiker)
                 .Include(g => g.GebruikerFilmLijst).ThenInclude(g => g.Gebruiker).Where()
        }*/
    }
}
