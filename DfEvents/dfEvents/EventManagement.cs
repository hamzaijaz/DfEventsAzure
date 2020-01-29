using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using dfEvents.DataAccess.Repository;
using AutoMapper;
using dfEvents.Models;
using dfEvents.DataAccess;

namespace dfEvents
{
    public class EventManagement
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;


        public EventManagement(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        [FunctionName("CreateEvent")]
        public async Task<IActionResult> CreateEvent(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "createevent")] CreateEventRequest request,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            EventEntity e = new EventEntity
            {
                EventIdentity = Guid.NewGuid().ToString(),
                EventTitle = request.EventTitle,
                EventDescription = request.EventDescription,
                EventDate = request.EventDate,
                EventType = request.EventType,
                Rsvp = 0,
                EventCost = request.EventCost
            };

            await _eventRepository.AddEvent(e);

            return new OkObjectResult(e);
        }

        [FunctionName("GetAllEvents")]
        public async Task<IActionResult> GetAllEvents(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "getallevents")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var events = await _eventRepository.GetEvents();

            return new OkObjectResult(events);
        }

        [FunctionName("GetEvent")]
        public async Task<IActionResult> GetEvent(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "getevent/{eventidentity}")] HttpRequest req, string eventidentity,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var e = await _eventRepository.GetEvent(eventidentity);

            return new OkObjectResult(e);
        }

        [FunctionName("DeleteEvent")]
        public async Task<IActionResult> DeleteEvent(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "deleteevent/{eventidentity}")] HttpRequest req, string eventidentity,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            await _eventRepository.DeleteEvent(eventidentity);

            return new OkObjectResult("Successfully deleted");
        }

        [FunctionName("Rsvp")]
        public async Task<IActionResult> Rsvp(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "rsvp/{eventidentity}")] HttpRequest req, string eventidentity,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            await _eventRepository.Rsvp(eventidentity);

            return new OkObjectResult("Successfully RSVP");
        }
    }
}
