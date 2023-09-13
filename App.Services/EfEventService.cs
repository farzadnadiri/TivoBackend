using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using App.Common.Pagination;
using App.DataLayer.Context;
using App.Entities;
using App.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace App.Services
{
    public class EfEventService:IEventService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<Event> _events;


        public EfEventService(IUnitOfWork uow)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(_uow));
            _events = _uow.Set<Event>();
        }


        public PagedList<Event> GetPagedEvents(int page)
        {
            return new PagedList<Event>(_events, page);
        }

        public Event AddNewEvent(Event @event)
        {
            _events.Add(@event);
            return @event;
        }

        public Event UpdateEvent(Event @event)
        {
            throw new NotImplementedException();
        }

        public Event DeleteEvent(Event @event)
        {
            _events.Remove(@event);
            return @event;
        }

        public Event SelectEvent(int id)
        {
            return _events.Find(id);
        }

        public IQueryable<Event> GetAllEvents()
        {
            return _events;
        }
    }
}
