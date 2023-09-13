using System.Collections.Generic;
using System.Linq;
using App.Common.Pagination;
using App.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Services.Contracts
{
    public interface IEventService
    {
        Event SelectEvent(int id);
        IQueryable<Event> GetAllEvents();
        PagedList<Event> GetPagedEvents(int page);
        Event AddNewEvent(Event @event);
        Event UpdateEvent(Event @event);
        Event DeleteEvent(Event @event);
    }
}