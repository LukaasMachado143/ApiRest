using AR.Domain.Entidades;
using AR.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AR.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<FuncionarioModel> Funcionarios { get; set; }
        public DbSet<EventoModel> Eventos { get; set; }

    }
}