using dfEvents.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace dfEvents.DataAccess.Repository
{
    public interface IEventRepository
    {
        Task AddEvent(EventEntity e);
        Task<List<EventEntity>> GetEvents();
        Task DeleteEvent(string eventIdentity);
        Task <EventEntity> GetEvent(string eventIdentity);
        Task Rsvp(string eventIdentity);

    }
}
