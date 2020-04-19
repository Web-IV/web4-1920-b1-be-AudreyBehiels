using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebappsIV_1920_be_AudreyB.Models
{
    public class Film
    {
        #region Properties
        public int FilmId { get; set; }

        [Required]
        public string Titel { get; set; } 
        public int Jaar { get; set; }
        public int Duur { get; set; } 
        public string Regisseur { get; set; }
        public ICollection<FilmGenre> FilmGenres { get; set; }
        public ICollection<FilmSchrijver> FilmSchrijvers { get; set; }
        public ICollection<FilmActeur> FilmActeurs { get; set; }
        public string Productiebedrijf { get; set; }
        public string KorteInhoud { get; set; }
        public int AantalDuimenOmhoog { get; set; }
        public ICollection<FilmGebruiker> FilmGebruikers { get;  set; }

        // Film affiche  
        #endregion

        #region Contructors
        public Film() { }
        public Film(string titel, int jaar, int duur,string regisseur,  string korteInhoud, string productiebedrijf)
        {
            this.Titel = titel;
            this.Jaar = jaar;
            this.Duur = duur;
            this.Regisseur = regisseur;
            this.KorteInhoud = korteInhoud;
            this.Productiebedrijf = productiebedrijf;
            this.FilmGenres = new List<FilmGenre>();
            this.FilmSchrijvers = new List<FilmSchrijver>();
            this.FilmActeurs = new List<FilmActeur>();
            this.AantalDuimenOmhoog = 0;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Aantal duimen met 1 verhogen
        /// </summary>
        public void VoegDuimToe()
        {
            
                /*FilmGebruiker filmGebruiker = new FilmGebruiker(this, gebruiker);
                gebruiker.FilmGebruikers.Add(filmGebruiker);
                FilmGebruikers.Add(filmGebruiker);*/
                AantalDuimenOmhoog++;

        }
        public void VerwijderDuim()
        {
            if(AantalDuimenOmhoog == 0)
            {
                throw new Exception("Je kan de score van de het aantal duimen niet onder 0 laten zakken.");
            } else if (AantalDuimenOmhoog >= 1)
            {
                AantalDuimenOmhoog--;
            }
        }
        #endregion
    }
}
