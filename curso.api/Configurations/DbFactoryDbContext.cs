using curso.api.Infraestruture.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace curso.api.Configurations
{
    public class DbFactoryDbContext : IDesignTimeDbContextFactory<ContextDb>
    {
        public ContextDb CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ContextDb>();
            optionsBuilder.UseSqlServer("Server=localhost;Database=CURSO;user=sa;passworld= curso1020");

            ContextDb context = new ContextDb(optionsBuilder.Options);

            return context;
        }
    }
}
