using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventManageApp.Core.Common;
using EventManageApp.Core.Models.Event;
using EventManageApp.Data.Context;
using EventManageApp.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventManageApp.Core.Services
{
    public class EventService
    {
        private readonly ApplicationDbContext _context;
        private readonly FileUploadHandler _fileUploadHandler;

        public EventService(ApplicationDbContext dbContext, FileUploadHandler uploadHandler)
        {
            _context = dbContext;
            _fileUploadHandler = uploadHandler;
        }

        public async Task<bool> CreateEvent(CreateEvent createEvent)
        {
            string fileName = await _fileUploadHandler.UploadFileAsync(createEvent.ImageFile, "Events");

            var newEvent = new Events
            {
                Title = createEvent.Title,
                Price = createEvent.Price,
                TotalSlots = createEvent.TotalSlots,
                AvailableSlots = createEvent.TotalSlots,
                EventDate = createEvent.EventDate,
                ImageUrl = fileName,
                Description = createEvent.Description,
                Status = createEvent.Status
            };
            await _context.Events.AddAsync(newEvent);
            var isSaved = await _context.SaveChangesAsync() > 0;

            if (!isSaved)
            {
                _fileUploadHandler.DeleteFile("Events", fileName);
                return false;
            }
            return true;
        }

        public async Task<IList<ViewEvents>> GetEventsAsync()
        {
            return await _context.Events.Select(e => new ViewEvents
            {
                Id = e.Id,
                Title = e.Title,
                Description = e.Description,
                EventDate = e.EventDate,
                ImageUrl = e.ImageUrl,
                Price = e.Price,
                Status = e.Status
            }).OrderByDescending(e => e.Id).ToListAsync();
        }
    }
}