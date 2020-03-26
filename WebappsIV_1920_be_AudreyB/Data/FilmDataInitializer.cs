using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebappsIV_1920_be_AudreyB.Models;

namespace WebappsIV_1920_be_AudreyB.Data
{
    public class FilmDataInitializer
    {
        private readonly FilmContext _dbFilmContext;

        public FilmDataInitializer(FilmContext dbFilmContext)
        {
            _dbFilmContext = dbFilmContext;

        }
        public void InitializeData()
        {
            _dbFilmContext.Database.EnsureDeleted();
            if (_dbFilmContext.Database.EnsureCreated())
            {
                // string titel, DateTime jaar, DateTime duur, ICollection<Genre> genre, List<String> acteurs, string regiseur, List<string> schrijvers, string korteInhoud, string productie)
                Film film1 = new Film("Titanic", new DateTime(1997), new DateTime(0, 0, 0, 0, 194, 0), new List<Genre> { Genre.Drama, Genre.Romantiek }, new List<string> { "Leonardo DiCaprio", "Kate Winslet", "Billy Zane", "Kathy Bates" }, "James Cameron", new List<string> { "James Cameron" }, "", "Paramount Pictures");
                Film film2 = new Film("Footloose", new DateTime(1984), new DateTime(0, 0, 0, 0, 107, 0), new List<Genre> { Genre.Drama, Genre.Muziek, Genre.Romantiek }, new List<string> { "Kevin Bacon", "Lori Singer","John Lithgow", "Dianne Wiest" }, "Herbert Ross", new List<string> { "Dean Pitchford" }, "", "Paramount Home Video");
                Film film3 = new Film("The Shawshank Redemption", new DateTime(1994), new DateTime(0, 0, 0, 0,142 , 0), new List<Genre> { Genre.Drama}, new List<string> { "Tim Robbins", "Morgan Freeman", "Bob Gunton", "William Sadler" }, "Frank Darabont", new List<string> {"Stephen King"}, "", "Columbia Pictures");
                Film film4 = new Film("Star Wars: Episode IV - A New Hope", new DateTime(1977), new DateTime(0, 0, 0, 0, 121, 0), new List<Genre> { Genre.Actie, Genre.Avontuur, Genre.Fantasie, Genre.Sciencefiction }, new List<string> { "Mark Hamill", "Harrison Ford", "Carrie Fisher", "Peter Cushing" }, "George Lucas", new List<string> { "George Lucas" }, "", "20th Century Fox");
                Film film5 = new Film("The NeverEnding Story", new DateTime(1984), new DateTime(0, 0, 0, 0, 102, 0), new List<Genre> { Genre.Avontuur, Genre.Drama, Genre.Fantasie, Genre.Familie }, new List<string> { "Barret Oliver", "Gerald McRaney", "Chris Eastman", "Darryl Cooksey" }, "Wolfgang Petersen", new List<string> { "Wolfgang Petersen" }, "", "Warner Home Video");
              
                _dbFilmContext.Films.AddRange(new Film[] { film1, film2, film3, film4, film5 }) ;


            }
        }
    }
}

