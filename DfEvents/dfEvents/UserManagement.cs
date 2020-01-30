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
using dfEvents.DataAccess;
using dfEvents.Models;

namespace dfEvents
{
    public class UserManagement
    {
        private readonly IEventRepository _eventRepository;
        private readonly IMapper _mapper;


        public UserManagement(IEventRepository eventRepository, IMapper mapper)
        {
            _eventRepository = eventRepository;
            _mapper = mapper;
        }

        [FunctionName("CreateUser")]
        public async Task<IActionResult> CreateEvent(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = "createuser")] CreateUserRequest request,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            UserEntity u = new UserEntity
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                EmailAddress = request.EmailAddress,
                UserIdentity = Guid.NewGuid().ToString(),
            };

            await _eventRepository.AddUser(u);

            return new OkObjectResult(u);
        }

        [FunctionName("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "getallusers")] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var users = await _eventRepository.GetUsers();

            return new OkObjectResult(users);
        }

        [FunctionName("GetUser")]
        public async Task<IActionResult> GetUser(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = "getuser/{useridentity}")] HttpRequest req, string useridentity,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var user = await _eventRepository.GetUser(useridentity);

            return new OkObjectResult(user);
        }
    }
}
