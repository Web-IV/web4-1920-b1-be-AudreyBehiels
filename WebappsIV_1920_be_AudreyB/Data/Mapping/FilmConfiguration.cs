using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebappsIV_1920_be_AudreyB.Models;

namespace WebappsIV_1920_be_AudreyB.Data.Mapping
{
    public class FilmConfiguration : IEntityTypeConfiguration<Film>
    {
        public void Configure(EntityTypeBuilder<Film> builder)
        {
            builder.ToTable("Film");
            builder.HasKey(f => f.FilmId);
            builder.Property(f => f.Titel).IsRequired();
            builder.Property(f => f.Jaar).IsRequired();
            builder.Property(f => f.Regisseur).IsRequired();
            builder.Property(f => f.Productiebedrijf).IsRequired();
            builder.Property(f => f.KortInhoud).IsRequired();
            builder.Property(f => f.AantalDuimenOmhoog);


        }
    }
}
