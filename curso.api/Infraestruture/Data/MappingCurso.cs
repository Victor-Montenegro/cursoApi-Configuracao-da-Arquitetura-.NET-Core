﻿using curso.api.Platform.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curso.api.Infraestruture.Data
{
    public class MappingCurso : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.ToTable("TB_CURSO");
            builder.HasKey(p => p.Codigo);
            builder.Property(p => p.Codigo).ValueGeneratedOnAdd();
            builder.Property(p => p.Descricao);
            builder.Property(p => p.Nome);
            builder.HasOne(p => p.Usuario)
                .WithMany().HasForeignKey(fk => fk.CodigoUsuario);
        }
    }
}
