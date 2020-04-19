using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebappsIV_1920_be_AudreyB.Models
{
    public class FilmGebruiker
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
            set { _gebruikerNaam = string.Format(Gebruiker.Voornaam + ' ' + Gebruiker.Familienaam); }
        } 
        #endregion

        #region Constructors
        public FilmGebruiker()
        {

        }
        public FilmGebruiker(Film film, Gebruiker gebruiker)
        {
            this.Film = film;
            this.Gebruiker = gebruiker;
            this.GebruikerNaam = gebruiker.Voornaam + ' ' + gebruiker.Familienaam;

        } 
        #endregion
    }
}
