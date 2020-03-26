using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebappsIV_1920_be_AudreyB.Data
{
    public class FilmDataInitializer
    {
        private readonly FilmContext _dbFilmContext;

        public FilmDataInitializer(FilmContext dbFilmContext)
        {
            _dbFilmContext = dbFilmContext;

        }
        public void InitializeData()
        {
            _dbFilmContext.Database.EnsureDeleted();
            if (_dbFilmContext.Database.EnsureCreated())
            {

            }
        }
    }
}
