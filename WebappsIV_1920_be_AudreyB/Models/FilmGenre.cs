using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebappsIV_1920_be_AudreyB.Models
{
    
    public class FilmGenre
    {
        #region Fields
        private int _filmID;
        private int _genreID;
        // private string _filmTitel;
        // private string _genreNaam;
        #endregion

        #region Properties
        public Film Film { get; set; }
        public Genre Genre { get; set; }
        public int FilmID
        {
            get { return _filmID; }
            set { _filmID = Film.FilmId; }
        }
        public int GenreID
        {
            get { return _genreID; }
            set { _genreID = Genre.GenreID; }
        }
      /*  public string FilmTitel
        {
            get { return _filmTitel; }
            set { _filmTitel = Film.Titel; }
        }
        public string GenreNaam
        {
            get { return _genreNaam; }
            set { _genreNaam = Genre.Naam; }
        }*/
        #endregion

        #region Constructors
        public FilmGenre() { }
        public FilmGenre(Film film, Genre genre)
        {
            this.Film = film;
            this.Genre = genre;
        }

        #endregion
    }
}

