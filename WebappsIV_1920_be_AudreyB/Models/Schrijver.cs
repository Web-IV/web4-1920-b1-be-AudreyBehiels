using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebappsIV_1920_be_AudreyB.Models
{
    public class Schrijver
    {
        #region Properties
        public int SchrijverID { get; set; }
        public string Naam { get; set; }
        [JsonIgnore]
        public Film Film { get; set; }
        [JsonIgnore]
        public ICollection<FilmSchrijver> FilmSchrijvers { get; set; }
        //public virtual ICollection<Film> Films { get; set; }
        #endregion

        #region Constructors
        public Schrijver() { }
        public Schrijver(string naam)
        {
            this.Naam = naam;
            this.FilmSchrijvers = new List<FilmSchrijver>();
            // this.Films = new List<Film>();
        }
        #endregion
    }
}
