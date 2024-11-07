using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventManageApp.Core.Models.Event;
using EventManageApp.Data.Context;
using EventManageApp.Data.Entities;

namespace EventManageApp.Core.Services
{
    public class EventService
    {
        private readonly ApplicationDbContext _context;

        public EventService(ApplicationDbContext dbContext)
        {
            _context = dbContext;
        }

        public void CreateEvent(CreateEvent Event)
        {

            var newEvent = new Events
            {
                Title = Event.Title,
                Price = Event.Price,
                TotalSlots = Event.TotalSlots,
                AvailableSlots = Event.TotalSlots,
                EventDate = Event.EventDate,
                ImageUrl = ""
            };
        }
    }
}