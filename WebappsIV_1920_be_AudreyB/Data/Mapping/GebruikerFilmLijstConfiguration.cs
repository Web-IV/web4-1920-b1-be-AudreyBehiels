using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WebappsIV_1920_be_AudreyB.Models;

namespace WebappsIV_1920_be_AudreyB.Data.Mapping
{
    public class GebruikerFilmLijstConfiguration : IEntityTypeConfiguration<GebruikerFilmLijst>
    {
        public void Configure(EntityTypeBuilder<GebruikerFilmLijst> builder)
        {

            builder.ToTable("GebruikerFilmLijst");
            builder.HasKey(fa => new { fa.FilmID, fa.GebruikerID });
            builder.Property(fg => fg.GebruikerID).IsRequired();
            builder.Property(fg => fg.FilmID).IsRequired();

            builder.HasOne(fg => fg.Film).WithMany(fg => fg.GebruikerFilmLijst)
                    .HasForeignKey(us => us.FilmID).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(fg => fg.Gebruiker).WithMany(fg => fg.GebruikerFilmLijst)
               .HasForeignKey(us => us.GebruikerID).OnDelete(DeleteBehavior.Cascade);

        }
    }
}