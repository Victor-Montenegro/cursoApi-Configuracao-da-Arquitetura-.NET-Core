using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace curso.api.Models
{
    public class Context : DbContext
    {

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Curso> Cursos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=CursoApi;Integrated Security=true");
        }
    }
}
