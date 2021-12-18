using curso.api.Platform.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curso.api.Infraestruture.Data
{
    public class ContextDb : DbContext
    {

        public DbSet<Usuario> Usuario { get; set; }

        public DbSet<Curso> Curso { get; set; }

        public ContextDb(DbContextOptions<ContextDb> options) :base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MappingCurso());
            modelBuilder.ApplyConfiguration(new MappingUsuario());

            base.OnModelCreating(modelBuilder);
        }
    }
}
