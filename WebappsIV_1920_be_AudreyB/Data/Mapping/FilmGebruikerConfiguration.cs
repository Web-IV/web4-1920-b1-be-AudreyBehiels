using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebappsIV_1920_be_AudreyB.Models;

namespace WebappsIV_1920_be_AudreyB.Data.Mapping
{
    public class FilmGebruikerConfiguration : IEntityTypeConfiguration<FilmGebruiker>
    {
        public void Configure(EntityTypeBuilder<FilmGebruiker> builder)
        {
            builder.ToTable("FilmGebruiker");
            builder.HasKey(fa => new { fa.FilmID, fa.GebruikerID });
            builder.Property(fg => fg.FilmID).IsRequired();
            builder.Property(fg => fg.GebruikerID).IsRequired();

            builder.HasOne(fg => fg.Film).WithMany(fg => fg.FilmGebruikers)
                    .HasForeignKey(us => us.FilmID).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(fg => fg.Gebruiker).WithMany(fg => fg.FilmGebruikers)
                .HasForeignKey(us => us.GebruikerID).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
