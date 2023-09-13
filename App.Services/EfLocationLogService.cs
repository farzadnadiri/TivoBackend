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
    public class EfLocationLogService:ILocationLogService
    {
        private readonly IUnitOfWork _uow;
        private readonly DbSet<LocationLog> _locationLogs;
   

        public EfLocationLogService(IUnitOfWork uow)
        {
            _uow = uow ?? throw new ArgumentNullException(nameof(_uow));
            _locationLogs = _uow.Set<LocationLog>();
        }

        public PagedList<LocationLog> GetPagedLocationLogs(int page)
        {
            return new PagedList<LocationLog>(_locationLogs, page);
        }

        public LocationLog AddNewLocationLog(LocationLog locationLog)
        {
            _locationLogs.Add(locationLog);
            return locationLog;
        }

        public LocationLog UpdateLocationLog(LocationLog locationLog)
        {
            throw new NotImplementedException();
        }

        public LocationLog DeleteLocationLog(int id)
        {
            var locationLog = SelectLocationLog(id);
            _locationLogs.Remove(locationLog);
            return locationLog;
        }

        public IQueryable<LocationLog> GetCarLocationLogs(int carId)
        {
            return _locationLogs.Where(q => q.Car.Id == carId);
        }

        public PagedList<LocationLog> GetPagedCarLocationLogs(int carId, int page)
        {
            var query= _locationLogs.Where(q => q.Car.Id == carId).OrderByDescending(d=>d.Time).ToList();
            return new PagedList<LocationLog>(query, page);
        }

        public LocationLog SelectLocationLog(int id)
        {
            return _locationLogs.Include(d=>d.Car).Single(d=>d.Id==id);
        }

        public IQueryable<LocationLog> GetAllLocationLogs()
        {
            return _locationLogs.Include(d=>d.Car).OrderByDescending(d=>d.Time);
        }
    }
}
