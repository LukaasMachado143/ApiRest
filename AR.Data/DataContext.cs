using AR.Domain.Entidades;
using Microsoft.EntityFrameworkCore;

namespace AR.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<FuncionarioModel> Funcionarios { get; set; }
    }
}