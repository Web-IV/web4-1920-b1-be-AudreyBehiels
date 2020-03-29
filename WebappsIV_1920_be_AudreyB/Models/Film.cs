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
        // public ICollection<string> Genre { get; set; }
        public ICollection<FilmGenre> FilmGenres { get; set; }
        public ICollection<FilmSchrijver> FilmSchrijvers { get; set; }
        public ICollection<FilmActeur> FilmActeurs { get; set; }
        //public virtual ICollection<Genre> Genres { get; set; }
        //public virtual ICollection<Schrijver> Schrijvers { get; set; }
        //public ICollection<string> Acteurs { get; set; }
        public string Regisseur { get; set; }
        // public ICollection<string> Schrijvers { get; set; }
        public string KortInhoud { get; set; }
        public string Productiebedrijf { get; set; }
        public int Jaar { get; set; }
        // Film affiche  
        #endregion

        #region Contructors
        public Film() { }
        public Film(string titel, int jaar, int duur,/* ICollection<string> genre, List<string> acteurs, */ string regisseur, /*List<string> schrijvers,*/ string korteInhoud, string productiebedrijf)
        {
            this.Titel = titel;
            this.Jaar = jaar;
            this.Duur = duur;
            //  this.Genre = genre;
            //this.Acteurs = acteurs;
            this.Regisseur = regisseur;
            //this.Schrijvers = schrijvers;
            this.KortInhoud = korteInhoud;
            this.Productiebedrijf = productiebedrijf;
            this.FilmGenres = new List<FilmGenre>();
            this.FilmSchrijvers = new List<FilmSchrijver>();
            this.FilmActeurs = new List<FilmActeur>();
            //    this.Genres = new List<Genre>();
            //    this.Schrijvers = new List<Schrijver>();
        }

        #endregion

        #region Methods

        #endregion
    }
}
