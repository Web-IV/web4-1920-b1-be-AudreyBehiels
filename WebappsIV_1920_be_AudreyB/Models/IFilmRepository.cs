using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebappsIV_1920_be_AudreyB.Models
{
    public interface IFilmRepository
    {
        IEnumerable<Film> GetAllFilms();
        IEnumerable<Film> GetFilmsByTitel(string titel);
        IEnumerable<Film> GetFilmsByYear(DateTime jaar);
        IEnumerable<Film> GetFilmsByGenre(string genre);

        void SaveChanges();
    }
}
