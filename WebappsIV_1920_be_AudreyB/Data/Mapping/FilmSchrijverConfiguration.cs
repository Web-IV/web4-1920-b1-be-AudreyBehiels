using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebappsIV_1920_be_AudreyB.Models;

namespace WebappsIV_1920_be_AudreyB.Data.Mapping
{
    public class FilmSchrijverConfiguration : IEntityTypeConfiguration<FilmSchrijver>
    {
        public void Configure(EntityTypeBuilder<FilmSchrijver> builder) 
        {
            builder.ToTable("FilmSchrijver");
            builder.HasKey(fg => new { fg.FilmID, fg.SchrijverID });
            builder.Property(fg => fg.FilmID).IsRequired();
            builder.Property(fg => fg.SchrijverID).IsRequired();
            //builder.Property(fg => fg.FilmTitel).IsRequired();
            //builder.Property(fg => fg.SchrijverNaam).IsRequired();

            builder.HasOne(fg => fg.Film).WithMany(fg => fg.FilmSchrijvers)
                .HasForeignKey(us => us.FilmID).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(fg => fg.Schrijver).WithMany(fg => fg.FilmSchrijvers)
                .HasForeignKey(us => us.SchrijverID).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
