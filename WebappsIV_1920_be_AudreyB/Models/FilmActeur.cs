using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebappsIV_1920_be_AudreyB.Models
{
    public class FilmActeur
    {
        #region Fields
        private int _filmID;
        private int _acteurID;
        private string _acteurNaam;
        #endregion

        #region Properties
        [JsonIgnore]
        public Film Film { get; set; }
        [JsonIgnore]
        public Acteur Acteur { get; set; }
        public int FilmID
        {
            get { return _filmID; }
            set { _filmID = Film.FilmId; }
        }
        public int ActeurID
        {
            get { return _acteurID; }
            set { _acteurID = Acteur.ActeurID; }
        }
        public string ActeurNaam
        {
            get { return _acteurNaam; }
            set { _acteurNaam = Acteur.Acteurnaam; }
        }
        #endregion

        #region Constructors
        public FilmActeur() { }
        public FilmActeur(Film film, Acteur acteur)
        {
            this.Film = film;
            this.Acteur = acteur;
            this._acteurNaam = Acteur.Acteurnaam;
        }
        #endregion
    }
}
