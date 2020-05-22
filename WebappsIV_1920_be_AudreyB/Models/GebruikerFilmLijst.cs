using System;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebappsIV_1920_be_AudreyB.Models
{
    public class GebruikerFilmLijst
    {

        #region Fields
        private int _filmID;
        private int _gebruikerID;
        private string _gebruikerNaam;
        
        #endregion

        #region Properties

        [JsonIgnore]
        public Film Film { get; set; }

        [JsonIgnore]
        public Gebruiker Gebruiker { get; set; }

        [JsonIgnore]
        public int FilmID
        {
            get { return _filmID; }
            set { _filmID = Film.FilmId; }
        }

        [JsonIgnore]
        public int GebruikerID
        {
            get { return _gebruikerID; }
            set { _gebruikerID = Gebruiker.GebruikerID; }
        }

        public string GebruikerNaam
        {
            get { return _gebruikerNaam; }
            set => _gebruikerNaam = string.Format(Gebruiker.Voornaam + ' ' + Gebruiker.Familienaam);
        }
        #endregion

        #region Constructors
        public GebruikerFilmLijst() { }
        public GebruikerFilmLijst(Film film, Gebruiker gebruiker)
        {

            Film = film;
            FilmID = film.FilmId;
            Gebruiker = gebruiker;
            GebruikerID = gebruiker.GebruikerID;
            GebruikerNaam = gebruiker.Voornaam + ' ' + gebruiker.Familienaam;

        }
        #endregion
    }
}



