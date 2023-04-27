using MeetupApi.BLL.DTO;
using MeetupApi.BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;      

namespace MeetupApi.UI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class EventsController : ControllerBase
        {
        private readonly IEventService _eventsService;
            public EventsController(IEventService service)
            {
                _eventsService = service ?? throw new ArgumentNullException();

            }

            [HttpGet]
            public async Task<ActionResult<EventDTO>> GetEventsAsync()
            {
                var events = await _eventsService.GetEventsAsync();
                if (events == null)
                {
                   return StatusCode(StatusCodes.Status204NoContent, "No events in database.");
                }

                return StatusCode(StatusCodes.Status200OK, events);

            }

            [HttpGet("{id}")]
            public async Task<ActionResult<EventDTO>> GetEventByIdAsync(int? id)
            {
                var @event = await _eventsService.GetEventByIdAsync(id);
                if (@event == null)
                {
                   return StatusCode(StatusCodes.Status404NotFound, $"No events found for id: {id}");
                }

                return StatusCode(StatusCodes.Status200OK, @event);

            }

            [HttpPost]
            public async Task<ActionResult> CreateEventAsync(CreateEventDTO newEvent)
            {
                var @event = await _eventsService.CreateEventAsync(newEvent);
                if (@event == null)
                {
                   return StatusCode(StatusCodes.Status400BadRequest, $"{newEvent.Title} could not be added.");
                }

                return StatusCode(StatusCodes.Status200OK, $"A new event has been created: {@event.Title}");
            }

            [HttpPut]
            public async Task<ActionResult> UpdateEventAsync(UpdateEventDTO updatedEvent,int? id)
            {
                var @event =  await _eventsService.UpdateEventAsync(updatedEvent,id);
                if (@event == null)
                {
                   return StatusCode(StatusCodes.Status400BadRequest, $"{updatedEvent.Title} could not be updated");
                }

                return StatusCode(StatusCodes.Status200OK, $"{updatedEvent.Title} successfully changed");
            }

            [HttpDelete("{id}")]
            public async Task<ActionResult> DeleteEventAsync(int? id)
            {
               (bool status, string message) = await _eventsService.DeleteEventAsync(id);
               if (status == false)
               {
                   return StatusCode(StatusCodes.Status404NotFound, message);
               }

               return StatusCode(StatusCodes.Status200OK, $"{id.Value} successfully deleted");
            }
    }
    
}
