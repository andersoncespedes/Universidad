using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class GradoConfiguration : IEntityTypeConfiguration<Grado>
{
    public void Configure(EntityTypeBuilder<Grado> builder)
    {
        builder.ToTable("grado");

        builder.Property(e => e.Id)
        .HasColumnName("id");

        builder.Property(e => e.Nombre)
        .IsRequired()
        .HasMaxLength(100)
        .HasColumnName("nombre");
    }
}
