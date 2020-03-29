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
        public int Duur { get; set; }
        [JsonIgnore]
        public ICollection<FilmGenre> FilmGenres { get; set; }
        [JsonIgnore]
        public ICollection<FilmSchrijver> FilmSchrijvers { get; set; }
        [JsonIgnore]
        public ICollection<FilmActeur> FilmActeurs { get; set; }
        public string Regisseur { get; set; }
        public string KortInhoud { get; set; }
        public string Productiebedrijf { get; set; }
        public int Jaar { get; set; }
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
            this.KortInhoud = korteInhoud;
            this.Productiebedrijf = productiebedrijf;
            this.FilmGenres = new List<FilmGenre>();
            this.FilmSchrijvers = new List<FilmSchrijver>();
            this.FilmActeurs = new List<FilmActeur>();
        }
        #endregion

        #region Methods

        #endregion
    }
}
