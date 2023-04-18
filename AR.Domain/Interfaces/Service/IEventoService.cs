using AR.Domain.Models;

namespace AR.Domain.Interfaces.Service
{
    public interface IEventoService
    {
        Task<IEnumerable<EventoModel>> GetAllEvents();
        Task<IEnumerable<EventoModel>> GetEventById(int id);
        Task AddEvent(EventoModel evento);
        Task RemoveEvent(int id, EventoModel evento);
        Task UpdateDataEvent(int id, EventoModel evento);
    }
}
