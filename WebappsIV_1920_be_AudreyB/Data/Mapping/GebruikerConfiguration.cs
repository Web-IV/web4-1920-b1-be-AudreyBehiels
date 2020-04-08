using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebappsIV_1920_be_AudreyB.Models;

namespace WebappsIV_1920_be_AudreyB.Data.Mapping
{
    public class GebruikerConfiguration : IEntityTypeConfiguration<Gebruiker>
    {
       
        public void Configure(EntityTypeBuilder<Gebruiker> builder)
        {
            builder.ToTable("Gebruiker");
            builder.HasKey(g => g.GebruikerID);
            builder.Property(g => g.Voornaam).HasMaxLength(50).IsRequired();
            builder.Property(g => g.Familienaam).HasMaxLength(50).IsRequired();
            builder.Property(g => g.Mailadres).IsRequired();

        }
    }
}
