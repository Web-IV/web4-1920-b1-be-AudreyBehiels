using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebappsIV_1920_be_AudreyB.Models
{
    public class Gebruiker
    {
        #region Properties
        public int GerbuikerID { get; set; }
        public string Voornaam { get; set; }
        public string Familienaam { get; set; }
        //  public string wachwoord { get; set; }
        public string Mailadres { get; set; }
        #endregion

        #region Constructors
        public Gebruiker()
        {

        }

        public Gebruiker(string voornaam, string familienaam, string mailadres)
        {
            this.Voornaam = voornaam;
            this.Familienaam = familienaam;
            this.Mailadres = mailadres;
        }
        #endregion


        #region Methods

        #endregion
    }
}
