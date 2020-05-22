using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebappsIV_1920_be_AudreyB.Models
{
    public class Gebruiker
    {
        
        #region Properties
        public int GebruikerID { get; set; }
        public string Voornaam { get; set; }
        public string Familienaam { get; set; }
        public string Mailadres { get; set; }
        public bool IsAdmin { get; set; }
        public ICollection<FilmGebruiker> FilmGebruikers { get; private set; }
        public ICollection<GebruikerFilmLijst> GebruikerFilmLijst { get; private set; }
       
        #endregion

        #region Constructors
        public Gebruiker() { }
        public Gebruiker(string voornaam, string familienaam, string mailadres)
        {
            this.Voornaam = voornaam;
            this.Familienaam = familienaam;
            this.Mailadres = mailadres;
            this.FilmGebruikers = new List<FilmGebruiker>();
            this.GebruikerFilmLijst = new List<GebruikerFilmLijst>();
        }


        #endregion


        #region Methods
        internal void VoegFilmToe(Film film)
        {
            if (GebruikerFilmLijst.Count()==0)
            {
                GebruikerFilmLijst fgebruiker = new GebruikerFilmLijst(film, this) { Film=film};
                film.GebruikerFilmLijst.Add(fgebruiker);
                GebruikerFilmLijst.Add(fgebruiker);
            }
            else
            {
                foreach (GebruikerFilmLijst fg in GebruikerFilmLijst)
                {
                    if (fg.Film/*2*/.Equals(film))
                    {
                        // misschien verwijderen uit lijst

                    }
                    else
                    {
                        // Film toevoegen aan lijst
                        GebruikerFilmLijst fgebruiker = new GebruikerFilmLijst(film, this);
                        film.GebruikerFilmLijst.Add(fgebruiker);
                        GebruikerFilmLijst.Add(fgebruiker);
                        break;
                    }
                }
                #endregion
            }
        }
    }
}

