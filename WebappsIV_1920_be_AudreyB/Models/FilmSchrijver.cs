using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebappsIV_1920_be_AudreyB.Models
{
    public class FilmSchrijver
    {
        #region Fields
        private int _filmID;
        private int _schrijverID;
        //private string _filmTitel;
        //private string _schrijverNaam;
        //private ICollection<string> _schrijverNamen;

        #endregion

        #region Properties
        public Film Film { get; set; }
        public Schrijver Schrijver { get; set; }
        public int FilmID
        {
            get { return _filmID; }
            set { _filmID = Film.FilmId; }
        }
        public int SchrijverID
        {
            get { return _schrijverID; }
            set { _schrijverID = Schrijver.SchrijverID; }
        }
        //public string FilmTitel
        //{
        //    get { return _filmTitel; }
        //    set { _filmTitel = Film.Titel; }
        //}
        //public string SchrijverNaam
        //{
        //    get { return _schrijverNaam; }
        //    set { _schrijverNaam = Schrijver.Naam; }
        //}
        /* public ICollection<string> Schrijversnamen
         {
             get { return _schrijverNamen; }
             set { _schrijverNamen = SchrijversNamen; }
         }*/

        //  public ICollection<string> SchrijversNamen { get; set; }
        #endregion

        #region Constructors
        public FilmSchrijver() { }
        public FilmSchrijver(Film film, Schrijver schrijver)
        {
            this.Film = film;
            this.Schrijver = schrijver;
        }
        //public FilmSchrijver(Film film, string schrijverNaam)
        //{
        //    this.Film = film;
        //    this.SchrijverNaam = schrijverNaam;
        //}
        //public FilmSchrijver(Film film, List<string> schrijversnamen)
        //{
        //    this.Film = film;
        //    this.SchrijversNamen = schrijversnamen;
        //}
        #endregion
    }
}
