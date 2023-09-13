using System.Collections.Generic;
using System.Linq;
using App.Common.Pagination;
using App.Entities;
using App.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace App.Services.Contracts
{
    public interface ICarService
    {
        Car SelectCar(int id);
        IQueryable<Car> GetAllCars();
        PagedList<Car> GetPagedCars(int page);
        Car AddNewCar(CarViewModel model);
        Car UpdateCar(CarViewModel model);
        Car DeleteCar(int id);
        LocationLogViewModel RealTimeLocation(int id);
        IQueryable<CarRealTimeStatus> RealTimeLocations();
    }
}
