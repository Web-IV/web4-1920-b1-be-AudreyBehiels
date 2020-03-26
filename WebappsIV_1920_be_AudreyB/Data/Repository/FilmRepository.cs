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
            return _films.ToList();
        }

        public IEnumerable<Film> GetFilmsByTitel(string titel)
        {
            return _films.Where(s => s.Titel.ToLower().Contains(titel.ToLower())).ToList();
        }

        public IEnumerable<Film> GetFilmsByGenre(string genre)
        {
            return _films.Where(s => s.Genre.Equals(genre)).ToList();
        }

        public IEnumerable<Film> GetFilmsByYear(DateTime jaar)
        {
            return _films.Where(s => s.Jaar.Equals(jaar)).ToList();
        }

        public void SaveChanges()
        {
            _filmContext.SaveChanges();
        }
        #endregion
    }
}
