using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebappsIV_1920_be_AudreyB.Models
{
    
    public class FilmGenre
    {
        #region Fields
        private int _filmID;
        private int _genreID;
         private string _genreNaam;
        #endregion

        #region Properties
            [JsonIgnore]
        public Film Film { get; set; }
        [JsonIgnore]
        public Genre Genre { get; set; }
        [JsonIgnore]
        public int FilmID
        {
            get { return _filmID; }
            set { _filmID = Film.FilmId; }
        }
        [JsonIgnore]
        public int GenreID
        {
            get { return _genreID; }
            set { _genreID = Genre.GenreID; }
        }
        
        public string GenreNaam
        {
            get { return _genreNaam; }
            set { _genreNaam = Genre.Naam; }
        }
        #endregion

        #region Constructors
        public FilmGenre() { }
        
        public FilmGenre(Film film, Genre genre)
        {
            this.Film = film;
            this.Genre = genre;
            this._genreNaam = Genre.Naam;
        }

        #endregion
    }
}

