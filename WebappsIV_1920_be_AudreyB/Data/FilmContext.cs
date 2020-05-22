using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebappsIV_1920_be_AudreyB.Data.Mapping;
using WebappsIV_1920_be_AudreyB.Models;

namespace WebappsIV_1920_be_AudreyB.Data
{
    public class FilmContext : IdentityDbContext<IdentityUser> //DbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Acteur> Acteurs { get; set; }
        public DbSet<Schrijver> Schrijvers { get; set; }
        public DbSet<FilmGenre> FilmGenres { get; set; }
        public DbSet<FilmSchrijver> FilmSchrijvers { get; set; }
        public DbSet<FilmActeur> FilmActeurs { get; set; }
        public DbSet<FilmGebruiker> FilmGebruikers { get; set; }
        public DbSet<GebruikerFilmLijst> GebruikerFilmLijst { get; set; }
       

        public DbSet<Gebruiker> Gebruikers { get; set; }

        public FilmContext(DbContextOptions<FilmContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new FilmConfiguration());
            builder.ApplyConfiguration(new FilmGenreConfiguration());
            builder.ApplyConfiguration(new FilmSchrijverConfiguration());
            builder.ApplyConfiguration(new FilmActeurConfiguration());
            builder.ApplyConfiguration(new FilmGebruikerConfiguration());
            builder.ApplyConfiguration(new GebruikerConfiguration());
            builder.ApplyConfiguration(new GebruikerFilmLijstConfiguration());

        }
    }
}
