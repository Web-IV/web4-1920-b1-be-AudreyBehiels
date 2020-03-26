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
        public int Id { get; set; }

        [Required]
        public string Titel { get; set; }
        public DateTime Duur { get; set; }
        public ICollection<Genre> Genre { get; set; }
        public ICollection<string> Acteurs { get; set; }
        public string Regiseur { get; set; }
        public ICollection<string> Schrijvers { get; set; }
        public string KortInhoud { get; set; }
        public string Productie { get; set; }
        public DateTime Jaar { get; set; }
        // Film affiche  
        #endregion

        #region Contructors
        public Film()
        {

        }
        public Film(string titel, DateTime jaar, DateTime duur, ICollection<Genre> genre, List<String> acteurs, string regiseur, List<string> schrijvers, string korteInhoud, string productie)
        {
            this.Titel = titel;
            this.Jaar = jaar;
            this.Duur = duur;
            this.Genre = genre;
            this.Acteurs = acteurs;
            this.Regiseur = regiseur;
            this.Schrijvers = schrijvers;
            this.KortInhoud = korteInhoud;
            this.Productie = productie;
        }
        #endregion

        #region Methods

        #endregion
    }
}
