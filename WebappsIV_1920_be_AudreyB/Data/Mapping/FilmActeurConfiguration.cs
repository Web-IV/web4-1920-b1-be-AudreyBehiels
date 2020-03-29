using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebappsIV_1920_be_AudreyB.Models;

namespace WebappsIV_1920_be_AudreyB.Data.Mapping
{
    public class FilmActeurConfiguration : IEntityTypeConfiguration<FilmActeur>
    {
        public void Configure(EntityTypeBuilder<FilmActeur> builder)
        {
            builder.ToTable("FilmActeur");
            builder.HasKey(fa => new { fa.FilmID, fa.ActeurID });
            builder.Property(fg => fg.FilmID).IsRequired();
            builder.Property(fg => fg.ActeurID).IsRequired();
            //builder.Property(fg => fg.FilmTitel).IsRequired();
            //builder.Property(fg => fg.ActeurNaam).IsRequired();

            builder.HasOne(fg => fg.Film).WithMany(fg => fg.FilmActeurs)
                    .HasForeignKey(us => us.FilmID).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(fg => fg.Acteur).WithMany(fg => fg.FilmsActeurs)
                .HasForeignKey(us => us.ActeurID).OnDelete(DeleteBehavior.Cascade);


        }
    }
}
