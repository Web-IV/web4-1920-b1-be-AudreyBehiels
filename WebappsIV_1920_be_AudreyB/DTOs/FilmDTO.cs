using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebappsIV_1920_be_AudreyB.Models;

namespace WebappsIV_1920_be_AudreyB.DTOs
{
    public class FilmDTO
    {
        public string Titel { get; set; }
        public int Jaar { get; set; }
        public int Duur { get; set; }
        public ICollection<FilmGenre> FilmGenres { get; set; }
        public ICollection<FilmSchrijver> FilmSchrijvers { get; set; }
        public ICollection<FilmActeur> FilmActeurs { get; set; }
        public string Regisseur { get; set; }
        public string KortInhoud { get; set; }
        public string Productiebedrijf { get; set; }
    }
}
