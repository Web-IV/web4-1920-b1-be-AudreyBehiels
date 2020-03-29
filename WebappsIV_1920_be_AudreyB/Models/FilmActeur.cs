using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebappsIV_1920_be_AudreyB.Models
{
    public class FilmActeur
    {
        #region Fields
        private int _filmID;
        private int _acteurID;
        //private string _filmTitel;
        //private string _acteurNaam;
        //private ICollection<string> _acteursNamen;
        #endregion

        #region Properties
        public Film Film { get; set; }
        public Acteur Acteur { get; set; }
        public int FilmID
        {
            get { return _filmID; }
            set { _filmID = Film.FilmId; }
        }
        public int ActeurID
        {
            get { return _acteurID; }
            set { _acteurID = Acteur.ActeurID; }
        }
        //public string FilmTitel
        //{
        //    get { return _filmTitel; }
        //    set { _filmTitel = Film.Titel; }
        //}
        //public string ActeurNaam
        //{
        //    get { return _acteurNaam; }
        //    set { _acteurNaam = Acteur.Acteurnaam; }
        //}
        //  public ICollection<string> ActeursNamen { get; set; }
        #endregion

        #region Constructors
        public FilmActeur() { }
        public FilmActeur(Film film, Acteur acteur)
        {
            this.Film = film;
            this.Acteur = acteur;
        }
        //public FilmActeur(Film film, string acteurNaam)
        //{
        //    this.Film = film;
        //    this.ActeurNaam = acteurNaam;
        //}
        //public FilmActeur(Film film, List<string> acteursNamen)
        //{
        //    this.Film = film;
        //    this.ActeursNamen = acteursNamen;
        //}
        #endregion
    }
}
