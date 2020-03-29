using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebappsIV_1920_be_AudreyB.Models
{
    public class Genre
    {
        #region Properties
        public int GenreID { get; set; }
        public string Naam { get; set; }
        public ICollection<FilmGenre> FilmGenres { get; set; }
       // public virtual ICollection<Film> Films { get; set; }

        #endregion

        public Genre(){}
        public Genre(string naam)
        {
            this.Naam = naam;
            this.FilmGenres = new List<FilmGenre>();
           // this.Films = new List<Film>();

        }

    }


}
