
using AR.Data;
using AR.Data.Repositories;
using AR.Domain.Interfaces.Repository;
using AR.Domain.Interfaces.Service;
using AR.Domain.Services;
using Microsoft.EntityFrameworkCore;

namespace ApiRest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("ApiRestTeste")));
            builder.Services.AddScoped<IFuncionarioRepository, FuncionarioRepository>();
            builder.Services.AddScoped<IFuncionarioService, FuncionarioService>();
            builder.Services.AddScoped<IEventoRepository, EventoRepository>();
            builder.Services.AddScoped<IEventoService, EventoService>();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}