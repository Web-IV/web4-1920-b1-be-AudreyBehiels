using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebappsIV_1920_be_AudreyB.Models;

namespace WebappsIV_1920_be_AudreyB.Data.Repository
{
    public class FilmRepository : IFilmRepository
    {
        #region Properties
        private readonly FilmContext _filmContext;
        private readonly DbSet<Film> _films;

        #endregion

        #region Constructor
        public FilmRepository(FilmContext dbFilmContext)
        {
            _filmContext = dbFilmContext;
            _films = dbFilmContext.Films;
        }
        #endregion

        #region Methods
        public IEnumerable<Film> GetAllFilms()
        {
            return _films.Include(fg => fg.FilmGenres).ThenInclude(g => g.Genre)
                .Include(fs => fs.FilmActeurs).ThenInclude(a => a.Acteur)
               .Include(fs => fs.FilmSchrijvers).ThenInclude(s => s.Schrijver)
                .ToList();
        }

        public Film GetFilmByTitel(string titel)
        {
            return _films.Include(f => f.FilmGenres).ThenInclude(fg => fg.Genre)
                .Include(f => f.FilmActeurs).ThenInclude(fa => fa.Acteur)
                 .Include(f => f.FilmSchrijvers).ThenInclude(fs => fs.Schrijver)
                .SingleOrDefault(f => f.Titel.ToLower().Equals(titel.ToLower()));

        }

        public IEnumerable<Film> GetFilmsByTitel(string titel)
        {
            return _films.Include(fg => fg.FilmGenres).ThenInclude(g => g.Genre)
                .Include(fs => fs.FilmActeurs).ThenInclude(a => a.Acteur)
               .Include(fs => fs.FilmSchrijvers).ThenInclude(s => s.Schrijver)
                .Where(s => s.Titel.ToLower().Equals(titel.ToLower())).ToList();
        }

        public IEnumerable<Film> GetFilmsByGenre(string genre)
        {

            ICollection<Film> films = new List<Film>();
            foreach (var film in _films.Include(fg => fg.FilmGenres).ThenInclude(g => g.Genre)
             .Include(fs => fs.FilmActeurs).ThenInclude(a => a.Acteur)
             .Include(fs => fs.FilmSchrijvers).ThenInclude(s => s.Schrijver))
            {
                foreach (var f in film.FilmGenres)
                {
                    if (f.GenreNaam.Equals(genre))
                    {
                        films.Add(f.Film);
                    }
                }
            }
            return films.ToList();
        }

        public IEnumerable<Film> GetFilmsByYear(int jaar)
        {
            return _films.Include(fg => fg.FilmGenres).ThenInclude(g => g.Genre)
                .Include(fs => fs.FilmActeurs).ThenInclude(a => a.Acteur)
               .Include(fs => fs.FilmSchrijvers).ThenInclude(s => s.Schrijver)
               .Where(s => s.Jaar.Equals(jaar)).ToList();
        }

        public void SaveChanges()
        {
            _filmContext.SaveChanges();
        }

        #endregion
    }
}
