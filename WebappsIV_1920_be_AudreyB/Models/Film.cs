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
        public ICollection<FilmGebruiker> FilmGebruikers { get;  set; }
        public ICollection<GebruikerFilmLijst> GebruikerFilmLijst { get; set; }
        public string Productiebedrijf { get; set; }
        public string KorteInhoud { get; set; }
        public int AantalDuimenOmhoog { get; set; }
        

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
            this.FilmGebruikers = new List<FilmGebruiker>();
            this.GebruikerFilmLijst = new List<GebruikerFilmLijst>();
            this.AantalDuimenOmhoog = 0;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Aantal duimen met 1 verhogen
        /// </summary>
        public void VoegDuimToe(Gebruiker g)
        {
            
                FilmGebruiker filmGebruiker = new FilmGebruiker(this, g);
            if (FilmGebruikers.Count() == 0)
            {
                g.FilmGebruikers.Add(filmGebruiker);
                FilmGebruikers.Add(filmGebruiker);
                AantalDuimenOmhoog++;
            }
            else
            {
                foreach (FilmGebruiker fg in FilmGebruikers)
                {
                    if (fg.Film.Equals(filmGebruiker.Film))
                    {

                    }
                    else
                    {

                        g.FilmGebruikers.Add(filmGebruiker);
                        FilmGebruikers.Add(filmGebruiker);
                        AantalDuimenOmhoog++;
                    }
                }
                /*if (g.FilmGebruikers.Contains(filmGebruiker))
                {
                    throw new InvalidOperationException("De gebruiker heeft al een thumbs up gegevens");
                }
                else
                {

                    g.FilmGebruikers.Add(filmGebruiker);
                    FilmGebruikers.Add(filmGebruiker);
                    AantalDuimenOmhoog++;
                }*/
            }
        }
        public void VerwijderDuim(Gebruiker g)
        {
            if (AantalDuimenOmhoog == 0)
            {
                throw new Exception("Je kan de score van de het aantal duimen niet onder 0 laten zakken.");
            } else {
                FilmGebruiker fg = FilmGebruikers.SingleOrDefault(gebruiker => gebruiker.Gebruiker.Equals(g));

                if (FilmGebruikers.Contains(fg))
                {
                    g.FilmGebruikers.Remove(fg);
                    FilmGebruikers.Remove(fg);
                    AantalDuimenOmhoog--;
                }
            }
        }
        #endregion
    }
}
