using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class ProfesorConfiguration : IEntityTypeConfiguration<Profesor>
{
    public void Configure(EntityTypeBuilder<Profesor> builder)
    {
        builder.ToTable("profesor");
        
        builder.Property(e => e.IdProfesorFk)
        .HasColumnName("id_profesor");

        builder.Property(e => e.IdDepartamento)
        .HasColumnName("id_departamento");

        builder.HasOne(e => e.Departamento)
        .WithMany(e => e.Profesores)
        .HasForeignKey(e => e.IdDepartamento);

        builder.HasOne(e => e.ProfesorP)
        .WithMany(e => e.Profesores)
        .HasForeignKey(e => e.IdProfesorFk);
    }
}
