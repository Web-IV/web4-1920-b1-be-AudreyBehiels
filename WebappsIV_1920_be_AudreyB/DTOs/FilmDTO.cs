using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebappsIV_1920_be_AudreyB.Models;

namespace WebappsIV_1920_be_AudreyB.DTOs
{
    public class FilmDTO
    {
        public int FilmID { get; set; }
        public string Titel { get; set; }
        public int Jaar { get; set; }
        public int Duur { get; set; }

        public ICollection<FilmGenre> FilmGenres { get; set; }
        public string Regisseur { get; set; }
        public ICollection<FilmSchrijver> FilmSchrijvers { get; set; }
        public ICollection<FilmActeur> FilmActeurs { get; set; }

        public ICollection<FilmGebruiker> FilmGebruikers { get;  set; }
        public string KorteInhoud { get; set; }
        public string Productiebedrijf { get; set; }
        public int AantalDuimenOmhoog { get; set; }
        public FilmDTO() { }

        public FilmDTO(Film film)
        {
            FilmID = film.FilmId;
            Titel = film.Titel;
            Jaar = film.Jaar;
            Duur = film.Duur;
            FilmGenres = film.FilmGenres;
            Regisseur = film.Regisseur;
            FilmSchrijvers = film.FilmSchrijvers;
            FilmActeurs = film.FilmActeurs;
            FilmGebruikers = film.FilmGebruikers;
            KorteInhoud = film.KorteInhoud;
            Productiebedrijf = film.Productiebedrijf;
            AantalDuimenOmhoog = film.AantalDuimenOmhoog;
         


        }
    }
}
