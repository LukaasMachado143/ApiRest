using AR.Domain.Interfaces.Repository;
using AR.Domain.Models;
using Microsoft.Extensions.Logging;

namespace AR.Data.Repositories
{
    public class EventoRepository : IEventoRepository
    {
        private readonly DataContext _context;
        private readonly ILogger<EventoRepository> _log;

        public EventoRepository(DataContext context, ILogger<EventoRepository> log) {  
            _context = context; 
            _log = log;
        }

        public async Task<IEnumerable<EventoModel>> GetAllEvents()
        {
            try
            {
                _log.LogInformation("Acessing database for search all events. (Repository)");
                var listaEventos = _context.Eventos;
                return listaEventos;
            }
            catch (Exception e)
            {

                _log.LogError($"Error when trying acessing database for search all events. (Repository) | Error:{e.Message}");
                throw;
            }
        }

        public async Task<IEnumerable<EventoModel>> GetEventById(int id)
        {
            try
            {
                _log.LogInformation("Acessing database for search Event by id. (Repiository)");
                var eventoEspecifico = _context.Eventos.Where(x => x.Id == id);
                return eventoEspecifico;
            }
            catch (Exception e)
            {
                _log.LogInformation($"Error when trying acessing database for search Event by id. (Repiository) | Error:{e.Message}");
                throw;
            }
        }

        public async Task AddEvent(EventoModel evento)
        {
            try
            {
                _log.LogInformation("Registering a new event in to the database.(Repository)");
                await _context.AddAsync(evento);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                _log.LogError($"Error when trying register a new event in to the database.(Repository) | Error:{e.Message}");
                throw;
            }
        }

        public async Task UpdateDataEvent(EventoModel evento)
        {
            try
            {
                _log.LogInformation("Changing data of event in to the database.(Repository)");
                _context.Update(evento);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                _log.LogError($"Error when trying Changing data of event in to the database.(Repository) | Error:{e.Message}");
                throw;
            }
        }
        public async Task RemoveEvent(EventoModel evento)
        {
            try
            {
                _log.LogInformation("Removing event in to the database.(Repository)");
                _context.Remove(evento);
                await _context.SaveChangesAsync();
            }
            catch (Exception e)
            {

                _log.LogError($"Error when trying Removing event in to the database.(Repository) | Error:{e.Message}");
                throw;
            }
        }
    }
}
