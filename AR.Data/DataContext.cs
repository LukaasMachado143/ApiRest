using AR.Domain;
using Microsoft.EntityFrameworkCore;

namespace AR.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Funcionario> Funcionarios { get; set; }
    }
}