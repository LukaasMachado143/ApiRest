using AR.Domain.Interfaces.Repository;
using AR.Domain.Interfaces.Service;
using AR.Domain.Models;
using Microsoft.Extensions.Logging;

namespace AR.Domain.Services
{
    public class EventoService : IEventoService
    {

        private readonly IEventoRepository _eventoRepository;
        private readonly ILogger<EventoService> _log;
        public EventoService(IEventoRepository eventoRepository, ILogger<EventoService> log)
        {
            _eventoRepository = eventoRepository;
            _log = log;
        }

        public Task<IEnumerable<EventoModel>> GetAllEvents()
        {
            try
            {
                _log.LogInformation("Call method 'GetAllEvents' of repository.(Service)");
                var listaEventos = _eventoRepository.GetAllEvents();
                return listaEventos;
            }
            catch (Exception e)
            {
                _log.LogError($"Have an error when trying to call method 'GetAllEvents' of repository.(Service) | Error: {e.Message}");
                throw new Exception($"Have an error when trying to call method 'GetAllEvents' of repository.(Service) | Error: {e.Message}");
            }
        }

        public Task<IEnumerable<EventoModel>> GetEventById(int id)
        {
            try
            {
                if ( id != null ) 
                {
                    _log.LogInformation("Call method 'GetEventById' of repository.(Service)");
                    var eventoEspecífico = _eventoRepository.GetEventById(id);
                    return eventoEspecífico;
                }
                else
                {
                    _log.LogInformation("The parameter gived is null, please verify data given.");
                    throw new Exception("The parameter gived is null, please verify data given.");
                }

            }
            catch (Exception e)
            {
                _log.LogError($"Have an error when trying to call method 'GetEventById' of repository.(Service) | Error: {e.Message}");
                throw new Exception($"Have an error when trying to call method 'GetEventById' of repository.(Service) | Error: {e.Message}");
            }
        }

        public Task AddEvent(EventoModel evento)
        {
            try
            {
                if (evento != null)
                {
                    _log.LogInformation("Call method 'AddEvent' of repository.(Service)");
                    var eventoAdicionado = _eventoRepository.AddEvent(evento);
                    return eventoAdicionado;
                }
                else
                {
                    _log.LogInformation("The parameter gived is null, please verify data given.");
                    throw new Exception("The parameter gived is null, please verify data given.");
                }

            }
            catch (Exception e)
            {
                _log.LogError($"Have an error when trying to call method 'AddEvent' of repository.(Service) | Error: {e.Message}");
                throw new Exception($"Have an error when trying to call method 'AddEvent' of repository.(Service) | Error: {e.Message}");
            }
        }
            
        public async Task UpdateDataEvent(int id, EventoModel evento)
        {
            try
            {
                if (id < 0 && evento != null) 
                {
                    var eventoEncontrado = await _eventoRepository.GetEventById(id);
                    if(eventoEncontrado != null) {
                        _log.LogInformation("Call method 'UpdateDataEvent' of repository.(Service)");
                        await _eventoRepository.UpdateDataEvent(evento);
                    }

                }
                else
                {
                    _log.LogInformation("The parameter gived is null, please verify data given.");
                    throw new Exception("The parameter gived is null, please verify data given.");
                }

            }
            catch (Exception e)
            {
                _log.LogError($"Have an error when trying to call method 'UpdateDataEvent' of repository.(Service) | Error: {e.Message}");
                throw new Exception($"Have an error when trying to call method 'UpdateDataEvent' of repository.(Service) | Error: {e.Message}");
            }
        }

        public async Task RemoveEvent(int id, EventoModel evento)
        {
            try
            {
                if (id < 0 && evento != null)
                {
                    var eventoEncontrado = await _eventoRepository.GetEventById(id);
                    if (eventoEncontrado != null)
                    {
                        _log.LogInformation("Call method 'UpdateDataEvent' of repository.(Service)");
                        await _eventoRepository.RemoveEvent(evento);
                    }

                }
                else
                {
                    _log.LogInformation("The parameter gived is null, please verify data given.");
                    throw new Exception("The parameter gived is null, please verify data given.");
                }

            }
            catch (Exception e)
            {
                _log.LogError($"Have an error when trying to call method 'UpdateDataEvent' of repository.(Service) | Error: {e.Message}");
                throw new Exception($"Have an error when trying to call method 'UpdateDataEvent' of repository.(Service) | Error: {e.Message}");
            }
        }
    }
}
