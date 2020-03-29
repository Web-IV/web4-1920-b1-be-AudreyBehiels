using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebappsIV_1920_be_AudreyB.Models;

namespace WebappsIV_1920_be_AudreyB.Data.Mapping
{
    public class FilmGenreConfiguration : IEntityTypeConfiguration<FilmGenre>
    {
        public void Configure(EntityTypeBuilder<FilmGenre> builder)
        {
            builder.ToTable("FilmGenre");
            builder.HasKey(fg => new { fg.FilmID, fg.GenreID });
            builder.Property(fg => fg.FilmID).IsRequired();
            builder.Property(fg => fg.GenreID).IsRequired();
            //builder.Property(fg => fg.FilmTitel).IsRequired();
            //builder.Property(fg => fg.GenreNaam).IsRequired();

            builder.HasOne(fg => fg.Film).WithMany(fg => fg.FilmGenres)
                .HasForeignKey(us => us.FilmID).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(fg => fg.Genre).WithMany(fg => fg.FilmGenres)
                .HasForeignKey(us => us.GenreID).OnDelete(DeleteBehavior.Cascade);

            //builder.ToTable("FilmGenre");
            //builder.HasKey(fg => new { fg.FilmTitel, fg.GenreNaam });
            //builder.Property(fg => fg.FilmTitel).IsRequired();
            //builder.Property(fg => fg.GenreNaam).IsRequired();

            //builder.HasOne(fg => fg.Film).WithMany(fg => fg.FilmGenres)
            //    .HasForeignKey(us => us.FilmTitel).OnDelete(DeleteBehavior.Cascade);

            //builder.HasOne(fg => fg.Genre).WithMany(fg => fg.FilmGenres)
            //    .HasForeignKey(us => us.GenreNaam).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
