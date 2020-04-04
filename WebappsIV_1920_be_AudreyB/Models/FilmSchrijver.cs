using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

using System.Threading.Tasks;

namespace WebappsIV_1920_be_AudreyB.Models
{
    public class FilmSchrijver
    {
        #region Fields
        private int _filmID;
        private int _schrijverID;
        private string _schrijverNaam;

        #endregion

        #region Properties
            [JsonIgnore]
        public Film Film { get; set; }
        [JsonIgnore]
        public Schrijver Schrijver { get; set; }
        [JsonIgnore]
        public int FilmID
        {
            get { return _filmID; }
            set { _filmID = Film.FilmId; }
        }
        [JsonIgnore]
        public int SchrijverID
        {
            get { return _schrijverID; }
            set { _schrijverID = Schrijver.SchrijverID; }
        }
        public string SchrijverNaam
        {
            get { return _schrijverNaam; }
            set { _schrijverNaam = Schrijver.Naam; }
        }
        #endregion

        #region Constructors
        public FilmSchrijver() { }

        public FilmSchrijver(Film film, Schrijver schrijver)
        {
            this.Film = film;
            this.Schrijver = schrijver;
            this._schrijverNaam = Schrijver.Naam;
          
        }
        #endregion
    }
}
