﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Computershare.Common.NPoco;

namespace dfEvents.DataAccess.Repository
{
    public class EventRepository : IEventRepository
    {
        private readonly IDbConnectionFactory _dbFactory;
        private readonly IMapper _mapper;

        public EventRepository(IDbConnectionFactory dbFactory, IMapper mapper)
        {
            _dbFactory = dbFactory;
            _mapper = mapper;
        }

        public async Task AddEvent(EventEntity e)
        {
            using (var db = await _dbFactory.CreateConnectionAsync())
            {
                await db.InsertAsync(e);
            }
        }

        public async Task<List<EventEntity>> GetEvents()
        {
            using (var db = await _dbFactory.CreateConnectionAsync())
            {
                return await db.FetchAsync<EventEntity>("SELECT * FROM dbo.Event");
            }
        }

        public async Task<EventEntity> GetEvent(string eventIdentity)
        {
            using (var db = await _dbFactory.CreateConnectionAsync())
            {
                return await db.FirstOrDefaultAsync<EventEntity>("SELECT * FROM dbo.Event WHERE EventIdentity = @0", eventIdentity);
            }
        }

        public async Task DeleteEvent(string eventIdentity)
        {
            using (var db = await _dbFactory.CreateConnectionAsync())
            {
                 await db.ExecuteAsync("DELETE FROM dbo.Event WHERE EventIdentity = @0", eventIdentity);
            }
        }

        public async Task Rsvp(string eventIdentity)
        {
            using (var db = await _dbFactory.CreateConnectionAsync())
            {
                await db.ExecuteAsync("UPDATE dbo.Event SET Rsvp = Rsvp + 1 Where EventIdentity = @0", eventIdentity);
            }
        }
    }
}
