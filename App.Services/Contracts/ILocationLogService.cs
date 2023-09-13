using System.Collections.Generic;
using System.Linq;
using App.Common.Pagination;
using App.Entities;
using Microsoft.EntityFrameworkCore;

namespace App.Services.Contracts
{
    public interface ILocationLogService
    {
        LocationLog SelectLocationLog(int id);
        IQueryable<LocationLog> GetAllLocationLogs();
        PagedList<LocationLog> GetPagedLocationLogs(int page);
        LocationLog AddNewLocationLog(LocationLog locationLog);
        LocationLog UpdateLocationLog(LocationLog locationLog);
        LocationLog DeleteLocationLog(int id);
        IQueryable<LocationLog> GetCarLocationLogs(int carId);
        PagedList<LocationLog> GetPagedCarLocationLogs(int carId,int page);
    }
}