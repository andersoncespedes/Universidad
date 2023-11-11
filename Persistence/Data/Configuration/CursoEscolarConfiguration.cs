using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.Data.Configuration;
public class CursoEscolarConfiguration : IEntityTypeConfiguration<CursoEscolar>
{
    public void Configure(EntityTypeBuilder<CursoEscolar> builder)
    {
        builder.ToTable("curso_escolar");

        builder.Property(e => e.AnyoInicio)
        .HasColumnName("anyo_inicio")
        .HasColumnType("year");  // Opcional: Configurar el tipo de columna de la base de datos como fecha

         builder.Property(e => e.AnyoFin)
        .HasColumnName("anyo_fin")
        .HasColumnType("year");  
    }
}
