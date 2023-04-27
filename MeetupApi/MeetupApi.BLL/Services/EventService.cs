using AutoMapper;
using MeetupApi.BLL.DTO;
using MeetupApi.BLL.Interfaces;
using MeetupApi.DAL.Modells;
using MeetupApi.BLL.Infrastructure;
using MeetupApi.DAL.Interfaces;

namespace MeetupApi.BLL.Services
{
    public class EventService : IEventService
    {
        private readonly IMapper _mapper;
        private readonly IRepository _eventRepository;

        public EventService(IMapper mapper, IRepository eventRepository)
        {
            _mapper = mapper
                ?? throw new ArgumentNullException();

            _eventRepository = eventRepository
                ?? throw new ArgumentNullException();

        }

        public async Task<IEnumerable<EventDTO>> GetEventsAsync()
        {
            try
            {
                var events = await _eventRepository.GetEventsAsync();
                return _mapper.Map<IEnumerable<EventDTO>>(events);
            }
            catch (Exception ex)
            {
                return null;
            }

        }

        public async Task<EventDTO> GetEventByIdAsync(int? id)
        {
            try
            {
                var @event = await _eventRepository.GetEventByIdAsync(id.Value);
                return _mapper.Map<EventDTO>(@event);
            }
            catch (Exception ex)
            {

                return null;
            }
        }

        public async Task<CreateEventDTO> CreateEventAsync(CreateEventDTO newEventDto)
        {
            try
            {
                var validator = new CreateEventValidator();
                var result = validator.Validate(newEventDto);
                if (!result.IsValid)
                {
                    throw new ValidationException("The entry is incorrect");
                }
                var @event = _mapper.Map<Event>(newEventDto);
                await _eventRepository.CreateEventAsync(@event);
                return newEventDto;
            }
            catch (Exception)
            {

                return null;
            }

        }

        public async Task<UpdateEventDTO> UpdateEventAsync(UpdateEventDTO eventDTO, int? id)
        {
            try
            {
                var existingEvent = await _eventRepository.GetEventByIdAsync(id.Value);
                var validator = new UpdateEventValidator();

                var result = validator.Validate(eventDTO);

                if (!result.IsValid)
                {
                    throw new ValidationException("The entry is incorrect");
                }
                var updatedEvent = _mapper.Map<Event>(eventDTO);

                updatedEvent.EventId = existingEvent.EventId;

                await _eventRepository.UpdateEventAsync(updatedEvent);
                return eventDTO;
            }
            catch (Exception ex)
            {

                return null;
            }

        }

        public async Task<(bool, string)> DeleteEventAsync(int? id)
        {
            try
            {
                var @event1 = await _eventRepository.GetEventByIdAsync(id.Value);
                if (@event1 == null)
                {
                    return (false, "Events could not be found");
                }
                await _eventRepository.DeleteEventAsync(id.Value);
                return (true, "Event got deleted.");
            }
            catch (Exception ex)
            {
                return (false, $"An error occured. Error Message: {ex.Message}");
            }

        }
    }
}
