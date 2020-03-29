using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebappsIV_1920_be_AudreyB.Models
{
    public class Acteur
    {
        #region Prpoperties
        public int ActeurID { get; set; }
        public string Acteurnaam { get; set; }
        public Film Film { get; set; }
        [JsonIgnore]
        public ICollection<FilmActeur> FilmsActeurs { get; set; }
        #endregion

        #region Constructors
        public Acteur() { }
        public Acteur(string naam)
        {
            this.Acteurnaam = naam;
            this.FilmsActeurs = new List<FilmActeur>();
        } 
        #endregion
    }
}
