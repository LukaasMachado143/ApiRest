using AR.Domain.Models;

namespace AR.Domain.Interfaces.Repository
{
    public interface IEventoRepository
    {
        Task <IEnumerable<EventoModel>> GetAllEvents();
        Task <IEnumerable<EventoModel>> GetEventById(int id);
        Task AddEvent(EventoModel evento);
        Task RemoveEvent(EventoModel evento);
        Task UpdateDataEvent(EventoModel evento);
    }
}
